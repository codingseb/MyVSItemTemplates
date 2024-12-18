namespace $rootnamespace$;

/// <summary>
/// <para>A double stack of undo and redo action.</para>
/// An <see cref="IUndoRedoAction"/> can be pushed and then undo and redo.<br/>
/// Each time a new action is pushed the Redo stack is cleared.<br/>
/// Each time a action is undone, this action is pop out of the Undo Stack and pushed in the Redo stack.<br/>
/// Each time a action is redone, this action is pop out of the Redo Stack and pushed in the Undo stack again.<br/>
/// </summary>
public class $safeitemname$
{
    private Stack<IUndoRedoAction> UndoStack { get; set; } = [];
    private Stack<IUndoRedoAction> RedoStack { get; set; } = [];

    /// <summary>
    /// Undo the last pushed action
    /// </summary>
    public void Undo()
    {
        if (UndoStack.Count == 0)
            return;

        var action = UndoStack.Pop();

        action.Undo();

        RedoStack.Push(action);
    }

    /// <summary>
    /// To Check if there is at least one action to undo
    /// </summary>
    /// <returns><c>true</c> if an action can be undo,<c>false</c> if no action is stacked</returns>
    public bool CanUndo() => UndoStack.Count > 0;

    /// <summary>
    /// Redo the last undone action
    /// </summary>
    public void Redo()
    {
        if (RedoStack.Count == 0)
            return;

        var action = RedoStack.Pop();

        action.Redo();

        UndoStack.Push(action);
    }

    /// <summary>
    /// To Check if there is at least one action to redo
    /// </summary>
    /// <returns><c>true</c> if an action can be redo,<c>false</c> if no action is undone</returns>
    public bool CanRedo() => RedoStack.Count > 0;

    /// <summary>
    /// Add action to the Undo stack
    /// </summary>
    /// <param name="undoRedoAction">The undo/redo action to push in undo stack</param>
    public void PushAction(IUndoRedoAction undoRedoAction)
    {
        if (UndoStack.Peek() is UndoRedoTransaction transaction && transaction.RecursiveOpen > 0)
        {
            transaction.PushAction(undoRedoAction);
        }
        else
        {
            UndoStack.Push(undoRedoAction);
        }
        RedoStack.Clear();
    }

    /// <summary>
    /// When called open an aggregate <see cref="IUndoRedoAction"/> that will store all next Pushed actions until <see cref="CloseTransaction"/> is call.<br/>
    /// After that all <see cref="IUndoRedoAction"/> stored in the transaction will be undone or redone together.<para/>
    /// </summary>
    /// <remarks>Each call of <see cref="OpenTransaction"/> need a corresponding call to <see cref="CloseTransaction"/> to really close the transaction</remarks>
    public void OpenTransaction()
    {
        if(UndoStack.Peek() is UndoRedoTransaction transaction && transaction.RecursiveOpen > 0)
        {
            transaction.RecursiveOpen++;
        }
        else
        {
            UndoStack.Push(new UndoRedoTransaction());
        }
    }

    /// <summary>
    /// Close a previously opened transaction with <see cref="OpenTransaction"/>
    /// </summary>
    /// <remarks>Each call of <see cref="OpenTransaction"/> need a corresponding call to <see cref="CloseTransaction"/> to really close the transaction</remarks>
    public void CloseTransaction()
    {
        if (UndoStack.Peek() is UndoRedoTransaction transaction && transaction.RecursiveOpen > 0)
        {
            transaction.RecursiveOpen--;
        }
    }

    /// <summary>
    /// Clear all undo/redo actions
    /// </summary>
    public void Clear()
    {
        UndoStack.Clear();
        RedoStack.Clear();
    }

    private class UndoRedoTransaction : IUndoRedoAction
    {
        private Stack<IUndoRedoAction> UndoStack { get; set; } = [];
        private Stack<IUndoRedoAction> RedoStack { get; set; } = [];

        public int RecursiveOpen { get; set; } = 1;

        public void Undo()
        {
            while (UndoStack.Count > 0)
            {
                var action = UndoStack.Pop();
                action.Undo();
                UndoStack.Push(action);
            }
        }
        public void Redo()
        {
            while(RedoStack.Count > 0)
            {
                var action = RedoStack.Pop();
                action.Redo();
                UndoStack.Push(action);
            }
        }

        public void PushAction(IUndoRedoAction undoRedoAction)
        {
            UndoStack.Push(undoRedoAction);
            RedoStack.Clear();
        }
    }
}