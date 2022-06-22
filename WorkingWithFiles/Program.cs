//
//  Файлы
//
//  Практическая работа
//
//  Цель: Научиться работать с файловой системой. Читать данные из файла и записывать их туда
//

/// <summary>
/// Метод, позволяющий вывести заголовок модуля в консоль
/// </summary>
/// <param name="Text">Текст заголовка</param>
static void Heading(string Text)
{
    Console.Clear();
    Console.WriteLine($"\n\t{Text}");
}

/// <summary>
/// Метод, позволяющий разделить строку на фрагменты по разделителю #
/// </summary>
/// <param name="Phrase">Строка для деления</param>
static string[] SplitString(string Phrase)
{
    string[] arrayPart = Phrase.Split('#');
    return arrayPart;
}


/// <summary>
/// Метод для чтения файла
/// </summary>
/// <param name="fileName">Имя файла</param>
static void readFiles(string fileName)
{
    using (StreamReader sr = new StreamReader(fileName))
    {
        while (!sr.EndOfStream)
        {
            Print(sr.ReadLine());
        }
    }     
}

/// <summary>
/// Метод для записи данных в файл
/// </summary>
/// <param name="fileName">Имя файла</param>
/// <param name="Line">Строка данных для записи в файл</param>
static void writeFiles(string fileName, string Line)
{
    using (StreamWriter sw = new StreamWriter(fileName, true))
    {
        sw.WriteLine(Line);
    }
}

/// <summary>
/// Метод форматированного вывода в консоль содержимого файла
/// </summary>
/// <param name="Line">Строка для вывода</param>
static void Print(string Line)
{
    string[] arrayStr = SplitString(Line);
    Console.Write($" {arrayStr[0]} {arrayStr[1]} {arrayStr[2],-30} {arrayStr[3]} {arrayStr[4]} {arrayStr[5]} {arrayStr[6]}");
    //foreach (string str in arrayStr)
    //{
    //    Console.Write($" {str}");        
    //}
    Console.WriteLine();
}

byte exit = 0;
while (exit != 1)
{
    Console.Clear();
    Console.WriteLine($"{"\tМЕНЮ:\n1 - Вывести на экран список сотрудников\n2 - Добавить данные о новых сотрудниках и сохранить в файл\n0 - Выход\n\n====="}");
    Console.Write("\nВыберите пункт меню: ");
    byte numMenu = byte.Parse(Console.ReadLine());
    
    if (numMenu >= 0 && numMenu <= 2) ;
    {
        switch (numMenu)
        {
            case 0: exit = 1; break;    // Выход из программы
            case 1:                     // Выводим список сотрудников в консоль
                Heading("Вывод списка сотрудников");
                Console.WriteLine();
                if (File.Exists(@"staff.txt"))
                {
                    readFiles("staff.txt");
                }
                else
                {
                    Console.WriteLine("\n Файл отсутствует");
                    Console.ReadKey();
                    break;
                }
                Console.ReadKey();
            break;
            case 2:                     // Добавляем данные о новых сотрудниках и сохраняем в файл
                Heading("Добавляем данные о новых сотрудниках и сохраняем в файл");
                string ind = "д";
                do
                {
                    Console.Write("\n\nID сотрудника: ");
                    string strID = Console.ReadLine();
                    string strDate = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                    Console.WriteLine($"Дата и время добавления записи: {strDate}");
                    Console.Write("Фамилия Имя Отчество сотрудника (полностью): ");
                    string strName = Console.ReadLine();
                    Console.Write("Дата рождения: ");
                    string strBirthday = Console.ReadLine();
                    int age = DateTime.Now.Year - Convert.ToDateTime(strBirthday).Year;
                    Console.WriteLine($"Возраст: {age}");
                    Console.Write("Рост: ");
                    string strHeight = Console.ReadLine();
                    Console.Write("Место рождения: ");
                    string strCity = Console.ReadLine();
                    Console.ReadKey();
                    string str = strID + "#" + strDate + "#" + strName + "#" + age + "#" + strHeight + "#" + strBirthday + "#" + strCity;
                    //string str = strID + "#" + strDate + "#" + strName + "#" + age + "#" + strHeight + "#" + strBirthday + "#город " + strCity;
                    writeFiles("staff.txt", str);
                    Console.Write("\nПродолжить в ввод? (д/н): ");
                    ind = Console.ReadLine();
                } while (ind == "д");                
            break;
        }
    } 
}