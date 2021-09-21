using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace cSharp_FileBrowser
{
    class BrowserItem
    {
        public string Name { get; set; }
        public  DateTime DateModified { get; set; }
        public  FileAttributes Type { get; set; }
        public string FullName { get; set; }
    }
}
