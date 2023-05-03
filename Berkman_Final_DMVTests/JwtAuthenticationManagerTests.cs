using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Berkman_Final_DMV.Controllers;
using Azure.Identity;
using Berkman_Final_DMV;

namespace Berkman_Final_DMV.Tests
{
    [TestClass()]
    public class JwtAuthenticationManagerTests
    {
        [TestMethod()]
        public void AuthenticateTest()
        {
            JwtAuthenticationManager manager = new JwtAuthenticationManager("fakekeynotlegit1111!");

            User user = new User
            {
                username = "testusername",
                password = "testpassword!!!"
            };

            var ret = manager.Authenticate(user.username, user.password);

            Assert.IsNull(ret);
        }
    }
}