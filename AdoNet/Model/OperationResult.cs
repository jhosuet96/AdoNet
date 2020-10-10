using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNet
{
   public class OperationResult
    {
        public bool Result { get; set; }
        public string Message { get; set; }

        public object Data { get; set; }

    }
}
