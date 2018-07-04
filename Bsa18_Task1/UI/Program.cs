using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

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
                    if (int.TryParse(Console.ReadKey().KeyChar.ToString(), out inputNumber))
                    {
                        switch (inputNumber) // выбираем пункты меню
                        {
                            case 1:
                                
                                inputCorrect = true;
                                break;
                            case 2:
                                
                                inputCorrect = true;
                                break;
                            case 3:
                                
                                inputCorrect = true;
                                break;
                            case 4:
                                
                                inputCorrect = true;
                                break;
                            case 5:
                                
                                inputCorrect = true;
                                break;
                            case 6:
                                
                                inputCorrect = true;
                                break;
                            case 7:

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
            Console.WriteLine("    Панель управления зоопарком\n\n" +
                    "\t\t1. Добавить животное\n" +
                    "\t\t2. Покормить животное\n" +
                    "\t\t3. Вылечить животное\n" +
                    "\t\t4. Удалить животное\n" +
                    "\t\t5. Автозаполнение зоопарка\n" +
                    "\t\t6. Показать информаицю о животных\n" +
                    "\t\t7. Выйти\n");
            Console.Write("  Введите цифру соответствующую номеру пункта меню : ");
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
