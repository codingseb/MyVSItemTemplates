namespace $rootnamespace$;

/// <summary>
/// The interface to implement to make an undoable redoable action to store in a UndoRedoStack
/// </summary>
public interface IUndoRedoAction
{
    /// <summary>
    /// This method is called when the action need to be undo.<br/>
    /// Implementation of the action that undo an action
    /// </summary>
    void Undo();

    /// <summary>
    /// This method is called when the action has been undo and need to be redo<br/>
    /// Implementation of the action that redo an action
    /// </summary>
    void Redo();
}