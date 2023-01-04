using Diplom.Entities.Input;
using UniRx;

namespace Diplom.Usecases.Input
{
  public interface IInputUsecase
  {
    IReadOnlyReactiveProperty<Entities.Input.Input> Input { get; }
    
    void SetInputType(InputType inputType);
  }
}