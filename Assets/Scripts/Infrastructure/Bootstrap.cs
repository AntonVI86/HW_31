using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private MainHeroSpawner _mainHeroSpawner;
    [SerializeField] private EnemiesSpawner _enemiesSpawner;

    [SerializeField] private LoadingScreen _loadingScreen;

    private void Awake()
    {
        StartCoroutine(StartProcess());
    }

    private IEnumerator StartProcess()
    {
        _loadingScreen.Show();
        _loadingScreen.ShowMessage("Загрузка...");

        yield return new WaitForSeconds(1.5f);

        _loadingScreen.Hide();

        Character mainHero = _mainHeroSpawner.Spawn();
        _enemiesSpawner.Spawn(mainHero.transform);
    }
}
