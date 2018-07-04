using Core.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using Core.Types;

namespace Core
{
    public class Client
    {
        private List<User> users;
        //private List<Adress> adresses;
        private static readonly Lazy<Client> instance;
        private static readonly Uri baseUri;

        public static Client Instance => instance.Value;

        static Client()
        {
            instance = new Lazy<Client>(() => new Client());
            baseUri = new Uri(@"https://5b128555d50a5c0014ef1204.mockapi.io/");
        }

        private Client()
        {
            InitializeUsers();
        }

        public void InitializeUsers()
        {
            IEnumerable<User> usersTemp = LoadData<User>(Endpoint.users);
            IEnumerable<Post> postsTemp = LoadData<Post>(Endpoint.posts);
            IEnumerable<Comment> commentsTemp = LoadData<Comment>(Endpoint.comments);
            IEnumerable<Todo> todosTemp = LoadData<Todo>(Endpoint.todos);

            users = usersTemp.GroupJoin(postsTemp, user => user.Id, post => post.UserId,
                (user, posts) => new User()
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    CreatedAt = user.CreatedAt,
                    Avatar = user.Avatar,
                    Posts = posts.GroupJoin(commentsTemp, post => post.Id, comment => comment.PostId,
                                (post, comments) => new Post()
                                {
                                    Id = post.Id,
                                    Likes = post.Likes,
                                    Title = post.Title,
                                    Body = post.Body,
                                    CreatedAt = post.CreatedAt,
                                    UserId = post.UserId,
                                    Comments = comments
                                                //.Where(c => c.UserId == user.Id)
                                                .ToList()
                                })
                                .ToList()
                }
            ).GroupJoin(todosTemp, user => user.Id, todo => todo.UserId,
                (user, todos) => new User()
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    CreatedAt = user.CreatedAt,
                    Avatar = user.Avatar,
                    Posts = user.Posts,
                    Todos = todos.ToList()
                }
                ).ToList();
        }

        IEnumerable<T> LoadData<T>(Endpoint endpoint) where T : class, new()
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

        /// <summary>
        /// Получить количество комментов под постами конкретного пользователя(по айди) (список из пост-количество)
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Dictionary<Post, int> GetCommentsCount(int userId)
        {
            return users.FirstOrDefault(user => user.Id == userId)
                                                .Posts
                                                .Select(post => 
                                                new KeyValuePair<Post, int>(post, post.Comments.Count())
                                                )
                                                .ToDictionary(post => post.Key, commentsCount => commentsCount.Value);
        }

        /// <summary>
        ///  Получить список комментов под постами конкретного пользователя(по айди), где body коммента < 50 символов (список из комментов)
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<Comment> GetCommentsList(int userId)
        {
            return users.FirstOrDefault(user => user.Id == userId)
                                    .Posts
                                    .SelectMany(post => post.Comments
                                                        .Where(comment => comment.Body.Length < 50));
        }

        /// <summary>
        /// Получить список(id, name) из списка todos которые выполнены для конкретного пользователя(по айди)
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Dictionary<int, string> GetTodos(int userId)
        {
            return users.FirstOrDefault(user => user.Id == userId)
                .Todos
                .Select(todo =>
                new KeyValuePair<int, string>(todo.Id, todo.Name)
                )
                .ToDictionary(id => id.Key, name => name.Value);
        }


        /// <summary>
        /// Получить список пользователей по алфавиту(по возрастанию) с отсортированными todo items по длине name(по убыванию)
        /// </summary>
        /// <returns></returns>
        public IEnumerable<User> GetUserList()
        {
           // var a = users.Select(user => user.Todos.OrderBy(todo => todo.Name.Max()))
            return null;
        }

        //        Получить следующую структуру(передать Id пользователя в параметры)

        //User

        //Последний пост пользователя(по дате)

        //Количество комментов под последним постом

        //Количество невыполненных тасков для пользователя

        //Самый популярный пост пользователя(там где больше всего комментов с длиной текста больше 80 символов)

        //Самый популярный пост пользователя(там где больше всего лайков)
        public object GetUserInfo(int userId)
        {
            //return users.Select(user => user.)
            return null;
        }

        //        Получить следующую структуру(передать Id поста в параметры)

        //Пост

        //Самый длинный коммент поста

        //Самый залайканный коммент поста

        //Количество комментов под постом где или 0 лайков или длина текста< 80
        public object GetPostInfo(int userId)
        {
            return null;
        }



    }
}
