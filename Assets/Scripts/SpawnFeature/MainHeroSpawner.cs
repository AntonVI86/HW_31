using Cinemachine;
using UnityEngine;

public class MainHeroSpawner : MonoBehaviour
{
    [SerializeField] private AgentCharacter _prefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private CinemachineVirtualCamera _followCamera;

    private Controller _controller;

    private void Awake()
    {
        Spawn(_spawnPoint.position);
    }

    private void Spawn(Vector3 position)
    {
        AgentCharacter instance = Instantiate(_prefab, position, Quaternion.identity, null);
        _followCamera.Follow = instance.CameraTarget;

        _controller = new KeyboardCharacterController(instance);

        _controller.Enable();
    }

    private void Update()
    {
        _controller?.Update(Time.deltaTime);
    }
}
