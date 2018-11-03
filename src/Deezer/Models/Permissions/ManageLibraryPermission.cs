using System;

namespace PoLaKoSz.Deezer.Models.Permissions
{
    /// <summary>
    /// Manage users' library. Add/rename a playlist. Add/order songs in the playlist.
    /// </summary>
    public class ManageLibraryPermission : Permission, IPermission
    {
        public ManageLibraryPermission()
            : base("manage_library")
        {

        }
    }
}
