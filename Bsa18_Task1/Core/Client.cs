using Core.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Client
    {
        public Client()
        {
                
        }

        /// <summary>
        /// Получить количество комментов под постами конкретного пользователя(по айди) (список из пост-количество)
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Dictionary<Post, int> GetCommentsCount(int userId)
        {
            return null;
        }

        /// <summary>
        ///  Получить список комментов под постами конкретного пользователя(по айди), где body коммента < 50 символов (список из комментов)
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<Comment> GetCommentsList(int userId)
        {
            return null;
        }

        /// <summary>
        /// Получить список(id, name) из списка todos которые выполнены для конкретного пользователя(по айди)
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Dictionary<int, string> GetTodos(int userId)
        {
            return null;
        }


        /// <summary>
        /// Получить список пользователей по алфавиту(по возрастанию) с отсортированными todo items по длине name(по убыванию)
        /// </summary>
        /// <returns></returns>
        public IEnumerable<User> GetUserList()
        {
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
