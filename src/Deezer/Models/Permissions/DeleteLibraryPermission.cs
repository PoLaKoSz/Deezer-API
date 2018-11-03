using System;

namespace PoLaKoSz.Deezer.Models.Permissions
{
    /// <summary>
    /// Delete library items. Allow the application to delete items in the user's library.
    /// </summary>
    public class DeleteLibraryPermission : Permission, IPermission
    {
        public DeleteLibraryPermission()
            : base("delete_library")
        {

        }
    }
}
