using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDVXRIPPER
{
    public enum TaggingStyle
    {
        Original = 0,
        Yomigana = 1
    }

    public class RipperConfiguration
    {
        public TaggingStyle artistTagging;
        public TaggingStyle titleTagging;
        public NAudio.Lame.LAMEPreset lamePreset;
        public string sourceDir = null;
        public string targetDir = null;
    }
}
