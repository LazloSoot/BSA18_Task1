using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Core;
using Core.Entities;
using System.Net;
using Core.Types;
using Newtonsoft.Json;
using Core.Helpers;

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
        private const int targetUserId = 97;
        private const int maxIdValue = 100;
        private const int minIdValue = 1;

        [Test]
        public void GetCommentsCountTest()
        {
            Dictionary<Post, int> currentResult;

            for (int currentUserId = minIdValue; currentUserId <= maxIdValue; currentUserId++)
            {
                currentResult = client.GetCommentsCount(currentUserId);
                Assert.NotNull(currentResult);

                List<Post> expectedPosts = posts.Where(post => post.UserId == currentUserId).ToList();
                int expectedCommentsCount = 0;


                foreach (var post in expectedPosts)
                {
                    Assert.IsTrue(currentResult.ContainsKey(post));
                    expectedCommentsCount = comments
                        .Select(c => c)
                        .Where(c => c.PostId == post.Id)
                        .Count();

                    Assert.AreEqual(expectedCommentsCount, currentResult[post]);
                }
            }
        }

        [Test]
        public void GetCommentsListTest()
        {
            List<Comment> currentResult;

            for (int currentUserId = minIdValue; currentUserId <= maxIdValue; currentUserId++)
            {
                currentResult = client.GetCommentsList(currentUserId).ToList();
                Assert.NotNull(currentResult);

                List<Post> targetPosts = posts.Where(post => post.UserId == currentUserId).ToList();
                List<Comment> expectedComments = null;
                int totalCommentsCount = 0;

                foreach (var post in targetPosts)
                {
                    expectedComments = comments.Where(c => c.PostId == post.Id && c.Body.Length < 50).ToList();
                    totalCommentsCount += expectedComments.Count();

                    foreach (var comment in expectedComments)
                    {
                        Assert.IsTrue(currentResult.Contains(comment));
                    }
                }

                Assert.AreEqual(totalCommentsCount, currentResult.Count());
            }
        }

        [Test]
        public void GetTodosTest()
        {
            for (int currentUserId = minIdValue; currentUserId <= maxIdValue; currentUserId++)
            {
                Dictionary<int, string> result = client.GetTodos(currentUserId);
                Assert.NotNull(result);

                List<Todo> expectedTodos = todos.Where(t => t.UserId == currentUserId && t.IsComplete).ToList();
                Assert.AreEqual(expectedTodos.Count, result.Count);

                foreach (var todo in expectedTodos)
                {
                    Assert.IsTrue(result.ContainsKey(todo.Id));
                    Assert.IsTrue(todo.IsComplete);
                    Assert.IsTrue(String.Equals(result[todo.Id], todo.Name));
                }
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
            UserInfo currentResult;
            for (int currentUserId = minIdValue; currentUserId <= maxIdValue; currentUserId++)
            {
                currentResult = client.GetUserInfo(currentUserId);
                Assert.NotNull(currentResult);

                User expectedUser = users
                    .FirstOrDefault(u => u.Id == currentUserId);
                Assert.AreEqual(expectedUser, currentResult.User);

                Post expectedLastPost = posts
                    .Where(p => p.UserId == currentUserId)
                    .OrderByDescending(p => p.CreatedAt)
                    .FirstOrDefault();
                var lastPos = currentResult.LastPost ?? null;
                Assert.AreEqual(expectedLastPost?.CreatedAt, lastPos?.CreatedAt);

                if(expectedLastPost != null)
                {
                    int expectedLastPostCommentsCount = comments.Where(c => c.PostId == expectedLastPost.Id)
                        .Count();
                    Assert.AreEqual(expectedLastPostCommentsCount, currentResult.LastPostCommentsCount);
                }

                int expectedUnfinishedTasksCount = todos
                    .Where(t => t.UserId == currentUserId && !t.IsComplete)
                    .Count();
                Assert.AreEqual(expectedUnfinishedTasksCount, currentResult.UnfinishedTasksCount);

                //там где больше всего комментов с длиной текста больше 80 символов)
                //  Post expectedMostPopComment = posts.Where(p => p.UserId == currentUserId && p.Id == comments.Where))

                Post expectedBestPost = posts
                    .Where(p => p.UserId == currentUserId && p.Likes == posts.Where(pp => pp.UserId == currentUserId).Max(ppp => ppp.Likes))
                    .FirstOrDefault();
                Assert.AreEqual(expectedBestPost?.Likes, currentResult.BestPost?.Likes);

            }

        }
        
        [Test]
        public void GetPostInfoTest()
        {
            PostInfo currentResult;
            for (int currentPostId = minIdValue; currentPostId <= maxIdValue; currentPostId++)
            {
                currentResult = client.GetPostInfo(currentPostId);
                Assert.NotNull(currentResult);

                Post expectedPost = posts.FirstOrDefault(post => post.Id == currentPostId);
                Assert.AreEqual(expectedPost, currentResult.Post);

                Comment expectedLongestComment = comments
                    .Where(c => c.PostId == currentPostId && c.Body.Length == comments.Where(cc => cc.PostId == currentPostId).Max(cc => cc.Body.Length))
                    .FirstOrDefault();
                Assert.AreEqual(expectedLongestComment?.Body.Length, currentResult.LongestComment?.Body.Length);

                Comment expectedBestComment = comments
                    .Where(c => c.PostId == currentPostId && c.Likes == comments.Where(cc => cc.PostId == currentPostId).Max(cc => cc.Likes))
                    .FirstOrDefault();
                Assert.AreEqual(expectedBestComment?.Likes, currentResult.BestComment?.Likes);

                int expectedCommentsCount = comments
                    .Where(c => c.PostId == currentPostId && (c.Likes == 0 || c.Body.Length < 80))
                    .Count();
                Assert.AreEqual(expectedCommentsCount, currentResult.CommentsCount);
            }
            
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
