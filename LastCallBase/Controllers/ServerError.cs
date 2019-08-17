using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LastCallBase.Controllers
{
    public class ServerError
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorDescription { get; set; }
        public string StatusMessage { get; set; }

        public ServerError()
        {
            ErrorCode = 0;
            ErrorMessage = "";
            ErrorDescription = "";
            StatusMessage = "";
        }
    }
}
