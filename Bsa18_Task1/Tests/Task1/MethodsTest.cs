using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Core;
using Core.Entities;
using System.Net;
using Core.Types;
using Newtonsoft.Json;

namespace Tests.Task1
{
    [TestFixture]
    public class MethodsTest
    {
        private static readonly Client client = Client.Instance;
        private static readonly Uri baseUri = new Uri(@"https://5b128555d50a5c0014ef1204.mockapi.io/");
        private static IEnumerable<User> users = LoadData<User>(Endpoint.users);
        private static IEnumerable<Post> posts = LoadData<Post>(Endpoint.posts);
        private static IEnumerable<Comment> comments = LoadData<Comment>(Endpoint.comments);
        private static IEnumerable<Todo> todos = LoadData<Todo>(Endpoint.todos);
        private const int targetUserId = 21;

        [Test]
        public void GetCommentsCountTest()
        {
            Dictionary<Post, int> result = client.GetCommentsCount(targetUserId);
            Assert.NotNull(result);

            List<Post> expectedPosts = posts.Where(post => post.UserId == targetUserId).ToList();
            int expectedCommentsCount = 0;

            
            foreach (var post in expectedPosts)
            {
                Assert.IsTrue(result.ContainsKey(post));
                expectedCommentsCount = comments
                    .Select(c => c)
                    .Where(c => c.PostId == post.Id)
                    .Count();

                Assert.AreEqual(expectedCommentsCount, result[post]);
            }
        }

        [Test]
        public void GetCommentsListTest()
        {
            IEnumerable<Comment> result = client.GetCommentsList(targetUserId);
            Assert.NotNull(result);

            List<Post> targetPosts = posts.Where(post => post.UserId == targetUserId).ToList();
            List<Comment> expectedComments = null;
            int totalCommentsCount = 0;

            foreach (var post in targetPosts)
            {
                expectedComments = comments.Where(c => c.PostId == post.Id).ToList();
                totalCommentsCount += expectedComments.Count();

                foreach (var comment in expectedComments)
                {
                    result.Contains(comment);
                }
            }

            Assert.AreEqual(totalCommentsCount, result.Count());
        }

        [Test]
        public void GetTodosTest()
        {
            Dictionary<int, string> result = client.GetTodos(targetUserId);
            Assert.NotNull(result);

            List<Todo> expectedTodos = todos.Where(t => t.UserId == targetUserId && t.IsComplete).ToList();
            Assert.AreEqual(expectedTodos.Count, result.Count);

            foreach (var todo in expectedTodos)
            {
                Assert.IsTrue(result.ContainsKey(todo.Id));
                Assert.IsTrue(todo.IsComplete);
                Assert.IsTrue(String.Equals(result[todo.Id], todo.Name));
            }
        }


        [Test]
        public void GetOrderedUserListTest()
        {
            List<User> result = client.GetOrderedUserList().ToList();
            Assert.NotNull(result);

            List<User> expectedUsers = users.OrderBy(user => user.Name).ToList();
            Assert.AreEqual(expectedUsers.Count, result.Count);

            List<Todo> expectedTodods = null;
            for (int i = 0; i < expectedUsers.Count; i++)
            {
                Assert.AreEqual(expectedUsers[i], result[i]);
                expectedTodods = todos.Where(t => t.UserId == result[i].Id).OrderBy(todo => todo.Name.Length).ToList();
                Assert.AreEqual(expectedTodods.Count, result[i].Todos.Count);

                for (int j = 0; j < expectedTodods.Count; j++)
                {
                    Assert.AreEqual(expectedTodods[j], result[i].Todos[j]);
                }
            }
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

        static IEnumerable<T> LoadData<T>(Endpoint endpoint) where T : class, new()
        {
            var jsonData = string.Empty;
            using (var wClient = new WebClient())
            {

                try
                {
                    jsonData = wClient.DownloadString(new Uri(baseUri, endpoint.ToString()));
                    if (String.IsNullOrEmpty(jsonData))
                        throw new ArgumentNullException("");

                }
                catch (Exception)
                {

                }
            }

            return JsonConvert.DeserializeObject<IEnumerable<T>>(jsonData) ?? null;
        }
    }
}
