using Diplom.Entities.Input;

namespace Diplom.Gateway.Input
{
  public class InputDBGateway : IInputDBGateway
  {
    private readonly Entities.Input.Input _input;

    public InputDBGateway()
    {
      _input = new Entities.Input.Input();
    }

    public Entities.Input.Input GetInputData() => _input;

    public float GetHorizontalMovement() => _input.HorizontalMovement;

    public void SetHorizontalMovement(float newHorizontalMovement)
    {
      _input.HorizontalMovement = newHorizontalMovement;
    }

    public InputType GetInputType() => _input.InputType;

    public void SetInputType(InputType newInputType)
    {
      _input.InputType = newInputType;
    }
  }
}