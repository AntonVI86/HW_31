using Cinemachine;
using UnityEngine;

public class MainHeroSpawner : MonoBehaviour
{
    [SerializeField] private Character _prefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private CinemachineVirtualCamera _followCamera;

    private Controller _controller;

    public Character Spawn()
    {
        Character instance = Instantiate(_prefab, _spawnPoint.position, Quaternion.identity, null);
        _followCamera.Follow = instance.CameraTarget;

        _controller = new CompositeController
            (new KeyboardPlayerController(instance)
            );

        _controller.Enable();

        return instance;
    }

    private void Update()
    {
        _controller?.Update(Time.deltaTime);
    }
}
