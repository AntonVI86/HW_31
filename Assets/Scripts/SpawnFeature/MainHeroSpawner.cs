using Cinemachine;
using UnityEngine;

public class MainHeroSpawner : MonoBehaviour
{
    [SerializeField] private MainHeroCharacter _prefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private CinemachineVirtualCamera _followCamera;

    private ControllersUpdateService _controllersUpdateService;

    public void Initialize(ControllersUpdateService controllersUpdateService)
    {
        _controllersUpdateService = controllersUpdateService;
    }

    public MainHeroCharacter Spawn()
    {
        MainHeroCharacter instance = Instantiate(_prefab, _spawnPoint.position, Quaternion.identity, null);

        instance.Initialize();

        _followCamera.Follow = instance.CameraTarget;

        Controller controller = new CompositeController
            (new KeyboardPlayerController(instance)
            );

        controller.Enable();

        _controllersUpdateService.Add(controller);

        return instance;
    }
}
