using Analytics;
using UnityEngine;
using Zenject;

public class ProjectInstaller : MonoInstaller
{
    [SerializeField] private GameAnalytics _gameAnalyticsPrefab;
    public override void InstallBindings()
    {
        BindGameAnalytics();
    }
    private void BindGameAnalytics()
    {
        Container.Bind<GameAnalytics>()
            .FromComponentInNewPrefab(_gameAnalyticsPrefab)
            .AsSingle()
            .NonLazy();
    }
}