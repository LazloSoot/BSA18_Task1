using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Core;

namespace Tests
{
    [TestFixture]
    public class MethodsTest
    {
        private static readonly Client client = new Client();

        [Test]
        public void GetCommentsCountTest()
        {
            var result = client.GetCommentsCount(0);
            Assert.NotNull(result);
        }

        [Test]
        public void GetCommentsListTest()
        {
            var result = client.GetCommentsList(0);
            Assert.NotNull(result);
        }

        [Test]
        public void GetTodosTest()
        {
            var result = client.GetTodos(0);
            Assert.NotNull(result);
        }


        [Test]
        public void GetUserListTest()
        {
            var result = client.GetUserList();
            Assert.NotNull(result);
        }

        [Test]
        public void GetUserInfoTest()
        {
            var result = client.GetUserInfo(0);
            Assert.NotNull(result);
        }

       
        public void GetPostInfoTest()
        {
            var result = client.GetPostInfo(0);
            Assert.NotNull(result);
        }
    }
}
