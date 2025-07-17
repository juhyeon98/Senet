using UnityEngine;

public class MovementCommand : IActionCommand
{
    private AActor _actor;
    private Vector3 _direction;

    public MovementCommand(AActor actor, Vector2 direction)
    {
        _actor = actor;
        _direction = direction;
    }

    public void ExecuteAction()
    {
        _actor.Move(_direction);
    }

    public void UndoAction()
    {
        _actor.Move(-_direction);
    }
}
