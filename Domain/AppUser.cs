using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthQues.Domain
{
    public class AppUser:IdentityUser
    {
        public string DisplayName { get; set; }
        public string CreatedById { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [ForeignKey("CreatedById")]
        public AppUser CreatedBy { get; set; }
    }
}
