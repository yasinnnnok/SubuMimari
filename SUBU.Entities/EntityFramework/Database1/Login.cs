using SUBU.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUBU.Entities.EntityFramework.Database1
{
    public class Login:EntityBase<int>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
