using UnityEngine;
using System.Collections.Generic;

public class ActionCommandInvoker
{
    private static Stack<IActionCommand> _actionCommandHistory = new Stack<IActionCommand>();

    public static void ExecuteCommand(IActionCommand command)
    {
        _actionCommandHistory.Push(command);
        command.ExecuteAction();
    }

    public static void UndoCommand()
    {
        if (_actionCommandHistory.Count > 0)
        {
            IActionCommand activeCommand = _actionCommandHistory.Pop();
            activeCommand.UndoAction();
        }
    }
}
