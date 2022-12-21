﻿using SUBU.Shared;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.UISample.Models
{

    public class UserQuery
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public EnumUsersRole EnumRole { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime? UpdateDate { get; set; }
        public string CreateUserName { get; set; }

        public string? UpdateUserName { get; set; }
        public bool Status { get; set; }
    }

    public class UserCreate
    {
        [Required]
       // [StringLength(50,ErrorMessage ="En fazla 50 karakter girebilirsiniz. ")]
        public string UserName { get; set; }
        public EnumUsersRole EnumRole { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime? UpdateDate { get; set; }
        public string? CreateUserName { get; set; }

        public string? UpdateUserName { get; set; }
        public bool Status { get; set; }
    }

}
