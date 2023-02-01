using System;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Text;

namespace FileMenager1
{
    class Program
    {
        /// <summary>
        /// В этом методе пользователю предлагается список всех действий, которые он может сделать.
        /// В зависимости от того, какую цифру введет пользователь (каждое действие пронумеровано), 
        /// будет вызван соотоветствующий метод(отвечающий за данное действие).
        /// </summary>
        /// <param name="path"> путь </param>
        public static void Menu(ref string path)
        {
            Console.WriteLine("Введите цифру(обозначающую действие, которое вы хотите выполнить)");
            Console.WriteLine();
            Console.WriteLine(@" ""0""  - возврат назад ");
            Console.WriteLine(@" ""1""  - просмотр списка дисков и выбор диска");
            Console.WriteLine(@" ""2""  - переход в другую директорию (выбор папки)");
            Console.WriteLine(@" ""3""  - просмотр списка файлов в директории и выбор файлов");
            Console.WriteLine(@" ""4""  - вывод содержимого текстового файла в консоль в кодировке UTF-8 ");
            Console.WriteLine(@" ""5""  - вывод содержимого текстового файла в консоль в выбранной пользователем кодировке ");
            Console.WriteLine(@" ""6""  - копирование файла (копирование содержимого файлa в новый файл с названием, которое вы сами выберите)");
            Console.WriteLine(@" ""7""  - перемещение файлов в выбранную пользователем директорию");
            Console.WriteLine(@" ""8""  - удаление файла ");
            Console.WriteLine(@" ""9""  - создание простого текстового файла в кодировке UTF-8");
            Console.WriteLine(@" ""10"" - создание простого текстового файла в выбранной пользователем кодировке");
            Console.WriteLine(@" ""11"" - конкатенация содержимого двух или более текстовых файлов и вывод результата в консоль в  кодировке UTF-8");
            Console.WriteLine(@" ""12"" - вывод в консоль текста записанного в уже существующем файле и добавление нового теста в этот файл");
            Console.WriteLine("P.S.:");
            Console.WriteLine("Чтобы воспользоваться действиями 4,5,6,7,8,11,12 вы сначала должны сконструировать путь до файла.");
            Console.WriteLine("Чтобы воспользоваться действиями 9,10 вы сначала должны сконструировать путь до папки, в которой вы хотите создать файл");
            Console.WriteLine("Когда путь будет готов, смело пользуйтесь данными действиями.");
            Console.WriteLine(" И еще ... При действиях 6,11 (копирование или конкатенация происходит в файл, который находится в папке, где и был изначально выбранный файл.)");
            Console.WriteLine("Если хотите его переместить, то выберите этот файл, затем выберите команду 7 (перемещение) ");
            Console.WriteLine("\n");
            int n = ValidateInteger();
            switch (n)
            {
                case (0):
                    Method0(ref path);
                    break;
                case (1):
                    Method1(ref path);
                    break;
                case (2):
                    Method2(ref path);
                    break;
                case (3):
                    Method3(ref path);
                    break;
                case (4):
                    Method4(ref path);
                    break;
                case (5):
                    Method5(ref path);
                    break;
                case (6):
                    Method6(ref path);
                    break;
                case (7):
                    Method7(ref path);
                    break;
                case (8):
                    Method8(ref path);
                    break;
                case (9):
                    Method9(ref path);
                    break;
                case (10):
                    Method10(ref path);
                    break;
                case (11):
                    Method11(ref path);
                    break;
                case (12):
                    Method12(ref path);
                    break;
                default:
                    return;
            }
        }
        /// <summary>
        /// Метод, отвечающий за возвращения пути на один шаг назад.
        /// </summary>
        /// <param name="path"> путь </param>
        static void Method0(ref string path)
        {
            try
            {
                char sep = Path.DirectorySeparatorChar;
                if (path == "")
                    Console.WriteLine("Вы не можете вернуться назад, так как путь еще не создан.");
                else
                {

                    string pathzerostr = "";
                    string[] pathzero = path.Split(new char[] { Path.DirectorySeparatorChar });
                    if (pathzero.Length > 2)
                    {
                        Array.Clear(pathzero, pathzero.Length - 1, 1);

                        pathzerostr = string.Join(sep, pathzero);
                        int ind = pathzerostr.LastIndexOf(Path.DirectorySeparatorChar);
                        path = pathzerostr.Substring(0, ind);
                    }
                    else if (path.IndexOf(sep) == path.LastIndexOf(sep))
                    {
                        if (path.IndexOf(sep) != path.Length - 1)
                        {
                            int ind = path.LastIndexOf(Path.DirectorySeparatorChar);
                            path = path.Substring(0, ind + 1);
                        }
                        else
                        {
                            path = "";
                        }
                    }


                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exeption " + "\n" + e.Message);
            }
        }
        /// <summary>
        /// Метод отвечающий за вывод в консоль текста записанного в уже существующем файле и добавление нового теста в этот файл.
        /// </summary>
        /// <param name="path"> путь </param>
        static void Method12(ref string path)
        {
            try
            {
                if (path == "")
                {
                    Console.WriteLine("Сначала нужно создать путь.");
                    Console.WriteLine("Передите к какому-то текстовому файлу, а затем нажмите 12. ");
                }
                else
                {
                    if (File.Exists(path))
                    {
                        Console.WriteLine("Cодержимое файла: " + File.ReadAllText(path, Encoding.UTF8));
                        Console.WriteLine("Введите текст, который хотите добавить в файл: ");
                        string newtext = Console.ReadLine();
                        File.AppendAllText(path, newtext, Encoding.UTF8);
                        Console.WriteLine("Новое содержимое файла: " + File.ReadAllText(path, Encoding.UTF8));
                    }
                    else
                    {
                        Console.WriteLine("Такого файла не существует. Сначала выберите файл, затем вы сможете воспользоваться данным действием.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exeption " + "\n" + ex.Message);
            }
        }

        /// <summary>
        /// Метод отвечает за конкатенацию содержимого двух или более текстовых файлов и вывод результата в консоль в  кодировке UTF-8.
        /// При предоставлении выбора, действия находится под номером 11, отсюда вытекает название метода.
        /// </summary>
        /// <param name="path"> путь </param>
        static void Method11(ref string path)
        {
            try
            {
                if (path == "")
                {
                    Console.WriteLine("Сначала нужно создать путь.");
                    Console.WriteLine("Передите к какому-то текстовому файлу, а затем выбирайте данное действие. ");
                }
                else
                {
                    if (!File.Exists(path))
                    {
                        Console.WriteLine("Файл не найден. Сначала выберите файл, а затем вы сможете выбрать данное действие.");
                        Console.WriteLine("(Вам нужно  построить путь к файлу, который вы хотите открыть)");
                    }
                    else
                    {
                        int n;
                        char sep = Path.DirectorySeparatorChar;
                        string text = "";
                        Console.WriteLine("Введите название для нового файла (туда будет записан результат конкатенации)");
                        string NameFile = Console.ReadLine();
                        int index = path.LastIndexOf(Path.DirectorySeparatorChar);
                        string newPathRes = path.Substring(0, index);
                        string WriteText = newPathRes + Path.DirectorySeparatorChar + NameFile;
                        text += File.ReadAllText(path);
                        do
                        {

                            Console.WriteLine("Хотите конкатенировать с еще одим текстовым файлом ? ");
                            Console.WriteLine("Если да - нажмите 1,тогда вам еще раз нужно будет выбрать нужый файл");
                            Console.WriteLine("Если нет - нажмите 0,тогда выведется содержимое текстового файла");
                            n = Checknew();
                            string newpath;

                            if (n == 1)
                            {

                                int ind = path.LastIndexOf(Path.DirectorySeparatorChar);
                                newpath = path.Substring(0, ind);
                                Method3(ref newpath);
                                text += File.ReadAllText(newpath, Encoding.UTF8);

                            }
                            else
                            {
                                Console.WriteLine("Ваш сконкатенированный текст: " + text);
                                File.WriteAllText(WriteText, text);
                            }
                        } while (n != 0);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exeption " + ex.Message);
            }

        }
        /// <summary>
        /// Метод отвечает за создание простого текстового файла в выбранной пользователем кодировке.
        /// </summary>
        /// <param name="path"> путь </param>
        static void Method10(ref string path)
        {
            try
            {
                if (path == "")
                {
                    Console.WriteLine("Сначала нужно создать путь.");
                    Console.WriteLine("Перейдите к соответствующей директории, где вы хотите создать текстовый файл.");
                }
                else
                {
                    int flagname = 1;
                    char[] invalidPathChars = Path.GetInvalidPathChars();
                    Console.WriteLine("Введите как вы хотите назвать файл");
                    string name = Console.ReadLine();
                    for (int i = 0; i < name.Length; i++)
                    {
                        if (invalidPathChars.Contains(name[i]))
                        {
                            flagname = 0;
                        }
                    }
                    if (flagname == 0)
                    {
                        Console.WriteLine("Ошибка в названии. Вы использовали не разрешенные символы.");
                    }
                    else
                    {

                        path += Path.DirectorySeparatorChar + name;
                        Console.WriteLine("Введите текст, который вы хотите поместить в новый файл");
                        string text;
                        text = Console.ReadLine();
                        Console.WriteLine("1 Encoding UTF8");
                        Console.WriteLine("2 Encoding UTF32");
                        Console.WriteLine("3 Encoding UTF7");
                        int n1;
                        do
                        {
                            Console.WriteLine("Выберите кодировку:");
                        } while (!int.TryParse(Console.ReadLine(), out n1) || n1 <= 0 || n1 >= 4);
                        if (n1 == 1)
                        {
                            File.WriteAllText(path, text, Encoding.UTF8);
                        }
                        else if (n1 == 2)
                        {
                            File.WriteAllText(path, text, Encoding.UTF32);
                        }
                        else if (n1 == 3)
                        {
                            File.WriteAllText(path, text, Encoding.UTF7);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exeption " + "\n" + ex.Message);
            }
        }
        /// <summary>
        /// Метод отвечающий за создание простого текстового файла в кодировке UTF-8.
        /// </summary>
        /// <param name="path"> путь </param>
        static void Method9(ref string path)
        {

            try
            {
                if (path == "")
                {
                    Console.WriteLine("Сначала нужно создать путь.");
                    Console.WriteLine("Перейдите к соответствующей директории, где вы хотите создать текстовый файл.");
                }
                else
                {
                    int flagname = 1;
                    char[] invalidPathChars = Path.GetInvalidPathChars();
                    Console.WriteLine("Введите как вы хотите назвать файл");
                    string name = Console.ReadLine();
                    for (int i = 0; i < name.Length; i++)
                    {
                        if (invalidPathChars.Contains(name[i]))
                        {
                            flagname = 0;
                        }
                    }
                    if (flagname == 0)
                    {
                        Console.WriteLine("Ошибка в названии. Вы использовали не разрешенные символы.");
                    }
                    else
                    {
                        path += Path.DirectorySeparatorChar + name;
                        Console.WriteLine("Введите текст, который вы хотите поместить в новый файл");
                        string text;
                        text = Console.ReadLine();
                        File.WriteAllText(path, text, Encoding.UTF8);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exeption " + "\n" + ex.Message);
            }
        }
        /// <summary>
        /// Метод отвечающий за удаление файла.
        /// </summary>
        /// <param name="path"> путь </param>
        static void Method8(ref string path)
        {
            try
            {
                if (path == "")
                {
                    Console.WriteLine("Сначала нужно создать путь.");
                    Console.WriteLine("Перейдите к файлу, который вы хотите удалить.");
                }
                else
                {
                    File.Delete(path);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exeption " + "\n" + ex.Message);
            }
        }
        /// <summary>
        /// Метод отвечающий за перемещение файлов в выбранную пользователем директорию.
        /// </summary>
        /// <param name="path"> путь </param>
        static void Method7(ref string path)
        {
            try
            {
                if (path == "")
                {
                    Console.WriteLine("Сначала нужно создать путь.");
                    Console.WriteLine("Выберите сначала файл, который хотите переместить в (выбранную вами) директорию");
                }
                else
                {
                    if (File.Exists(path))
                    {
                        string newpath = "";
                        int n;
                        do
                        {
                            Console.WriteLine("Если вы еще не выбрали нужную для перемещения директорию, то нажмите 1 для продолжения , иначе нажмите 0");
                            n = Checknew();
                            if (n == 1)
                            {

                                Method2(ref newpath);
                            }

                        } while (n != 0);
                        int ind = path.LastIndexOf(Path.DirectorySeparatorChar);
                        newpath += path.Substring(ind, path.Length - ind);
                        Console.WriteLine("new path " + newpath);
                        if (!File.Exists(newpath))
                        {
                            File.Copy(path, newpath);
                            File.Delete(path);
                        }
                        else
                        {
                            Console.WriteLine("Этот файл уже существует");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Файла не существует.");
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exeption " + "\n" + ex.Message);
            }
        }
        /// <summary>
        /// Метод отвечающий за копирование файла.
        /// Копирование содержимого текстового файлa в новый с названием, которое создает сам пользователь.
        /// </summary>
        /// <param name="path"> путь </param>
        static void Method6(ref string path)
        {
            try
            {
                if (path == "")
                {
                    Console.WriteLine("Сначала нужно создать путь.");
                    Console.WriteLine("Выберите сначала файл, который вы хотите скопировать.");
                }
                else
                {
                    if (!File.Exists(path))
                    {
                        Console.WriteLine("Файла не существует. Выберите сначала файла, затем вы сможете его скопировать.");
                    }
                    else
                    {
                        Console.WriteLine("Введите как вы хотите назвать новый файл");
                        string newpathname = Console.ReadLine();
                        string pathzerostr = "";
                        string[] pathzero = path.Split(new char[] { Path.DirectorySeparatorChar });
                        Array.Clear(pathzero, pathzero.Length - 1, 1);
                        int i = 0;
                        foreach (var numder in pathzero)
                        {
                            pathzerostr += pathzero[i] + Path.DirectorySeparatorChar;
                            i++;
                        }
                        string newpath;
                        newpath = pathzerostr + newpathname;
                        if (!File.Exists(newpath))
                        {
                            File.Copy(path, newpath);
                        }
                        else
                        {
                            Console.WriteLine("Этот файл уже существует");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exeption " + "\n" + ex.Message);
            }
        }
        /// <summary>
        /// Метод отвечающий за вывод содержимого текстового файла в консоль в выбранной пользователем кодировке.
        /// </summary>
        /// <param name="path"> путь </param>
        static void Method5(ref string path)
        {
            try
            {
                if (path == "")
                {
                    Console.WriteLine("Сначала нужно сконструировать путь. Начните с действия 1 (выбор дисков)");
                    Console.WriteLine("Затем у вас уже будет возможность выбирать данную команду .");
                }
                else
                {
                    if (!File.Exists(path))
                    {
                        Console.WriteLine("Файла не существует. Выберите его сначала.");
                    }
                    else
                    {
                        int n1;
                        Console.WriteLine("1 Encoding UTF8");
                        Console.WriteLine("2 Encoding UTF32");
                        Console.WriteLine("3 Encoding UTF7");
                        do
                        {
                            Console.WriteLine("выберите кодировку:");
                        } while (!int.TryParse(Console.ReadLine(), out n1) || (n1 <= 0) || (n1 >= 4));
                        if (n1 == 1)
                        {
                            Console.WriteLine(File.ReadAllText(path), Encoding.UTF8);
                        }
                        else if (n1 == 2)
                        {
                            Console.WriteLine(File.ReadAllText(path), Encoding.UTF32);
                        }
                        else if (n1 == 3)
                        {
                            Console.WriteLine(File.ReadAllText(path), Encoding.UTF7);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Некорректный путь " + "\n" + ex.Message);
            }
        }
        /// <summary>
        /// Метод отвечающий за вывод содержимого текстового файла в консоль в кодировке UTF-8.
        /// </summary>
        /// <param name="path"> путь </param>
        static void Method4(ref string path)
        {
            try
            {
                if (path == "")
                {
                    Console.WriteLine("Сначала нужно сконструировать путь. Начните с действия 1 (выбор дисков)");
                    Console.WriteLine("Затем у вас уже будет возможность выбирать данную команду .");
                }
                else
                {
                    if (File.Exists(path))
                    {
                        Console.WriteLine(File.ReadAllText(path), Encoding.UTF8);
                    }
                    else
                    {
                        Console.WriteLine("Файла не существует. Выберите, пожалуйста, файл");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Некорректный путь " + "\n" + ex.Message);
            }
        }

        /// <summary>
        /// Метод отвечающий за просмотр списка файлов в директории и выбор файлов.
        /// </summary>
        /// <param name="path"> путь </param>
        static void Method3(ref string path)
        {
            try
            {
                if (path == "")
                {
                    Console.WriteLine("Копьютеру непонятно, где вы хотите просмотреть список файлов...");
                    Console.WriteLine("Сначала вы должны создать ненулевой путь (начиная с действия 1)");
                }
                else
                {
                    string[] file = Directory.GetFiles(path);
                    for (int i = 0; i < file.Length; i++)
                    {
                        Console.WriteLine(i + 1 + " " + file[i]);
                    }
                    int n1;
                    do
                    {
                        Console.WriteLine("выберите номер файла");
                    } while (!int.TryParse(Console.ReadLine(), out n1) || (n1 < 0) || (n1 > file.Length));
                    if (n1 > 0)
                    {
                        path = file[n1 - 1];
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("The process failed: " + "\n" + ex.ToString());
            }
        }
        /// <summary>
        /// Метод отвечающий за просмотр списка дисков и выбор диска.
        /// </summary>
        /// <param name="path"> путь </param>
        static void Method1(ref string path)
        {
            try
            {
                string[] drive = Drives();
                int n1;
                for (int i = 0; i < drive.Length; i++)
                {
                    Console.WriteLine(i + 1 + " " + drive[i]);
                }
                do
                {
                    Console.WriteLine("выберите номер диска");
                } while (!int.TryParse(Console.ReadLine(), out n1) || (n1 <= 0) || (n1 > drive.Length));
                if (n1 > 0)
                {
                    path = drive[n1 - 1];
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: " + "\n" + e.ToString());
            }
        }
        /// <summary>
        /// Метод, отвечающий за переход в другую директорию (выбор папки).
        /// </summary>
        /// <param name="s"> путь </param>
        static void Method2(ref string s)
        {
            try
            {
                int n1;
                if (s == "")
                {
                    Method1(ref s);
                }
                string[] dirs = Directories(s);
                do
                {
                    Console.WriteLine("выберите номер папки в каторую в хотите перейти");
                } while (!int.TryParse(Console.ReadLine(), out n1) || (n1 > dirs.Length) || (n1 <= 0));
                if (n1 > 0)
                {
                    s = dirs[n1 - 1];
                }
                else
                {
                    Console.WriteLine("вы ничего не делаете");
                }
            }
            catch (System.UnauthorizedAccessException ex)
            {
                Console.WriteLine("The process failed: " + "\n" + ex.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("The process failed: " + "\n" + ex.ToString());
                return;
            }


        }
        /// <summary>
        /// В методе выводится на экран список директориев.
        /// </summary>
        /// <param name="path"> путь </param>
        /// <returns> массив, состоящий из директориев </returns>
        static string[] Directories(string path)
        {
            string[] dirs = Directory.GetDirectories(path);
            Console.WriteLine("The number of directories ", dirs.Length);
            for (int i = 0; i < dirs.Length; i++)
            {
                Console.WriteLine(i + 1 + " " + dirs[i]);
            }

            return dirs;
        }
        /// <summary>
        /// В методе создается массив, элементами которого являются диски.
        /// </summary>
        /// <returns> массив, элементами которого являются название дисков</returns>
        static string[] Drives()
        {
            int i = 0;
            DriveInfo[] allDrives = DriveInfo.GetDrives();

            string[] drive = new string[allDrives.Length];
            foreach (DriveInfo d in allDrives)
            {
                drive[i] = d.ToString();
                i++;
            }
            return drive;
        }
        /// <summary>
        /// Проверка введенного значения на корректность.
        /// </summary>
        /// <returns> число от 1 до 12 </returns>
        static int ValidateInteger()
        {
            int n;
            do
            {
                Console.WriteLine("Введите число");
            } while (!int.TryParse(Console.ReadLine(), out n) || (n < 0) || (n > 12));
            return n;


        }
        /// <summary>
        ///  Проверка введенного значения на корректность.
        /// </summary>
        /// <returns> число от 0 до 1 </returns>
        static int Checknew()
        {
            int n;
            do
            {
                Console.WriteLine("Введите число");
            } while (!int.TryParse(Console.ReadLine(), out n) || (n < 0) || (n > 1));
            return n;
        }

        public static void Main()
        {
            try
            {
                Console.WriteLine("Дорогой пользователь, вас приветствует Файловый Менеджер.");
                Console.WriteLine("Вам будет каждый раз показан путь, который вы создаете своими командами (Текущий путь). ");
                Console.WriteLine("Приятного использования:) ");
                bool quit = false;
                string path = "";

                while (!quit)
                {

                    Console.WriteLine();
                    Console.WriteLine("         Текущий путь: " + path);
                    Menu(ref path);
                    Console.WriteLine();
                    Console.WriteLine("Вы хотите продолжить? ");
                    Console.WriteLine("Если да, то введите 1. Программа продолжит свое выполнение.");
                    Console.WriteLine("Если нет, то введите 0. Программа закроется.");
                    int checnew = Checknew();
                    if (checnew == 0)
                    {
                        quit = true;
                    }
                    else
                    {
                        quit = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exeption " + "\n" + ex.Message);
            }
        }
    }
}