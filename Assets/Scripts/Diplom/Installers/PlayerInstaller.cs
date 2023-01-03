using Diplom.Gateway.Player;
using Diplom.Presenters.Level;
using Diplom.Presenters.Player;
using Diplom.Presenters.PlayerUI;
using Diplom.Usecases.Player;
using Zenject;

namespace Diplom.Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            var gateway = new PlayerDBGateway();
            var usecase = new PlayerUsecase(gateway);
            var playerStatsPresenter = new PlayerStatsPresenter();
            playerStatsPresenter.Initialize(usecase);

            Container.Bind<IPlayerDBGateway>().FromInstance(gateway).AsSingle();;
            Container.Bind<IPlayerUsecase>().FromInstance(usecase).AsSingle();;
            Container.Bind<IPlayerStatsPresenter>().FromInstance(playerStatsPresenter).AsSingle();;

            Container.Bind<IPlayerUIPresenter>().To<PlayerUIPresenter>().AsSingle();
        }
    }
}