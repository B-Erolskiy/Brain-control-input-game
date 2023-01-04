using Diplom.Presenters.Level;
using UnityEngine;
using Zenject;

namespace Diplom.Installers
{
    public class LevelBuilderInstaller : MonoInstaller
    {
        [SerializeField] private LevelBuilderPresenter _levelBuilderPresenter;
        
        public override void InstallBindings()
        {
            Container.Bind<ILevelBuilderPresenter>().FromInstance(_levelBuilderPresenter).AsSingle();
        }
    }
}