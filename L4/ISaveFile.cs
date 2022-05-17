using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L4
{
    public interface ISaveFile
    {
        List<string> Get_String(List<Schedule> items);
        void Save_File(List<Schedule> items);
    }
}
