using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SDVXRIPPER
{
    class WorkerConfiguration
    {
        public readonly RipperConfiguration configuration;
        public readonly List<string> trackPaths;
        public readonly XDocument musicDb;

        public WorkerConfiguration(RipperConfiguration config, List<string> tracks, XDocument db)
        {
            configuration = config;
            trackPaths = tracks;
            musicDb = db;
        }
    }
}
