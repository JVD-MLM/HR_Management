using HR_Management.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace HR_Management.Identity
{
    public class MyIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
    }
}
