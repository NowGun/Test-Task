using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace testovoe.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            Films = new HashSet<Film>();
        }

        public string Name { get; set; }
        public string Surname { get; set; }

        public virtual ICollection<Film> Films { get; set; }
    }
}
