using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheatreSeatAllocationTest
{
   public  interface  ITheater
    {
        string AllocateSeats(int numSeats);
    }
}
