using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS
{
    internal class Record
    {
        // Assign a random GUID
        public Guid ClientID { get; private set; } = Guid.NewGuid();
    }
}
