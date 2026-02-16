using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private MainHeroSpawner _mainHeroSpawner;
    [SerializeField] private EnemiesSpawner _enemiesSpawner;

    [SerializeField] private LoadingScreen _loadingScreen;
    [SerializeField] private ConfirmPopup _confirmPopup;

    private ControllersUpdateService _controllersUpdateService;

    private void Awake()
    {
        StartCoroutine(StartProcess());
    }

    private IEnumerator StartProcess()
    {
        _loadingScreen.Show();
        _loadingScreen.ShowMessage("Загрузка...");

        _controllersUpdateService = new ControllersUpdateService();

        _mainHeroSpawner.Initialize(_controllersUpdateService);
        _enemiesSpawner.Initialize(_controllersUpdateService);
        MainHeroCharacter mainHero = _mainHeroSpawner.Spawn();


        yield return new WaitForSeconds(1.5f);

        _loadingScreen.Hide();

        _confirmPopup.Show();
        _confirmPopup.ShowMessage($"Press {KeyCode.F.ToString()} for begin");

        yield return _confirmPopup.WaitConfirm(KeyCode.F);

        _confirmPopup.Hide();
        _enemiesSpawner.Spawn(mainHero.transform);
    }

    private void Update()
    {
        _controllersUpdateService?.Update(Time.deltaTime);
    }
}
