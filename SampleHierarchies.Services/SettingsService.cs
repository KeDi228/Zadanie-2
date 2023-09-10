using Newtonsoft.Json;
using SampleHierarchies.Data;
using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Services;
using System.Diagnostics;

namespace SampleHierarchies.Services;

/// <summary>
/// Settings service.
/// </summary>
public class SettingsService : ISettingsService
{
    #region ISettings Implementation

    /// <inheritdoc/>
    public ISettings? Settings { get; set; }//kev

    public bool Read(string jsonPath)//kev
    {

        bool result = true;
        try
        {
            string jsonContent = File.ReadAllText(jsonPath);
            var jsonSettings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Objects
            };
            Settings = JsonConvert.DeserializeObject<Settings>(jsonContent, jsonSettings);
            //List<test> myDeserializedObjList = (List<test>)Newtonsoft.Json.JsonConvert.DeserializeObject(Request["jsonString"], typeof(List<test>));
            if (Settings is null)
            {
                result = false;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            result = false;
        }
        return result;

    }

    /// <inheritdoc/>

    public bool Write(string jsonPath)
    {
        bool result = true;
        try
        {
            var jsonSettings = new JsonSerializerSettings();
            string jsonContent = JsonConvert.SerializeObject(Settings);
            string jsonContentFormatted = jsonContent.FormatJson();
            File.WriteAllText(jsonPath, jsonContentFormatted);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            result = false;
        }
        return result;

    }
    #endregion // ISettings Implementation
    /// <summary>
    /// Default ctor.
    /// </summary>
    public SettingsService()
    {
        Settings = new Settings();
    }

}