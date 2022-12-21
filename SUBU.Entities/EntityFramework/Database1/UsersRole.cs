using SUBU.Entities.Base;
using SUBU.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUBU.Entities.EntityFramework.Database1
{
    public class UsersRole : EntityBase<int>
    {
        [Required]
        public string UserName { get; set; }
        public EnumUsersRole EnumRole { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime? UpdateDate { get; set; }
        public string CreateUserName { get; set; }

        public string? UpdateUserName { get; set; }
        public bool Status { get; set; }
    }

}
