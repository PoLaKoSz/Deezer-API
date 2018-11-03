using System;

namespace PoLaKoSz.Deezer.Models.Permissions
{
    /// <summary>
    /// Access user data any time.
    /// </summary>
    public class OfflinePermission : Permission, IPermission
    {
        public OfflinePermission()
            : base("offline_access")
        {

        }
    }
}
