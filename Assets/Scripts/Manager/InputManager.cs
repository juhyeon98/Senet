using UnityEngine;

public class InputManager : MonoBehaviour
{
    public AActor player;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            OnUpInput();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            OnDownInput();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            OnLeftInput();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            OnRightInput();
        }
    }

    private void ExecuteActorCommand(AActor actor, Vector2 direction)
    {
        if (actor.CanMoveTo(direction))
        {
            IActionCommand command = new MovementCommand(actor, direction);
            ActionCommandInvoker.ExecuteCommand(command);
        }
    }

    private void OnUpInput()
    {
        ExecuteActorCommand(player, Vector2.up);
    }

    private void OnDownInput()
    {
        ExecuteActorCommand(player, Vector2.down);
    }

    private void OnLeftInput()
    {
        ExecuteActorCommand(player, Vector2.left);
    }

    private void OnRightInput()
    {
        ExecuteActorCommand(player, Vector2.right);
    }
}
