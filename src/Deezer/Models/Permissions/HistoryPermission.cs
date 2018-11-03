using System;

namespace PoLaKoSz.Deezer.Models.Permissions
{
    /// <summary>
    /// Allow the application to access the user's listening history.
    /// </summary>
    public class HistoryPermission : Permission, IPermission
    {
        public HistoryPermission()
            : base("listening_history")
        {

        }
    }
}
