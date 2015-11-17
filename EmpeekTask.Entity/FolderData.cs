using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpeekTask.Entity
{
    public class FolderData
    {
        public string Name { get; set; }
        public string FullPath { get; set; }
        public int Level { get; set; }
        public List<FileData> Files { get; set; }
    }
}
