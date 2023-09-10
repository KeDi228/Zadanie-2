namespace SampleHierarchies.Gui;

/// <summary>
/// Abstract base class for a screen.
/// </summary>
public abstract class Screen
{
    #region Public Methods

    /// <summary>
    /// Show the screen.
    /// </summary>
    public virtual void Show()
    {
        Console.WriteLine("Showing screen");
    }

    #endregion // Public Methods

    #region Properties

    public virtual string? ScreenDefinitionJson { get; set; }


    #endregion // Properties
}
