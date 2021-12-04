using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover_Hepsiburada
{
    public class Plateau
    {
        public int width{ get; set; }
        public int height { get; set; }
        public int minWidth { get; set; }  
        public int minHeight { get; set; }

        public void DefinePlateauSize(string[] maxPoints)
        {
            width = int.Parse(maxPoints[0]); 
            height = int.Parse(maxPoints[1]);
            minWidth = 0;
            minHeight = 0;
        }
    }
}
