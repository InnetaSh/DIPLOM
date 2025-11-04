using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globals.Models
{
    public class RefBase<T> : EntityBase where T : EntityBase
    {
        public int RefID { get; set; }
        public T Parent { get; set; }
    }
}
