namespace Тумаков
{
    internal class Program
    {
        static void task1()
        {
            /*В класс банковский счет, созданный в упражнениях 7.1- 7.3 добавить
            метод, который переводит деньги с одного счета на другой. У метода два параметра: ссылка
            на объект класса банковский счет откуда снимаются деньги, второй параметр – сумма.*/
            Console.WriteLine("Упражнение 8.1");
            Console.WriteLine("Выберите тип счета: ");
            Console.WriteLine("0 - Сберегательный");
            Console.WriteLine("1 - Расчетный");
            int.TryParse(Console.ReadLine(), out var accountTypeInput);
            AccountType accountType = (AccountType)accountTypeInput;

            BankChet myAccount = new BankChet(accountType);
            Console.Write("Введите начальный баланс: ");
            decimal.TryParse(Console.ReadLine(), out var initialBalance);
            myAccount.SetBalance(initialBalance);

            myAccount.PrintBankChet();

            Console.WriteLine("Теперь аккаунт откуда снимаются деньги");
            Console.WriteLine("Выберите тип счета: ");
            Console.WriteLine("0 - Сберегательный");
            Console.WriteLine("1 - Расчетный");
            int.TryParse(Console.ReadLine(), out var account2Input);
            AccountType account2Type = (AccountType)accountTypeInput;

            BankChet account2 = new BankChet(account2Type);
            Console.Write("Введите начальный баланс: ");
            decimal.TryParse(Console.ReadLine(), out var account2Balance);
            account2.SetBalance(account2Balance);

            Console.WriteLine("Введите сумму для снятия");
            decimal.TryParse(Console.ReadLine(), out var amount);
            if (myAccount.Perevod(account2, amount))
            {
                Console.WriteLine("Перевод получился");
                myAccount.PrintBankChet();
            }
            else
            {
                Console.WriteLine("Перевод не удался");
            }
        }
        static void task2()
        {
            /*Реализовать метод, который в качестве входного параметра принимает
            строку string, возвращает строку типа string, буквы в которой идут в обратном порядке.
            Протестировать метод.*/
            Console.WriteLine("Упражнение 8.2");
            Console.WriteLine("Введите строку");
            string stroka = Console.ReadLine();
            Console.WriteLine("Строка в обратном порядке");
            string stroka2 = StrokaPerevorot(stroka);
            Console.WriteLine(stroka2);
        }
        static void task3()
        {
            /*Написать программу, которая спрашивает у пользователя имя файла. Если
            такого файла не существует, то программа выдает пользователю сообщение и заканчивает
            работу, иначе в выходной файл записывается содержимое исходного файла, но заглавными
            буквами.*/
            Console.WriteLine("Упражнение 8.3");
            Console.WriteLine("Введите название файла");
            string file = Console.ReadLine()!;
            string vvod = File.ReadAllText(file);
            if (File.Exists(file)) 
            {
                string vivod = "";
                using (StreamWriter sw = File.CreateText("вывод.txt"))
                {
                    foreach (char c in vvod)
                    {
                        if (char.IsLetter(c))
                        {
                            vivod += char.ToUpper(c);
                        }
                        else
                        {
                            vivod += c;
                        }
                    }
                    sw.Write(vivod);
                }
            }
            else
            {
                Console.WriteLine("Файла не существует");
            }
        }
        static void task4()
        {
            /*Реализовать метод, который проверяет реализует ли , параметр
            метода интерфейс System.IFormattable.Использовать оператор is и as. (Интерфейс
            IFormattable обеспечивает функциональные возможности форматирования значения объекта
            в строковое представление.)*/
            Console.WriteLine("Упражнение 8.4");
            DateTime k = DateTime.Now;
            if (Preobrazuetsa(k))
            {
                Console.WriteLine("объект поддерживает IFormattable");
            }
            else
            {
                Console.WriteLine("объект не поддерживает IFormattable");
            }
        }
        static void task5() 
        {
            /*Работа со строками. Дан текстовый файл, содержащий ФИО и e-mail
            адрес. Разделителем между ФИО и адресом электронной почты является символ #:
            Иванов Иван Иванович # iviviv@mail.ru
            Петров Петр Петрович # petr@mail.ru
            Сформировать новый файл, содержащий список адресов электронной почты.
            Предусмотреть метод, выделяющий из строки адрес почты. Методу в
            качестве параметра передается символьная строка s, e-mail возвращается в той же строке s:
            public void SearchMail (ref string s).*/
            Console.WriteLine("ДЗ 1");
            if (File.Exists("text.txt"))
            {
                List<string> email = new List<string>();
                using (StreamReader sr = File.OpenText("text.txt"))
                {
                    string s;
                    while ((s = sr.ReadLine()) != null)
                    {
                        SearchMail(ref s);
                        email.Add(s);
                    }
                }
                using (StreamWriter sw = File.CreateText("вывод.txt"))
                {
                    foreach(string s in email)
                    {
                        sw.WriteLine(s);
                    }
                }
            }
            else
            {
                Console.WriteLine("Файла нет");
            }
        }
        public static void SearchMail(ref string s)
        {
            int otvet = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '#')
                {
                    otvet = i;
                }
            }
            otvet++;
            string s1 = "";
            while(otvet < s.Length)
            {
                if (s[otvet] != ' ')
                {
                    s1 += s[otvet];
                }
                otvet++;
            }
            s = s1;
        }
        public static string StrokaPerevorot(string stroka)
        {
            string stroka2 = "";
            for(int i = stroka.Length - 1; i >= 0; i--)
            {
                stroka2 += stroka[i];
            }
            return stroka2;
        }
        public static bool Preobrazuetsa(object o) 
        { 
            if(o is IFormattable)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void Main(string[] args)
        {
            task1();
            task2();
            task3();
            task4();
            task5();
        }
    }
}