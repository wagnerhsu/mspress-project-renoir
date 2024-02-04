///////////////////////////////////////////////////////////////////
//
// Project RENOIR
// Release Notes Instant Reporter
//
// Reference application presented in
// Clean Architecture with .NET (MS Press) 2024
// Author: Dino Esposito
// 
//

using System.ComponentModel.DataAnnotations;
using Youbiquitous.Martlet.Core.Extensions;

namespace Youbiquitous.Renoir.DomainModel.Management;

/// <summary>
/// USER entity (properties)
/// </summary>
public partial class User : BaseEntity
{
    /// <summary>
    /// Mostly needed for EF and to save us an entire layer of DTOs
    /// </summary>
    public User()
    {
        RoleId = Role.Viewer.Name;
    }

    /// <summary>
    /// Helper ctor
    /// </summary>
    /// <param name="email"></param>
    /// <param name="hashedPassword"></param>
    /// <param name="role"></param>
    public User(string email, string hashedPassword, string role = null)
    {
        Email = email;
        RoleId = role;
        Password = hashedPassword;
    }

    /// <summary>
    /// Helper ctor
    /// </summary>
    /// <param name="id"></param>
    /// <param name="email"></param>
    /// <param name="role"></param>
    /// <param name="name"></param>
    public User(long id, string email, string role = Role.NameOf_Viewer, string name = null)
    {
        UserId = id;
        Email = email;
        RoleId = role;
        DisplayName = name.IsNullOrWhitespace() ? email : name;
    }

    /// <summary>
    /// Unique ID (autogenerated)
    /// </summary>
    public long UserId { get; set; }

    /// <summary>
    /// Email (used as key)
    /// </summary>
    [MaxLength(100)]
    public string Email { get; set; }

    /// <summary>
    /// Hashed password
    /// </summary>
    [MaxLength(1500)]
    public string Password { get; set; }

    /// <summary>
    /// Role of the account (expressed as a constant string)
    /// </summary>
    [MaxLength(50)]
    public string RoleId { get; set; }

    /// <summary>
    /// Personal display name (overriding email for display)
    /// </summary>
    [MaxLength(100)]
    public string DisplayName { get; set; }

    /// <summary>
    /// Date of signup
    /// </summary>
    public DateTime? SignedUp { get; set; }

    /// <summary>
    /// Date of admin approval of application
    /// </summary>
    public DateTime? Approved { get; set; }

    /// <summary>
    /// Whether the account is locked down
    /// </summary>
    public bool Locked { get; set; }

    /// <summary>
    /// Picture representative of the user
    /// </summary>
    public byte[] Photo { get; set; }

    /// <summary>
    /// Products the user can work on 
    /// </summary>
    public virtual IEnumerable<UserProductBinding> Products { get; set; }
}
