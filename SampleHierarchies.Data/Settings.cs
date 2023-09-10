using SampleHierarchies.Interfaces.Data;//kev
using SampleHierarchies.Enums;//kev
using SampleHierarchies.Interfaces.Data.Mammals;
using System.Xml.Linq;

namespace SampleHierarchies.Data
{
    //internal class Settings// comm kev
    //kev-->
    public class Settings : ISettings
    {
        public List<ISettings> Setting { get; set; }

        public void Display(int screenNum)
        {
            var screenName = (ColorScreenChoices)screenNum;
            Console.WriteLine($"{screenName} screen: Foreground color is {MainTextColor}, background color is {MainBackgroundColor}");
        }

        #region Ctors And Properties
        public string Version { get; set; }
        public int ScreenNumber { get; set; }
        public ConsoleColor MainTextColor { get; set; }
        public ConsoleColor MainBackgroundColor { get; set; }
        

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="screenNum">Name</param>
        /// <param name="text">Name</param>
        /// <param name="background">Breed</param>
        /// 
        public Settings(int screenNum, ConsoleColor text, ConsoleColor background)
        {
            ScreenNumber = screenNum;
            MainTextColor = text;
            MainBackgroundColor = background;
        }

        public Settings()
        {
            Setting = new List<ISettings>();
        }

        #endregion //Ctors And Properties
    }



    //<--kev
}
