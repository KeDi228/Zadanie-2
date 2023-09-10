using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleHierarchies.Interfaces.Data;

namespace SampleHierarchies.Interfaces.Services
{
    public interface IScreenDefinitionService
    {
        #region Interface Members

        /// <summary>
        /// Load definitions.
        /// </summary>
        /// <param name="jsonFileName">Json path</param>
        /// <returns></returns>
        //ScreenDefinition Load(string jsonFileName);

        /// <summary>
        /// Save definitions.
        /// </summary>
        /// <param name="jsonFileName">Json path</param>
        /// <returns></returns>
        //bool Save(ScreenDefinition screenDefinition, string jsonFileName);

        #endregion // Interface Members
    }
}
