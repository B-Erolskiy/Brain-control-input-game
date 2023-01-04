using Diplom.Presenters.MenuSceneUI;
using Zenject;

namespace Diplom.Installers
{
    public class MenuInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            var menuSceneUIPresenter = new MenuSceneUIPresenter();
            menuSceneUIPresenter.Initialize();
            Container.Bind<IMenuSceneUIPresenter>().FromInstance(menuSceneUIPresenter);

            Container.Bind<IMenuUIPresenter>().To<MenuUIPresenter>().AsSingle();
        }
    }
}