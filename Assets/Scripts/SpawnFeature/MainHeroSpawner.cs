using Cinemachine;
using UnityEngine;

public class MainHeroSpawner : MonoBehaviour
{
    [SerializeField] private Character _prefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private CinemachineVirtualCamera _followCamera;

    private Controller _controller;

    private void Awake()
    {
        Spawn(_spawnPoint.position);
    }

    private void Spawn(Vector3 position)
    {
        Character instance = Instantiate(_prefab, position, Quaternion.identity, null);
        _followCamera.Follow = instance.CameraTarget;

        _controller = new CompositeController
            (new PlayerDirectionMoveableController(instance), 
            new PlayerDirectionRotatableController(instance));

        _controller.Enable();
    }

    private void Update()
    {
        _controller?.Update(Time.deltaTime);
    }
}
