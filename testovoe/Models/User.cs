using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using testovoe.Data.Entities;

namespace testovoe.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public virtual Film Film { get; set; }
    }
}
