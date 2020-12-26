using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Для получения информации вызовите команду \"инфо\"");
            int kol_Switch = 0;
            //DirectoryInfo dir1 = new DirectoryInfo(".");// Привязаться к текущему рабочему каталогу
            DirectoryInfo MainDir = new DirectoryInfo(@"C:\"); // Привязаться к C:\Users\пк
            Console.Write(MainDir.FullName + ">");//Начальная строка  директори, в которой будем работать
            while (0 < 1)
            {
                string KomandString = Console.ReadLine();
                string[] words = KomandString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);//разбиваем командную строку на части
                string Komand = words[0].ToString();
                Switch(words, Komand, MainDir, kol_Switch, out MainDir);
                Console.Write(MainDir.FullName + ">");
            }
            Console.ReadKey();
        }

        public static DirectoryInfo Switch(string[] words, string komand, DirectoryInfo MainDir, int kol_Switch, out DirectoryInfo Maindir)//Определие команды
        {
            Maindir = MainDir;
            string str;
            if (kol_Switch == 1)
            {
                words = komand.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                komand = words[0].ToString();
            }
            switch (komand)
            {
                case "ИНФО":
                case "инфо":
                case "Инфо":
                    {
                        if (words.Length == 1) //Если общее ИНФО
                            Console.WriteLine("СМЕНА         Смена текущей папки\nСК            Создать каталог\nСФ            Создать файл\nКАТАЛОГ       Вывод списка файлов и подпапок из указанной папки\nФАЙЛ          Вывод информации об указанном файле\nПФ            Поиск файла\nКОПИРОВАТЬ    Копировать содержимое указанного файла в дргой файл\nУДКАТ         Удалить каталог\nУДФ           Удалить файл\nПЕРФ          Переместить файл\nПЕРК          Переместить каталог\nПЕРЕИМЕНОВАТЬ Переименовать файл\nОЧИСТИТЬ      Очистка экрана\nПС            Поск строки в указаном файле\n\nЧтобы получить информацию об определенной команде, введите ИНФО имя_команды");
                        if (words.Length == 2)//Если информация поопределенной команде
                        {
                            komand = words[1].ToString();
                            Info(komand);
                        }
                        if (words.Length > 2) Console.WriteLine("Неверная команда. Для получения информации вызовите команду ИНФО.");
                    }
                    break;
                case "СМЕНА":
                case "смена":
                case "Смена":
                    Smena(words, MainDir, out Maindir);              //Смена каталога
                    break;
                case "СК":
                case "ск":
                case "Создатькаталог":
                case "создатькаталог":
                    Directory.CreationOfCatalog(words, MainDir);//Создание каталога
                    break;
                case "СФ":
                case "сф":
                case "Создатьфайл":
                case "создатьфайл":
                    File.CreationOfFile(words, MainDir);//создание файла
                    break;
                case "КАТАЛОГ":
                case "каталог":
                case "Каталог":
                    Directory.DirectoryType(words, MainDir);//Вывод содержимого каталога
                    break;
                case "ФАЙЛ":
                case "файл":
                case "Файл":
                    File.FileType(words, MainDir);//Вывод содержимого файла 
                    break;
                case "ПОИСКФАЙЛА":
                case "поискфайла":
                case "ПФ":
                case "пф":
                    File.FindFile(words, MainDir);//поиск файла по шаблону
                    break;
                case "КОПИРОВАТЬ":
                case "копировать":
                case "Копировать":
                    File.CopyFile(words, MainDir);//копировать файл
                    break;
                case "УДАЛИТЬКАТАЛОГ":
                case "удалитькаталог":
                case "УДКАТ":
                case "удкат":
                    Directory.DirectoryDel(words, MainDir);//удалить каталог
                    break;
                case "УДАЛИТЬФАЙЛ":
                case "удалитьфайл":
                case "УДФ":
                case "удф":
                    File.FileDel(words, MainDir);//удалить файл
                    break;
                case "ПЕРЕМЕСТИТЬФАЙЛ":
                case "переместитьфайл":
                case "ПЕРФ":
                case "перф":
                    File.FileMove(words, MainDir);//переместить файл с удалением
                    break;
                case "ПЕРЕМЕСТИТЬКАТАЛОК":
                case "переместитькаталог":
                case "ПЕРК":
                case "перк":
                    Directory.DirectoryMove(words, MainDir);//переместить каталог
                    break;
                case "ПЕРЕИМЕНОВАТЬ":
                case "переименовать":
                case "Переименовать":
                    File.FileRen(words, MainDir);//переименовать файл
                    break;
                case "ОЧИСТИТЬ":
                case "очистить":
                case "Очистить":
                    Console.Clear();//очистить экран
                    break;
                case "ПОИСКСТРОКИ":
                case "поискстроки":
                case "ПС":
                case "пс":
                    File.FileFindString(words, MainDir);//поиск строки
                    break;
                default:
                    {
                        KomandFile(words, MainDir, kol_Switch);
                        kol_Switch++;
                    }
                    break;
            }
            return Maindir;
        }

        public static DirectoryInfo Smena(string[] words, DirectoryInfo md, out DirectoryInfo maindir)
        {
            maindir = md;
            string str;
            try
            {
                if (words.Length == 1)
                {
                    str = @"" + maindir + @"";//Путь
                    DirectoryInfo dir = new DirectoryInfo(str);
                    maindir = dir;
                }
                if (words.Length == 2)
                {
                    str = @"" + words[1] + @"";//Путь
                    DirectoryInfo dir = new DirectoryInfo(str);
                    maindir = dir;
                }
                if (words.Length > 2) Console.WriteLine("Неверная команда. Для получения информации вызовите команду ИНФО.");
            }
            catch (DirectoryNotFoundException ex) { Console.WriteLine(ex.Message); }
            return maindir;
        }

        public static void Info(string komand) //ИНФО
        {
            switch (komand)
            {
                case "СМЕНА":
                case "смена":
                case "Смена":
                    Console.WriteLine("Изменяет текущий каталог.\n\nСМЕНА диск:\\путь\nСмена диск:\\путь\nсмена диск:\\путь\n\nНапример: СМЕНА C:\\Users\\пк\\text");
                    break;
                case "СК":
                case "ск":
                case "Создатькаталог":
                case "создатькаталог":
                    Console.WriteLine("Создать каталог.\n\nСоздатькаталог диск:\\путь\nсоздатькаталог диск:\\путь\nСК диск:\\путь\nск диск:\\путь");
                    break;
                case "СФ":
                case "сф":
                case "Создатьфайл":
                case "создатьфайл":
                    Console.WriteLine("Создать файл.\n\nСоздатьфайл [/З] диск:\\путь\\имя_файла\nсоздатьфайл [/З] диск:\\путь\\имя_файла\nСФ [/З] диск:\\путь\\имя_файла\nсф [/З] диск:\\путь\\имя_файла\n\n[/З] - с вводом текста");
                    break;
                case "КАТАЛОГ":
                case "каталог":
                case "Каталог":
                    Console.WriteLine("Вывод списка файлов и подкаталогов в указанном каталоге.\n\nКАТАЛОГ [/К] диск:\\путь [файл]\nКаталог [/К] диск:\\путь [файл]\nкаталог [/К] диск:\\путь [файл]\n\n/К - копировать информацию в файл");
                    break;
                case "ФАЙЛ":
                case "файл":
                case "Файл":
                    Console.WriteLine("Вывод содержимого файла.\n\nФАЙЛ [/К] [диск:\\путь\\]имя_файла1 [файл2]\nФайл [/К] [диск:\\путь\\]имя_файла1 [файл2]\nфайл [/К] [диск:\\путь\\]имя_файла1 [файл2]\n\n/К - копировать содержимое файла1 в файл2");
                    break;
                case "ПОИСКФАЙЛА":
                case "поискфайла":
                case "ПФ":
                case "пф":
                    Console.WriteLine("Поиск файла.\n\nПОИСКФАЙЛА [диск:\\путь\\]имя_файла\nпоискфайла [диск:\\путь\\]имя_файла\nПФ [диск:\\путь\\]имя_файла\nпф [диск:\\путь\\]имя_файла");
                    break;
                case "КОПИРОВАТЬ":
                case "копировать":
                case "Копировать":
                    Console.WriteLine("Копировать содержимое файла в другой файл.\n\nКОПИРОВАТЬ [диск:\\путь\\]имя_файла1 [диск:\\путь\\]имя_файла2 \nКопировать [диск:\\путь\\]имя_файла1 [диск:\\путь\\]имя_файла2\nкопировать [диск:\\путь\\]имя_файла1 [диск:\\путь\\]имя_файла2");
                    break;
                case "УДАЛИТЬКАТАЛОГ":
                case "удалитькаталог":
                case "УДКАТ":
                case "удкат":
                    Console.WriteLine("Удалить каталог.\n\nУДАЛИТЬКАТАЛОГ диск:\\путь\nудалитькаталог диск:\\путь\nУДКАТ диск:\\путь\nудкат диск:\\путь");
                    break;
                case "УДАЛИТЬФАЙЛ":
                case "удалитьфайл":
                case "УДФ":
                case "удф":
                    Console.WriteLine("Удалить файл.\n\nУДАЛИТЬФАЙЛ [диск:\\путь\\]имя_файла\nудалитьфайл [диск:\\путь\\]имя_файла\nУДФ [диск:\\путь\\]имя_файла\nудф [диск:\\путь\\]имя_файла");
                    break;
                case "ПЕРЕМЕСТИТЬФАЙЛ":
                case "переместитьфайл":
                case "ПЕРФ":
                case "перф":
                    Console.WriteLine("Переместить файл в другой каталог.\n\nПЕРЕМЕСТИТЬФАЙЛ [диск:\\путь\\]имя_файла диск:\\новый_путь\nпереместитьфайл [диск:\\путь\\]имя_файла диск:\\новый_путь\nПЕРФ [диск:\\путь\\]имя_файла диск:\\новый_путь\nперф [диск:\\путь\\]имя_файла диск:\\новый_путь");
                    break;
                case "ПЕРЕМЕСТИТЬКАТАЛОК":
                case "переместитькаталог":
                case "ПЕРК":
                case "перк":
                    Console.WriteLine("Переместить каталог.\n\nПЕРЕМЕСТИТЬКАТАЛОГ [диск:\\старый_каталог] диск:\\новый_каталог\nпереместитькаталог [диск:\\старый_каталог] диск:\\новый_каталог\nПЕРК [диск:\\старый_каталог] диск:\\новый_каталог\nперк [диск:\\старый_каталог] диск:\\новый_каталог");
                    break;
                case "ПЕРЕИМЕНОВАТЬ":
                case "переименовать":
                case "Переименовать":
                    Console.WriteLine("Переименовать файл.\n\nПЕРЕИМЕНОВАТЬ [диск:\\путь\\]старое_имя_файла новое_имя_файла\nпереименовать [диск:\\путь\\]старое_имя_файла новое_имя_файла\nПереименовать [диск:\\путь\\]старое_имя_файла новое_имя_файла");
                    break;
                case "ОЧИСТИТЬ":
                case "очистить":
                case "Очистить":
                    Console.WriteLine("Очистка содержимого экрана.");
                    break;
                case "ПОИСКСТРОКИ":
                case "поискстроки":
                case "ПС":
                case "пс":
                    Console.WriteLine("Поиск строки в указвнном файле.\n\nПОИСКСТРОКИ [диск:\\путь\\]имя_файла искомая_строка\nпоискстроки [диск:\\путь\\]имя_файла искомая_строка\nПС [диск:\\путь\\]имя_файла искомая_строка\nпс [диск:\\путь\\]имя_файла искомая_строка");
                    break;
                default:
                    Console.WriteLine("Неверная команда {0}. Для получения информации вызовите команду ИНФО.", komand);
                    break;
            }
        }

        public static void KomandFile(string[] words2, DirectoryInfo maindir, int kol_Switch)
        {
            string path = maindir.ToString();
            string file = words2[0];
            if (file.Contains("//"))
            {
                try
                {
                    try
                    {
                        FileStream filestream = new FileStream(file, FileMode.Open); //создаем файловый поток 
                        StreamReader reader = new StreamReader(filestream, Encoding.GetEncoding(1251)); //Открываем файл для чтения
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            if (kol_Switch > 0) Console.WriteLine("Неверная команда {0}. Для получения информации вызовите команду ИНФО.", line);
                            if (kol_Switch == 0)
                            {
                                kol_Switch = 0;
                                Switch(words2, line, maindir, kol_Switch, out maindir);
                            }
                        }
                    }
                    catch (UnauthorizedAccessException ex) { Console.WriteLine(ex.Message); }
                }
                catch (NotSupportedException ex) { Console.WriteLine(ex.Message); }
            }
            else
            {
                path += "\\" + file;
                try
                {
                    try
                    {
                        FileStream filestream = new FileStream(path, FileMode.Open); //создаем файловый поток 
                        StreamReader reader = new StreamReader(filestream, Encoding.GetEncoding(1251)); //Открываем файл для чтения
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            if (kol_Switch > 0) Console.WriteLine("Неверная команда {0}. Для получения информации вызовите команду ИНФО.", line);
                            if (kol_Switch == 0)
                            {
                                kol_Switch = 1;
                                Switch(words2, line, maindir, kol_Switch, out maindir);
                                kol_Switch = 0;
                            }
                        }
                    }
                    catch (UnauthorizedAccessException ex) { Console.WriteLine(ex.Message); }
                }
                catch (NotSupportedException ex) { Console.WriteLine(ex.Message); }
            }
        }

        public static string Parts(string[] words2, DirectoryInfo maindir, out string key, out string file, out string str)
        {
            file = maindir.ToString();
            key = "";
            str = "";
            if (words2.Length == 2)//если 2 элемента
            {
                if (words2[1].ToString()[0] != '/')
                {
                    if (words2[1].ToString().Contains(':'))//не втекущем каталоге
                        file = words2[1];
                    if (words2[1].ToString().Contains(':') == false)//в текущем каталоге
                    {
                        if (words2[1].ToString().Contains('.')) file += words2[1];
                    }
                    return file;
                }
                else Console.WriteLine("Неверная команда. Для получения информации вызовите команду ИНФО.");
            }
            if (words2.Length == 3)//если 3 элемента
            {
                if (words2[1].Length == 2)
                {
                    key = words2[1];
                    if (words2[2].ToString().Contains(':'))//не втекущем каталоге
                        file = words2[2];
                    if (words2[2].ToString().Contains(':') == false)//в текущем каталоге
                        file += words2[2];
                }
                else
                {
                    if (words2[1].ToString().Contains(':'))//не втекущем каталоге
                        file = words2[1];
                    if (words2[1].ToString().Contains(':') == false)//в текущем каталоге
                        file += words2[1];
                    str = words2[2];
                }
                return key;
                return file;
            }
            else Console.WriteLine("Неверная команда. Для получения информации вызовите команду ИНФО.");
            if (words2.Length == 4)//если 4 элемента
            {
                if (words2[1].Length == 2)
                {
                    key = words2[1];
                    if (words2[2].ToString().Contains(':'))//не втекущем каталоге
                        file = words2[2];
                    if (words2[2].ToString().Contains(':') == false)//в текущем каталоге
                        file += words2[2];
                    str = words2[3];
                    return key;
                    return str;
                    return file;
                }
                else Console.WriteLine("Неверная команда. Для получения информации вызовите команду ИНФО.");
            }
            return key;
        }

        public class Directory
        {
            public static void CreationOfCatalog(string[] words2, DirectoryInfo maindir)//Создание каталога
            {
                if (words2.Length == 2)
                {
                    string path = words2[1];//Путь
                    string str = "";//Для разбиения пути
                    if (path.Contains(":\\") == false)//Если создаем в текущем каталоге
                    {
                        maindir.CreateSubdirectory(path);//Создание подкаталогов в текущем каталоге
                    }
                    if (path.Contains(":\\") == true)//Если создаем не в текущем каталоге
                    {
                        for (int i = 0; i < 3; i++) str += path[i];//Присвоение главное каталога, например C:\
                        try
                        {
                            DirectoryInfo newdir = new DirectoryInfo(str);
                            str = "";
                            for (int i = 3; i < path.Length; i++) str += path[i];//Присвоение остальных подкаталогов
                            newdir.CreateSubdirectory(str);
                        }
                        catch (NotSupportedException ex)
                        {
                            Console.WriteLine("Невозможно найти каталог. " + ex.Message);
                        }
                    }
                }
            }

            public static void DirectoryType(string[] words2, DirectoryInfo maindir)//Вывод содержимого каталога
            {
                string key, path, file;
                if (words2.Length > 4 || words2.Length < 2) Console.WriteLine("Неверная команда. Для получения информации вызовите команду ИНФО.");
                else
                {
                    path = maindir.ToString();
                    key = "";
                    file = "";
                    if (words2.Length == 2)//если 2 элемента
                    {
                        if (words2[1].ToString() != "/К")
                            path = words2[1];
                        else Console.WriteLine("Неверная команда. Для получения информации вызовите команду ИНФО.");
                    }
                    if (words2.Length == 3)//если 3 элемента
                    {
                        if (words2[1].ToString() == "/К")
                        {
                            key = words2[1];
                            file = words2[2];
                        }
                        else Console.WriteLine("Неверная команда. Для получения информации вызовите команду ИНФО.");
                    }
                    if (words2.Length == 4)//если 4 элемента
                    {
                        if (words2[1].ToString() == "/К")
                        {
                            key = words2[1];
                            path = words2[2];
                            file = words2[3];
                        }
                        else Console.WriteLine("Неверная команда. Для получения информации вызовите команду ИНФО.");
                    }
                    DirectoryInfo typedir = new DirectoryInfo(@path);
                    DirectoryInfo[] directors = typedir.GetDirectories();
                    int countfile = 0;
                    if (key == "")//если без ключа
                    {
                        FileInfo[] typefile = typedir.GetFiles();
                        for (int i = 0; i < typefile.Count(); i++)
                        {
                            Console.WriteLine(typefile[i].CreationTime + "           " + typefile[i].Length + " " + typefile[i].Name);
                        }
                        foreach (DirectoryInfo d in directors)
                        {
                            Console.Write(d.CreationTime + " " + d.Attributes + "         " + d.Name);
                            typefile = d.GetFiles();
                            countfile = typefile.Length;
                            for (int i = 0; i < typefile.Count(); i++)
                            {
                                Console.WriteLine(typefile[i].CreationTime + "           " + typefile[i].Length + " " + typefile[i].Name);
                            }
                        }
                    }
                    Console.WriteLine("           {0} папок, {1} файлов", directors.Length, countfile);
                    if (key != "")//Если есть ключ - копировать в файл
                    {
                        FileStream filestream = new FileStream(@file, FileMode.Open); //создаем файловый поток
                        StreamWriter writer = new StreamWriter(filestream, Encoding.GetEncoding(1251));
                        string text = ""; //Объявляем переменную, в которую будем записывать текст из файла 
                        StreamReader filereader = new StreamReader(filestream, Encoding.GetEncoding(1251));
                        while (!filereader.EndOfStream) //Цикл длиться пока не будет достигнут конец файла
                        {
                            text = filereader.ReadLine(); //В переменную text по строчно записываем содержимое файла
                            writer.WriteLine(text);
                        }
                        foreach (DirectoryInfo d in directors)
                        {
                            Console.Write(d.CreationTime + " " + d.Attributes + "         " + d.Name);
                            text = d.CreationTime + " " + d.Attributes + "         " + d.Name;
                            writer.WriteLine(text);
                            FileInfo[] typefile = d.GetFiles();
                            countfile = typefile.Length;
                            for (int i = 0; i < typefile.Count(); i++)
                            {
                                Console.WriteLine(typefile[i].CreationTime + "           " + typefile[i].Length + " " + typefile[i].Name);
                                text = typefile[i].CreationTime + "           " + typefile[i].Length + " " + typefile[i].Name;
                                writer.WriteLine(text);
                            }
                        }
                        Console.WriteLine("           {0} папок, {1} файлов", directors.Length, countfile);
                        text = directors.Length.ToString() + " папок, " + countfile.ToString() + " файлов";
                        writer.WriteLine(text);
                        writer.Close();
                    }
                }
            }

            public static void DirectoryDel(string[] words2, DirectoryInfo maindir)//Удалить каталог
            {
                if (words2.Length > 2) Console.WriteLine("Неверная команда. Для получения информации вызовите команду ИНФО.");
                string path = maindir.ToString();//Путь
                if (words2.Length == 2)//Если создаем не в текущем каталоге
                    path = words2[1];//Путь
                DirectoryInfo typedir = new DirectoryInfo(@path);
                typedir.Delete(true);//c удалением подкаталогов
            }

            public static void DirectoryMove(string[] words2, DirectoryInfo maindir)//Переместить каталог
            {
                if (words2.Length > 3) Console.WriteLine("Неверная команда. Для получения информации вызовите команду ИНФО.");
                string pathold = maindir.ToString();//Путь
                string pathnew = words2[1];
                int countname = 0;
                if (words2.Length == 3)//Если создаем не в текущем каталоге
                {
                    pathold = words2[1];
                    pathnew = words2[2];
                }
                int i = pathold.Length - 1;
                while (pathold[i] != '\\')
                {
                    countname++;
                    i--;
                }
                pathnew += "\\";
                for (int j = pathold.Length - countname - 1; j < pathold.Length; j++)
                    pathnew += pathold[j];
                DirectoryInfo dirmove = new DirectoryInfo(@pathold);
                if (dirmove.Exists)
                    dirmove.MoveTo(pathnew);
            }
        }

        public class File
        {
            public static void CreationOfFile(string[] words2, DirectoryInfo maindir)//Создание файла
            {
                string sumbol;
                string file;//имя файла
                string key, str;
                Parts(words2, maindir, out key, out file, out str);
                try
                {
                    if (key == "")
                    {
                        FileInfo newfile = new FileInfo(@file);
                        if (newfile.Exists == false) //Если файл не существует
                        {
                            newfile.Create(); //Создаем
                            Console.WriteLine("Создан: " + newfile.FullName);
                        }
                        else Console.WriteLine("Файл уже существует");
                    }
                    if (key != "")//c вводом текста
                    {
                        if (key != "/З")
                            Console.WriteLine("Такого ключа не существует. Для получения информации вызовите команду ИНФО.");
                        if (key == "/З")
                        {
                            Console.WriteLine("Запись текста. По окончанию введите end");
                            FileStream filestream = new FileStream(@file, FileMode.OpenOrCreate); //создаем файловый поток
                            StreamReader filereader = new StreamReader(filestream, Encoding.GetEncoding(1251));
                            StreamWriter writer = new StreamWriter(filestream, Encoding.GetEncoding(1251));
                            string text = ""; //Объявляем переменную, в которую будем записывать текст из файла 
                            while (!filereader.EndOfStream) //Цикл длиться пока не будет достигнут конец файла
                            {
                                text = filereader.ReadLine(); //В переменную text по строчно записываем содержимое файла
                                writer.WriteLine(text);
                            }
                            //sumbol = "";
                            do
                            {
                                sumbol = "";
                                text = Console.ReadLine(); //В переменную text по строчно записываем текст
                                if (text != "end") writer.WriteLine(text);
                                //keypress = Console.ReadKey(); // считать данные о нажатых клавишах   
                                sumbol = text;
                            } while (sumbol != "end");
                            writer.Close();
                        }
                    }
                }
                catch (FileNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            public static void FileType(string[] words2, DirectoryInfo maindir)//Вывод содержимого файла
            {
                string file1;//имя файла
                string key, file2;
                Parts(words2, maindir, out key, out file1, out file2);
                try
                {
                    FileStream filestream1 = new FileStream(file1, FileMode.Open); //создаем файловый поток
                    StreamReader reader1 = new StreamReader(filestream1, Encoding.GetEncoding(1251));

                    if (key != "")//Если есть ключ - копировать в файл
                    {
                        FileStream filestream2 = new FileStream(file2, FileMode.Open); //создаем файловый поток
                        StreamWriter writer = new StreamWriter(filestream2, Encoding.GetEncoding(1251));
                        StreamReader reader2 = new StreamReader(filestream2, Encoding.GetEncoding(1251));
                        string text = ""; //Объявляем переменную, в которую будем записывать текст из файла 
                        while (!reader2.EndOfStream) //Цикл длиться пока не будет достигнут конец файла
                        {
                            text = reader2.ReadLine(); //В переменную text по строчно записываем содержимое файла2
                            writer.WriteLine(text);
                        }
                        while (!reader1.EndOfStream) //Цикл длиться пока не будет достигнут конец файла
                        {
                            text = reader1.ReadLine(); //В переменную text по строчно записываем содержимое файла1
                            writer.WriteLine(text);
                            Console.WriteLine(text);
                        }
                        writer.Close();
                    }
                    if (key == "")//Если без ключа
                        Console.WriteLine(reader1.ReadToEnd()); //считываем все данные с потока и выводим на экран
                    reader1.Close(); //закрываем поток
                }
                catch (FileNotFoundException ex)
                {
                    Console.WriteLine("Невозможно найти файл. ", ex.Message);
                }
            }

            public static void FindFile(string[] words2, DirectoryInfo maindir)//поиск файла по шаблону
            {
                string path;
                string key, str;
                Parts(words2, maindir, out key, out path, out str);
                if (words2.Length == 2) str = words2[1].ToString();
                try
                {
                    DirectoryInfo newdir = new DirectoryInfo(@path);
                    try
                    {
                        try
                        {
                            FileInfo[] files = newdir.GetFiles(str + "*.*", SearchOption.AllDirectories);
                            Console.WriteLine("Найдено {0} файлов", files.Length);
                            foreach (FileInfo f in files)
                                Console.WriteLine(f.CreationTime + "  " + f.Length + "  " + f.Name);
                        }
                        catch (UnauthorizedAccessException ex) { Console.WriteLine(ex.Message); }
                    }
                    catch (DirectoryNotFoundException ex)
                    { Console.WriteLine(ex.Message); }
                }
                catch (NotSupportedException ex) { Console.WriteLine(ex.Message); }
            }

            public static void CopyFile(string[] words2, DirectoryInfo maindir)//Копировать файл 
            {
                string file1, key, file2, str;
                Parts(words2, maindir, out key, out file1, out file2);
                try
                {
                    if (file2[1] != ':')
                    {
                        str = file2;
                        file2 = maindir.ToString() + str;
                    }
                    try
                    {
                        try
                        {
                            FileStream filestream2 = new FileStream(file2, FileMode.Open); //создаем файловый поток
                            StreamReader reader2 = new StreamReader(filestream2, Encoding.GetEncoding(1251));
                            StreamWriter writer = new StreamWriter(filestream2, Encoding.GetEncoding(1251));
                            string text = ""; //Объявляем переменную, в которую будем записывать текст из файла
                            while (!reader2.EndOfStream) //Цикл длиться пока не будет достигнут конец файла
                            {
                                file2 = reader2.ReadLine(); //В переменную text по строчно записываем содержимое файла2
                                writer.WriteLine(text);
                            }
                            FileStream filestream1 = new FileStream(file1, FileMode.Open); //создаем файловый поток 
                            StreamReader reader1 = new StreamReader(filestream1, Encoding.GetEncoding(1251)); //Открываем файл для чтения
                            while (!reader1.EndOfStream) //Цикл длиться пока не будет достигнут конец файла
                            {
                                text = reader1.ReadLine() + "\n"; //В переменную text по строчно записываем содержимое файла1
                                writer.WriteLine(text);
                            }
                            writer.Close(); // Закрываем файл
                        }
                        catch (UnauthorizedAccessException ex) { Console.WriteLine(ex.Message); }
                    }
                    catch (DirectoryNotFoundException ex)
                    { Console.WriteLine(ex.Message); }
                }
                catch (NotSupportedException ex) { Console.WriteLine(ex.Message); }
            }

            public static void FileDel(string[] words2, DirectoryInfo maindir)//Удалить файл
            {
                string file, key, str;
                Parts(words2, maindir, out key, out file, out str);
                try
                {
                    try
                    {
                        FileInfo fileInf = new FileInfo(@file);
                        if (fileInf.Exists)
                            fileInf.Delete();
                    }
                    catch (UnauthorizedAccessException ex) { Console.WriteLine(ex.Message); }
                }
                catch (NotSupportedException ex) { Console.WriteLine(ex.Message); }
            }

            public static void FileMove(string[] words2, DirectoryInfo maindir)//Переместить файл
            {
                string file, key, newpath;
                string file2 = "";
                int count = 0;
                Parts(words2, maindir, out key, out file, out newpath);
                try
                {
                    try
                    {
                        int i = file.Length - 1;
                        while (i != 0)
                        {
                            if (file[i] != '\\') i--;
                            else
                            {
                                count = i;
                                i = 0;
                            }
                        }
                        for (int j = count; j < file.Length; j++) file2 += file[j];
                        FileInfo fileInf = new FileInfo(@file);
                        try
                        {
                            if (fileInf.Exists) fileInf.MoveTo(@newpath + file2);
                        }
                        catch (DirectoryNotFoundException ex) { Console.WriteLine(ex.Message); }
                    }
                    catch (UnauthorizedAccessException ex) { Console.WriteLine(ex.Message); }
                }
                catch (NotSupportedException ex) { Console.WriteLine(ex.Message); }
            }

            public static void FileRen(string[] words2, DirectoryInfo maindir)//Переименовать файл
            {
                string file, key, newname, str;
                string file2 = "";
                Parts(words2, maindir, out key, out file, out newname);
                str = newname;
                newname = "";
                int i = file.Length - 1; int count = 0;
                while (i != 0)
                {
                    if (file[i] != '\\') i--;
                    else
                    {
                        count = i;
                        i = 0;
                    }
                }
                for (int j = count; j < file.Length; j++) file2 += file[j];
                for (int j = 0; j < count + 1; j++) newname += file[j];
                newname += str;
                try
                {
                    try
                    {
                        FileInfo fileInf = new FileInfo(@file);
                        fileInf.MoveTo(@newname);
                    }
                    catch (UnauthorizedAccessException ex) { Console.WriteLine(ex.Message); }
                }
                catch (NotSupportedException ex) { Console.WriteLine(ex.Message); }
            }

            public static void FileFindString(string[] words2, DirectoryInfo maindir)//Поиск строки
            {
                string file, key, findstring;
                int countstring = 0;
                Parts(words2, maindir, out key, out file, out findstring);
                try
                {
                    try
                    {
                        FileStream filestream = new FileStream(file, FileMode.Open); //создаем файловый поток 
                        StreamReader reader = new StreamReader(filestream, Encoding.GetEncoding(1251)); //Открываем файл для чтения
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            if (line.ToLower().Contains(findstring.ToLower()))
                            {
                                Console.WriteLine(line);
                                countstring++;
                            }
                        }
                        Console.WriteLine("Найдено: {0}", countstring);
                    }
                    catch (UnauthorizedAccessException ex) { Console.WriteLine(ex.Message); }
                }
                catch (NotSupportedException ex) { Console.WriteLine(ex.Message); }
            }
        }
    }
}
