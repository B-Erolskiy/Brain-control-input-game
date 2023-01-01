using Diplom.Gateway.Player;
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

            Container.Bind<IPlayerDBGateway>().FromInstance(gateway);
            Container.Bind<IPlayerUsecase>().FromInstance(usecase);
            Container.Bind<IPlayerStatsPresenter>().FromInstance(playerStatsPresenter);

            var playerUIPresenter = new PlayerUIPresenter();
            playerUIPresenter.Initialize(usecase);
            Container.Bind<IPlayerUIPresenter>().FromInstance(playerUIPresenter);
        }
    }
}