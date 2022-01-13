using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.Core.Authentication
{
    public class JWT
    {
        public string Token { get; set; }
        public DateTime ValidTo { get; set; }
    }
}
