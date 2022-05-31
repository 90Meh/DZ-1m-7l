var start = false;
do
{

    Console.WriteLine("Введите размерность таблицы.");
    Console.WriteLine("Размер таблицы может составлять от 1го до 6ти.");


    var sizeTable = 0;
    var state = true;

    //Запрос у пользователя размеров таблицы.
    while (state)
    {
        var sizeParse = int.TryParse(Console.ReadLine(), out sizeTable);

        if (sizeParse && sizeTable > 0 && sizeTable < 7)
        {
            state = false;
        }

        else
        {
            Console.WriteLine("Число введено некорректно, попробуйте ещё раз.");
            Console.WriteLine("Размер таблицы может составлять от 1го до 6ти.");
        }
    }

    Console.WriteLine("Введите Текст для таблицы.");

    //Запрос у пользователя содержания таблицы.
    var text = "";

    while (!state)
    {
        text = Console.ReadLine();

        if (string.IsNullOrEmpty(text) || text.Length > 28)
        {
            Console.WriteLine("Таблица не может быть пустой и не может содержать больше 28ми символов. Введите текст");
        }
        else
        {
            state = true;
        }
    }

    //Метод для получения строки разделителя.
    static string Separator(int a)
    {
        var b = "";
        for (int i = 0; i <= a; i++)
        {
            b = b + "+";
        }
        return b;
    }
    //Метод для вывода горизонтальных, пустых строк.
    static void Midle(int a, int b)
    {
        var midle = "";
        for (int i = 0; i < a - 1; i++)
        {
            midle = midle + " ";
        }

        string second = "+" + midle + "+";

        for (int i = 0; i < b - 1; i++)
        {
            Console.WriteLine(second);
        }
    }
    //Метод собирающий строку с текстом
    static string TextInBox(int st, string t)
    {
        var textTemp = "";
        for (int i = 0; i < st - 1; i++)
        {
            textTemp += " ";
        }

        var third = "+" + textTemp + t + textTemp + "+";
        return third;
    }

    //Метод вывода шахматной доски
    static void Chess(int ls, int st)
    {
        var chessStringTemp1 = " ";
        var chessStringTemp2 = "+";
        for (int i = 0; i < ls - 2; i++)
        {
            if (chessStringTemp1[i] == ' ')
            {
                chessStringTemp1 = chessStringTemp1 + "+";
                chessStringTemp2 = chessStringTemp2 + " ";
            }
            else
            {
                chessStringTemp1 = chessStringTemp1 + " ";
                chessStringTemp2 = chessStringTemp2 + "+";
            }
        }

        var chessString1 = "+" + chessStringTemp1 + "+";
        var chessString2 = "+" + chessStringTemp2 + "+";
        var stateChess = 2;
        for (int i = 1; i < st * 2; i++)
        {
            if (stateChess == 1)
            {
                Console.WriteLine(chessString2);
                stateChess = 2;
            }
            else
            {
                Console.WriteLine(chessString1);
                stateChess = 1;
            }
        }

    }

    //Метод выводящий крест
    static void Cross(int ls)
    {
        char[] cross = new char[ls - 1];
        cross[0] = '+';
        cross[cross.Length - 1] = '+';
        for (int i = 0; i < cross.Length; i++)
        {
            cross[i] = ' ';
        }

        for (int i = 0; i < cross.Length; ++i)
        {
            cross[i] = '+';
            cross[cross.Length - 1 - i] = '+';
            string crossString = new string(cross);
            crossString = "+" + crossString + "+";
            Console.WriteLine(crossString);
            cross[i] = ' ';
            cross[cross.Length - 1 - i] = ' ';
        }
    }



    //Вызов методов и сборка строк
    var lenghtString = text.Length + sizeTable * 2 - 1;
    string separator = Separator(lenghtString);
    string textInBox = TextInBox(sizeTable, text);

    Console.WriteLine(separator);
    Midle(lenghtString, sizeTable);
    Console.WriteLine(textInBox);
    Midle(lenghtString, sizeTable);
    Console.WriteLine(separator);
    Chess(lenghtString, sizeTable);
    Console.WriteLine(separator);
    Cross(lenghtString);
    Console.WriteLine(separator);


    //Перезапуск приложения.
    Console.WriteLine("Выполнить программу ещё раз? yes/no");
    var ci = true;
    while (ci)
    {
        string startString = Console.ReadLine();
        switch (startString)
        {
            case "yes":
                start = true;
                ci = false;
                break;
            case "no":
                start = false;
                ci = false;
                break;
            default:
                Console.WriteLine("Введено некорректно.Повторите ввод.");
                break;
        }

    }


} while (start);//Знаю не очень честно, но не придумалось куда приставить do while ещё)