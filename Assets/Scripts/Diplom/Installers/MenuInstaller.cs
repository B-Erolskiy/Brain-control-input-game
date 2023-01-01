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

            var menuUIPresenter = new MenuUIPresenter();
            menuUIPresenter.Initialize(menuSceneUIPresenter);
            Container.Bind<IMenuUIPresenter>().FromInstance(menuUIPresenter);
        }
    }
}