using Diplom.Gateway.BrainStats;
using Diplom.Presenters.Input.Brain;
using Diplom.Usecases.BrainStats;
using Zenject;

namespace Diplom.Installers
{
  public class BrainStatsInstaller : MonoInstaller
  {
    public override void InstallBindings()
    {
      Container.Bind<IBrainStatsGateway>().To<BrainStatsGateway>().AsSingle();
      Container.Bind<IBrainStatsUsecase>().To<BrainStatsUsecase>().AsSingle();
      Container.Bind<IBrainStatsPresenter>().To<BrainStatsPresenter>().AsSingle();
    }
  }
}