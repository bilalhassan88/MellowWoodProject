using Abp.Authorization;
using MellowWoodProject.Authorization.Roles;
using MellowWoodProject.Authorization.Users;

namespace MellowWoodProject.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
