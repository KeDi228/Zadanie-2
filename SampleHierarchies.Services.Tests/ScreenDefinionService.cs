using Newtonsoft.Json;
using SampleHierarchies.Data;
using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.Services.Tests
{
    public static class ScreenDefinionService
    {
        public static bool Load(string jsonFileName)
        {
            bool result = true;            

            try
            {
                string jsonContent = File.ReadAllText(jsonFileName);
                var jsonSettings = new JsonSerializerSettings()
                {
                    TypeNameHandling = TypeNameHandling.Objects
                };

                List<ScreenLineEntry> LineEntries = JsonConvert.DeserializeObject<List<ScreenLineEntry>>(jsonContent, jsonSettings);
                if (LineEntries != null)
                {
                    foreach (var _screenLineEntry in LineEntries)
                    {
                        Console.WriteLine(_screenLineEntry.Text
                                          ,Console.BackgroundColor = _screenLineEntry.BackgroundColor,
                                          Console.ForegroundColor = _screenLineEntry.ForegroundColor
                                         );
                    }
                }
                else
                {
                    result = false;
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            return result;
        }


        public static bool Save(ScreenDefinition screenDefinition, string jsonFileName)
        {
            bool result = true;
            try
            {
                var jsonSettings = new JsonSerializerSettings();
                string jsonContent = JsonConvert.SerializeObject(screenDefinition);
                string jsonContentFormatted = jsonContent.FormatJson();
                File.WriteAllText(jsonFileName, jsonContentFormatted);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                result = false;
            }
            return result;
        }
    }
}
