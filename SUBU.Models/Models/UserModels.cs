using System.ComponentModel.DataAnnotations;

namespace SUBU.Models;

public class UserCreate
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

public class UserUpdate
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


public class UserRoleCreate
{
    public string UserName { get; set; }
    public EnumUsersRole EnumRole { get; set; }
}