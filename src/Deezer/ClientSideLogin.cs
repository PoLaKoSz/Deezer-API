using PoLaKoSz.Deezer.Models.Permissions;
using System;
using System.Collections.Generic;

namespace PoLaKoSz.Deezer
{
    public class ClientSideLogin
    {
        public readonly int AppID;
        public readonly Uri RedirectUri;
        public readonly List<IPermission> GrantedPermissions;
        public readonly string AccessToken;



        /// <summary>
        /// This constructor only useful when the User already accepted Your APP
        /// to access his/her data with offline_access permission
        /// </summary>
        /// <param name="accessToken">Access token given from the Deezer server at
        /// the end of the Authorization process</param>
        public ClientSideLogin(string accessToken)
            : this(0, new Uri("https://github.com/PoLaKoSz/Deezer-API"), accessToken, new List<IPermission>() { new OfflinePermission()}) { }

        private ClientSideLogin(int appID, Uri redirectUri)
            : this(appID, redirectUri, "", new List<IPermission>()) { }

        private ClientSideLogin(int appID, Uri redirectUri, string accessToken, List<IPermission> grantedPermissions)
        {
            AppID = appID;
            RedirectUri = redirectUri;
            GrantedPermissions = grantedPermissions;
            AccessToken = accessToken;
        }
    }
}
