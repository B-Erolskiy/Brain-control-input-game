using Diplom.Gateway.Input;
using Diplom.Presenters.Input;
using Diplom.Presenters.Input.Keyboard;
using Diplom.Usecases.Input;
using Diplom.Usecases.Input.Keyboard;
using Zenject;

namespace Diplom.Installers
{
  public class InputInstaller : MonoInstaller
  {
    public override void InstallBindings()
    {
      Container.Bind<IInputDBGateway>().To<InputDBGateway>().AsSingle();
      Container.Bind<IInputUsecase>().To<InputUsecase>().AsSingle();
      Container.Bind<IInputPresenter>().To<InputPresenter>().AsSingle();
      
      Container.Bind<IKeyboardInputUsecase>().To<KeyboardInputUsecase>().AsSingle();
      Container.Bind<IKeyboardInputPresenter>().To<KeyboardInputPresenter>().AsSingle();
    }
  }
}