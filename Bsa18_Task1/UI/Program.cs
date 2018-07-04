using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Core.Entities;

namespace UI
{
    class Program
    {

        #region Настройка окна консоли
        static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);
        static readonly IntPtr HWND_TOP = new IntPtr(0);
        const UInt32 SWP_NOSIZE = 0x0001;
        const UInt32 SWP_NOMOVE = 0x0002;
        const UInt32 SWP_NOZORDER = 0x0004;
        const UInt32 SWP_NOREDRAW = 0x0008;
        const UInt32 SWP_NOACTIVATE = 0x0010;
        const UInt32 SWP_FRAMECHANGED = 0x0020;
        const UInt32 SWP_SHOWWINDOW = 0x0040;
        const UInt32 SWP_HIDEWINDOW = 0x0080;
        const UInt32 SWP_NOCOPYBITS = 0x0100;
        const UInt32 SWP_NOOWNERZORDER = 0x0200;
        const UInt32 SWP_NOSENDCHANGING = 0x0400;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
        #endregion

        private static bool isExit = false;
        private readonly static Client client = Client.Instance;
        private readonly static List<User> users = client.Users;

        static void Main(string[] args)
        {
            IntPtr ConsoleHandle = System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle;
            const UInt32 WINDOW_FLAGS = SWP_SHOWWINDOW;
            SetWindowPos(ConsoleHandle, HWND_NOTOPMOST, 100, 100, 900, 600, WINDOW_FLAGS);
            Console.OutputEncoding = Encoding.GetEncoding(1251);


            Run();
        }

        public static void Run()
        {
            int inputNumber;
            bool inputCorrect;
            while (!isExit)
            {
                inputCorrect = false;
                Console.Clear();
                ShowTask1Menu();

                while (!inputCorrect)
                {
                    int inputId = 0;
                    if (int.TryParse(Console.ReadKey().KeyChar.ToString(), out inputNumber))
                    {
                        switch (inputNumber) // выбираем пункты меню
                        {
                            case 1:

                                Console.Clear();
                                ShowAllHierarhy();
                                inputCorrect = true;
                                break;
                            case 2:
                                Console.Clear();
                                Console.WriteLine("Введите id пользователя : ");
                                if (int.TryParse(Console.ReadLine().ToString(), out inputId) && inputId > 0 )
                                {
                                    Console.Clear();
                                    ShowGetCommentsCount(inputId);
                                }
                                else
                                {
                                    ShowInputError("Ошибка ввода, попробуйте еще раз.");
                                    Console.ReadKey();
                                }
                                inputCorrect = true;
                                break;
                            case 3:
                                Console.Clear();
                                Console.WriteLine("Введите id пользователя : ");
                                if (int.TryParse(Console.ReadLine().ToString(), out inputId) && inputId > 0)
                                {
                                    Console.Clear();
                                    ShowGetCommentsList(inputId);
                                }
                                else
                                {
                                    ShowInputError("Ошибка ввода, попробуйте еще раз.");
                                    Console.ReadKey();
                                }
                                    
                                inputCorrect = true;
                                break;
                            case 4:
                                Console.Clear();
                                Console.WriteLine("Введите id пользователя : ");
                                if (int.TryParse(Console.ReadLine().ToString(), out inputId) && inputId > 0)
                                {
                                    Console.Clear();
                                    ShowGetTodos(inputId);
                                }
                                else
                                {
                                    ShowInputError("Ошибка ввода, попробуйте еще раз.");
                                    Console.ReadKey();
                                }

                                inputCorrect = true;
                                break;
                            case 5:
                                Console.Clear();
                                ShowGetOrderedUserList();

                                inputCorrect = true;
                                break;
                            case 6:
                                Console.Clear();
                                Console.WriteLine("Введите id пользователя : ");
                                if (int.TryParse(Console.ReadLine().ToString(), out inputId) && inputId > 0)
                                {
                                    Console.Clear();
                                    ShowGetUserInfo(inputId);
                                }
                                else
                                {
                                    ShowInputError("Ошибка ввода, попробуйте еще раз.");
                                    Console.ReadKey();
                                }
                                inputCorrect = true;
                                break;
                            case 7:
                                Console.Clear();
                                Console.WriteLine("Введите id пользователя : ");
                                if (int.TryParse(Console.ReadLine().ToString(), out inputId) && inputId > 0)
                                {
                                    Console.Clear();
                                    ShowGetPostInfo(inputId);
                                }
                                else
                                {
                                    ShowInputError("Ошибка ввода, попробуйте еще раз.");
                                    Console.ReadKey();
                                }
                                inputCorrect = true;
                                break;
                            case 8:
                                Console.Write("\t\t    Выход\n\n" +
                                    "  Нажмите N если хотите вернуться и продолжить работу или любую другую\n  клавишу для выхода : ");
                                char inputKey = Console.ReadKey().KeyChar;
                                if (!(inputKey == 'n' || inputKey == 'N'))
                                    isExit = true;
                                inputCorrect = true;
                                break;
                            default:
                                ShowInputError("Введенное число не соответствует ни одному номеру\n  пунктов меню.");
                                break;
                        }
                    }
                    else
                    {
                        ShowInputError("Введено не число, попробуйте еще раз.");
                    }
                }
            }
        }

        public static void ShowMainMenu()
        {
            Console.WriteLine("    BSA 18 Tasks\n\n" +
                    "\t\t1. Task1\n" +
                    "\t\t2. Выйти\n");
            Console.Write("  Введите цифру соответствующую номеру пункта меню : ");
        }

        public static void ShowTask1Menu()
        {
            Console.WriteLine("    Task1 : .NET Data Structures and LINQ\n\n" +
                    "\t1. Показать всю иерархию\n" +
                    "\t2. Вывести количество комментов под постами конкретного пользователя\n" +
                    "\t3. Вывести список комментов под постами конкретного пользователя где body коммента < 50 символов\n" +
                    "\t4. Вывести список(id, name) из списка todos которые выполнены для конкретного пользователя\n" +
                    "\t5. Вывести список пользователей по алфавиту(по возрастанию) с отсортированными todo items по длине name(по убыванию)\n" +
                    "\t6. Вывести структуру из задания 5\n" +
                    "\t7. Вывести структуру из задания 6\n" +
                    "\t8. Выйти\n");
            Console.Write("  Введите цифру соответствующую номеру пункта меню : ");
        }

        public static void ShowAllHierarhy()
        {
            User userTemp;
            Post postTemp;

            foreach (var user in users)
            {
                userTemp = user;
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine(userTemp);
                Console.ResetColor();
                foreach (var post in userTemp.Posts)
                {
                    postTemp = post;
                    Console.WriteLine("   " + postTemp);
                    foreach (var comment in postTemp.Comments)
                    {
                        Console.WriteLine("      " + comment);
                    }
                    Console.WriteLine();
                }
                //Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                foreach (var todo in userTemp.Todos)
                {
                    
                    Console.WriteLine("   " + todo);
                }
                Console.WriteLine();
                Console.ResetColor();
                Console.WriteLine(new string('=', Console.BufferWidth));
            }

            Console.ReadKey();
        }

        public static void ShowGetCommentsCount(int userId)
        {
            var result = client.GetCommentsCount(userId);

            foreach (var item in result)
            {
                Console.WriteLine(item.Key);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Количество комментов : {item.Value}");
                Console.ResetColor();
                Console.WriteLine();
                foreach (var comment in item.Key.Comments)
                {
                    Console.WriteLine(comment);
                }
                Console.WriteLine();
                Console.WriteLine(new string('=', 100));
                Console.WriteLine();
            }

            Console.ReadKey();
        }

        public static void ShowGetCommentsList(int userId)
        {
            var result = client.GetCommentsList(userId);

            foreach (var comment in result)
            {
                Console.WriteLine(comment);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\t\tКоличество символов : {comment.Body.Length}");
                Console.ResetColor();
                Console.WriteLine();
            }


            Console.ReadKey();
        }

        public static void ShowGetTodos(int userId)
        {
            var result = client.GetTodos(userId);

            foreach (var todo in result)
            {
                Console.WriteLine(todo.Key + "  " + todo.Value); 
                Console.WriteLine();
            }

            Console.ReadKey();
        }

        public static void ShowGetOrderedUserList()
        {
            var result = client.GetOrderedUserList();

            foreach (var user in result)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\t\tИмя : {user.Name}");
                Console.ResetColor();
                Console.WriteLine(user);
                Console.WriteLine("\t\tTodos");
                foreach (var todo in user.Todos)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("\t\t" + todo.Name);
                    Console.ResetColor();
                }
                Console.WriteLine();
            }


            Console.ReadKey();
        }

        public static void ShowGetUserInfo(int inputId)
        {
            var result = client.GetUserInfo(inputId);

            Console.WriteLine(result.User);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\t\tСписок постов пользователя");
            Console.ResetColor();
            Console.WriteLine(new string('-', 100));

            foreach (var post in result.User.Posts)
            {
                if (post.Equals(result.LastPost) || post.Equals(result.BestPost) || post.Equals(result.MostPopComment))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    if (post.Equals(result.LastPost))
                    {
                        Console.WriteLine("\tПоследний пост");
                        Console.WriteLine($"\tКоличество комментов под последним постом : {result.LastPostCommentsCount}");
                    }
                    if (post.Equals(result.MostPopComment))
                        Console.WriteLine("\tСамый популярный пост(больше всего комментов с длиной текста больше 80 символов)");
                    if (post.Equals(result.BestPost))
                        Console.WriteLine("Самый популярный пост пользователя(больше всего лайков)");
                    Console.WriteLine(new string('-', 82));
                    Console.ResetColor();
                    Console.WriteLine(post);
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(new string('-', 82));
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine(post);
                }
                
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\t\tСписок тасков пользователя");
            Console.ResetColor();
            Console.WriteLine(new string('-', 100));
            foreach (var todo in result.User.Todos)
            {
                Console.WriteLine(todo);
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Количество невыполненных тасков : {result.UnfinishedTasksCount}");
            Console.ResetColor();
            Console.ReadKey();
        }


        public static void ShowGetPostInfo(int inputId)
        {
            var result = client.GetPostInfo(inputId);

            Console.WriteLine(result.Post);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\t\tСписок комментов пользователя");
            Console.ResetColor();
            Console.WriteLine(new string('-', 100));

            foreach (var comment in result.Post.Comments)
            {
                if (comment.Equals(result.LongestComment) || comment.Equals(result.BestComment))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    if (comment.Equals(result.LongestComment))
                        Console.WriteLine($"\tСамый длинный коммент поста");
                    if (comment.Equals(result.BestComment))
                        Console.WriteLine("\tСамый залайканный коммент поста");

                    Console.WriteLine(new string('-', 82));
                    Console.ResetColor();
                    Console.WriteLine(comment);
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(new string('-', 82));
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine(comment);
                }

            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Количество комментов под постом где или 0 лайков или длина текста< 80 : {result.CommentsCount}");
            Console.ResetColor();
            Console.ReadKey();

        }

        static void ShowInputError(string message)
        {
            int posTop = Console.CursorTop + 10,
                    currentPosTop = Console.CursorTop;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.CursorTop = posTop;
            Console.WriteLine(new string(' ', Console.BufferWidth));
            Console.WriteLine(new string(' ', Console.BufferWidth));
            Console.CursorTop = posTop;
            Console.Write("  Ошибка ввода : {0}", message);
            Console.ResetColor();
            Console.CursorTop = currentPosTop;
        }

    }
}
