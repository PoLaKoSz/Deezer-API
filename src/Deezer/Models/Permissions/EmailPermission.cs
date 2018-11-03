using System;

namespace PoLaKoSz.Deezer.Models.Permissions
{
    /// <summary>
    /// Get the user's email
    /// </summary>
    public class EmailPermission : Permission, IPermission
    {
        public EmailPermission()
            : base("email")
        {

        }
    }
}
