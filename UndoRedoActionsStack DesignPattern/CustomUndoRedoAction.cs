namespace $rootnamespace$;

/// <summary>
/// A customizable UndoRedo Action<br/>
/// (Without Data) To pass data use <see cref="CustomUndoRedoAction&lt;T&gt;"/>  or <see cref="CustomUndoRedoAction&lt;TUndo,TRedo&gt;"/>
/// </summary>
public class CustomUndoRedoAction : IUndoRedoAction
{
    /// <summary>
    /// The action to execute on Undo
    /// </summary>
    public Action? UndoAction { get; set; }

    /// <summary>
    /// The action to execute on Redo
    /// </summary>
    public Action? RedoAction { get; set; }

    /// <inheritdoc/>
    public void Undo()
    {
        UndoAction?.Invoke();
    }

    /// <inheritdoc/>
    public void Redo()
    {
        RedoAction?.Invoke();
    }
}

/// <summary>
/// A customizable Undo/Redo Action<br/>
/// With shared custom data to pass to actions
/// </summary>
/// <typeparam name="T">The type of the <see cref="Data"/> to pass to <see cref="UndoAction"/> and <see cref="RedoAction"/></typeparam>
public class CustomUndoRedoAction<T> : IUndoRedoAction
{
    /// <summary>
    /// Will be pass to <see cref="UndoAction"/> and <see cref="RedoAction"/> when called
    /// </summary>
    public T? Data { get; set; }

    /// <summary>
    /// The action to execute on Undo
    /// </summary>
    public Action<T?>? UndoAction { get; set; }

    /// <summary>
    /// The action to execute on Redo
    /// </summary>
    public Action<T?>? RedoAction { get; set; }

    /// <inheritdoc/>
    public void Undo()
    {
        UndoAction?.Invoke(Data);
    }

    /// <inheritdoc/>
    public void Redo()
    {
        RedoAction?.Invoke(Data);
    }
}

/// <summary>
/// A customizable Undo/Redo Action<br/>
/// With specific custom data to pass to each actions
/// </summary>
/// <typeparam name="TUndo">The type of the <see cref="UndoData"/> to pass to <see cref="UndoAction"/></typeparam>
/// <typeparam name="TRedo">The type of the <see cref="RedoData"/> to pass to <see cref="RedoAction"/></typeparam>
public class CustomUndoRedoAction<TUndo,TRedo> : IUndoRedoAction
{
    /// <summary>
    /// Will be pass to <see cref="UndoAction"/> when called
    /// </summary>
    public TUndo? UndoData { get; set; }

    /// <summary>
    /// Will be pass to <see cref="RedoAction"/> when called
    /// </summary>
    public TRedo? RedoData { get; set; }

    /// <summary>
    /// The action to execute on Undo
    /// </summary>
    public Action<TUndo?>? UndoAction { get; set; }

    /// <summary>
    /// The action to execute on Redo
    /// </summary>
    public Action<TRedo?>? RedoAction { get; set; }

    /// <inheritdoc/>
    public void Undo()
    {
        UndoAction?.Invoke(UndoData);
    }

    /// <inheritdoc/>
    public void Redo()
    {
        RedoAction?.Invoke(RedoData);
    }
}
