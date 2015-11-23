using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlManager.Data
{
    class Directories
    {
        public static readonly string CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        public static readonly string ConfigFilePath = Path.Combine(CurrentDirectory, "config.xml");
    }
}
