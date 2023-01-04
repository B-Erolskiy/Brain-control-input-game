using Diplom.Entities.Input;

namespace Diplom.Gateway.Input
{
  public interface IInputDBGateway
  {
    Entities.Input.Input GetInputData();
    float GetHorizontalMovement();
    void SetHorizontalMovement(float newHorizontalMovement);
    InputType GetInputType();
    void SetInputType(InputType newInputType);
  }
}