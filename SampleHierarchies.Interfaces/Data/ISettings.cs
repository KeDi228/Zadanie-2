using SampleHierarchies.Interfaces.Data.Mammals;

namespace SampleHierarchies.Interfaces.Data;

/// <summary>
/// Settings interface.
/// </summary>
public interface ISettings
{
    #region Interface Members

    /// <summary>
    /// Version of settings.
    /// </summary>
    string Version { get; set; }

    //enum ColorScreenChoices ScreenNumber { }
    int ScreenNumber { get; set; }//KeDi
    ConsoleColor MainTextColor { get; set; }//KeDi
    ConsoleColor MainBackgroundColor { get; set; }//KeDi

    /// <summary>
    /// Settings collection.
    /// </summary>
    List<ISettings> Setting { get; set; }

    #endregion // Interface Members
}

