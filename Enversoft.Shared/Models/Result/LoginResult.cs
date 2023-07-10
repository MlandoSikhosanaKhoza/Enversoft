using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enversoft.Shared { 
    public class LoginResult
    {
        public bool IsAuthorized { get; set; }

        public string JwtToken { get; set; }
    }
}
