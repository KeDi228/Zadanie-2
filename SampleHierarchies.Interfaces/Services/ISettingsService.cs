using SampleHierarchies.Interfaces.Data;

namespace SampleHierarchies.Interfaces.Services;

/// <summary>
/// Settings service interface.
/// </summary>
public interface ISettingsService
{
    #region Interface Members
    ISettings? Settings { get; set; }//KeDi

    /// <summary>
    /// Read settings.
    /// </summary>
    /// <param name="jsonPath">Json path</param>
    /// <returns></returns>
    
    //ISettings? Read(string jsonPath);//KeDi
    bool Read(string jsonPath);//KeDi


    /// <summary>
    /// Write settings.
    /// </summary>
    /// <param name="jsonPath">Json path</param>

    //void Write(ISettings settings, string jsonPath);//KeDi
    bool Write(string jsonPath);//KeDi
    

    #endregion // Interface Members
}
