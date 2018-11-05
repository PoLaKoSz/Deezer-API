using PoLaKoSz.Deezer.Models.Permissions;
using System;
using System.Collections.Generic;

namespace PoLaKoSz.Deezer
{
    public class ClientSideLogin
    {
        public readonly int AppID;
        public readonly Uri RedirectUri;
        public List<IPermission> GrantedPermissions;
        public readonly string AccessToken;



        public ClientSideLogin(string accessToken, List<IPermission> permissions)
            : this(0, new Uri("https://github.com/PoLaKoSz/Deezer-API"), accessToken, permissions) { }

        public ClientSideLogin(int appID, Uri redirectUri)
            : this(appID, redirectUri, "", new List<IPermission>()) { }

        public ClientSideLogin(int appID, Uri redirectUri, string accessToken, List<IPermission> permissions)
        {
            AppID = appID;
            RedirectUri = redirectUri;
            GrantedPermissions = grantedPermissions;
            AccessToken = accessToken;
        }
    }
}
