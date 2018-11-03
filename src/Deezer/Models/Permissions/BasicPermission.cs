using System;

namespace PoLaKoSz.Deezer.Models.Permissions
{
    /// <summary>
    /// Access users basic information including name, firstname, profile picture only
    /// </summary>
    public class BasicPermission : Permission, IPermission
    {
        public BasicPermission()
            : base("basic_access")
        {

        }
    }
}
