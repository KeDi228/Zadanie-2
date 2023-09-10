using SampleHierarchies.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.Services.Tests
{
    public class ScreenLineEntry : IScreenLineEntry
    {   

        #region Implementation

        public ConsoleColor BackgroundColor { get; set; }
        public ConsoleColor ForegroundColor { get; set; }
        public String Text { get; set; }

        #endregion //Implenetation



        #region Ctor and properties

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="backgroundColor">Name</param>
        /// <param name="foregroundColor">Name</param>
        /// <param name="text">Breed</param>
        /// 
        public ScreenLineEntry(ConsoleColor backgroundColor, ConsoleColor foregroundColor, string text)
        {
            BackgroundColor = backgroundColor;
            ForegroundColor = foregroundColor;
            Text = text;
        }

        #endregion //Ctor and properties
    }


}
