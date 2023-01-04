using Diplom.Gateway.Settings;
using Diplom.Presenters.Settings;
using Diplom.Usecases.Settings;
using Zenject;

namespace Diplom.Installers
{
  public class SettingsInstaller : MonoInstaller
  {
    public override void InstallBindings()
    {
      var gateway = new SettingsDBGateway();
      var usecase = new SettingsUsecase(gateway);
      var presenter = new SettingsPresenter();
      presenter.Initialize(usecase);

      Container.Bind<ISettingsDBGateway>().FromInstance(gateway);
      Container.Bind<ISettingsUsecase>().FromInstance(usecase);
      Container.Bind<ISettingsPresenter>().FromInstance(presenter);
    }
  }
}