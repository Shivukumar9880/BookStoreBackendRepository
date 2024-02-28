using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.ModelResponse
{
    public class AddressResponse
    {
        public string fullAddress { get; set; }
        public string city { get; set; }
        public string state { get; set; }

        public int type { get; set; }  
        
        public int id { get; set; }
    }
}
