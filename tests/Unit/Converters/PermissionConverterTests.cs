using NUnit.Framework;
using PoLaKoSz.Deezer.Converters;
using PoLaKoSz.Deezer.Models.Permissions;
using System.Collections.Generic;

namespace PoLaKoSz.Deezer.Tests.Unit
{
    public class PermissionConverterTests
    {
        [Test]
        public void Empty_List_Should_Return_Empty_string()
        {
            var input = new List<IPermission>();

            var actual = PermissionConverter.Convert(input);

            Assert.AreEqual("", actual);
        }

        [Test]
        public void Multiple_Permission_Should_Return_Comma_Seperated_String()
        {
            var input = new List<IPermission>()
            {
                new BasicPermission(),
                new CommunityPermission(),
                new DeleteLibraryPermission(),
                new EmailPermission(),
                new HistoryPermission(),
                new ManageLibraryPermission(),
                new OfflinePermission()
            };

            var actual = PermissionConverter.Convert(input);

            Assert.AreEqual("basic_access,manage_community,delete_library,email,listening_history,manage_library,offline_access", actual);
        }
    }
}
