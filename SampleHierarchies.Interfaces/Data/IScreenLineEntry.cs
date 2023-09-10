using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.Interfaces.Data
{
    public interface IScreenLineEntry // KeDi
    {
        ConsoleColor BackgroundColor { get; set; }
        ConsoleColor ForegroundColor { get; set; }
        String Text { get; set; }
    }
}
