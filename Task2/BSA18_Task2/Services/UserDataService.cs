using System;
using System.Collections.Generic;
using System.Linq;
using Core;
using Core.Entities;
using Core.Helpers;

namespace BSA18_Task2.Services
{
    public class UserDataService
    {
        private static readonly Client userDataClient;
        private static readonly Lazy<UserDataService> instance;

        public static UserDataService Instance => instance.Value;
        static UserDataService()
        {
            instance = new Lazy<UserDataService>(() => new UserDataService());
            userDataClient = Client.Instance;
            userDataClient.InitializeUsers();
        }

        UserDataService()
        {

        }

        #region Users

        public IEnumerable<User> GetAllUsers()
        {
            return userDataClient.Users;
        }

        public IEnumerable<User> GetOrderedUserList()
        {
            return userDataClient.GetOrderedUserList();
        }

        public UserInfo GetUserInfo(int userId)
        {
            return userDataClient.GetUserInfo(userId);
        }

        public User GetUser(int userId)
        {
            return userDataClient.Users?.Find(u => u.Id == userId);
        }

        #endregion

        #region Comments

        public IEnumerable<Comment> GetCommentsList(int userId)
        {
            return userDataClient.GetCommentsList(userId);
        }

        public IEnumerable<Comment> GetUserCommentsList(int userId)
        {
            return userDataClient.Users.Find(user => user.Id == userId)?.Comments;
        }

        public Dictionary<Post, int> GetCommentsCount(int userId)
        {
            return userDataClient.GetCommentsCount(userId);
        }

        #endregion

        #region Posts

        public PostInfo GetPostInfo(int postId)
        {
            return userDataClient.GetPostInfo(postId);
        }
        
        public IEnumerable<Post> GetUserPostsList(int userId)
        {
            return userDataClient.Users.Find(user => user.Id == userId)?.Posts;
        }

        public Post GetPost(int postId)
        {
            Post result = null;
            foreach (var user in userDataClient.Users)
            {
                result = user.Posts.FirstOrDefault(p => p.Id == postId);
                if (result != null)
                    break;
            }
            return result;
        }
        #endregion

        #region Todos

#warning реализовать getAllTodos

        public IEnumerable<Todo> GetAllTodos()
        {
           return null;
        }

        public IEnumerable<Todo> GetUserTodos(int userId)
        {
            return userDataClient.Users.Find(user => user.Id == userId)?.Todos;
        }

        public Dictionary<int, string> GetCompletedUserTodos(int userId)
        {
            return userDataClient.GetTodos(userId);
        }

        #endregion



    }
}