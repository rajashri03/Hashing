using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hashing
{
    public class HashMap
    {
        public string Key { get; set; }
        public int Value { get; set; }
        public HashMap Next { get; set; }
        public HashMap Previous { get; set; }
    }
}
