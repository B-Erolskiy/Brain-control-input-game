using Diplom.Entities.Input;
using UniRx;

namespace Diplom.Presenters.Input
{
  public interface IInputPresenter
  {
    IReadOnlyReactiveProperty<InputType> InputType { get; }
    IReadOnlyReactiveProperty<float> HorizontalMovement { get; }
    void SetInputType(InputType newInputType);
  }
}