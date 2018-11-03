using System;

namespace PoLaKoSz.Deezer.Models.Permissions
{
    /// <summary>
    /// Manage users' friends. Add/remove a following/follower.
    /// </summary>
    public class CommunityPermission : Permission, IPermission
    {
        public CommunityPermission()
            : base("manage_community")
        {

        }
    }
}
