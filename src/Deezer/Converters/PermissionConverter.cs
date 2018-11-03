using PoLaKoSz.Deezer.Models.Permissions;
using System.Collections.Generic;
using System.Linq;

namespace PoLaKoSz.Deezer.Converters
{
    public static class PermissionConverter
    {
        public static string Convert(List<IPermission> permissions)
        {
            return string.Join(",", permissions.Select(p => p.Name));
        }
    }
}
