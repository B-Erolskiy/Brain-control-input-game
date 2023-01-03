using Diplom.Gateway.Level;
using Diplom.Presenters.Level;
using Diplom.ScriptableObjects;
using Diplom.ScriptableObjects.Level;
using Diplom.Usecases.Level;
using UnityEngine;
using Zenject;

namespace Diplom.Installers
{
  public class LevelProjectInstaller : MonoInstaller
  {
    [SerializeField] private LevelCollectionObject _levelCollectionObject;
    
    public override void InstallBindings()
    {
      var levelDBGateway = new LevelDBGateway(_levelCollectionObject);
      var levelUsecase = new LevelUsecase(levelDBGateway);
      Container.Bind<ILevelDBGateway>().FromInstance(levelDBGateway).AsSingle();
      Container.Bind<ILevelUsecase>().FromInstance(levelUsecase).AsSingle();
      Container.Bind<ILevelLoaderPresenter>().To<LevelLoaderPresenter>().AsSingle();
    }
  }
}