using System;

namespace Lab6
{
    class Program
    {
        static string ReverseString(string input)
        {
            char[] chars = input.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }

        static void Task1()
        {
            Console.WriteLine("В класс банковский счет, созданный в упражнениях 7.1- 7.3 добавить метод, который переводит деньги с одного счета на другой.");
            BankAccount bankAcc1 = new BankAccount(339325892385, TypeOfBankAccount.Текущий);
            BankAccount bankAcc2 = new BankAccount(563335, TypeOfBankAccount.Сберегательный);
            Console.WriteLine(bankAcc1.GetAccountData());
            Console.WriteLine(bankAcc2.GetAccountData());
            bankAcc1.MoneyTransfer(bankAcc2, 982759823789234m);
            Console.WriteLine($"Новые балансы аккаунтов: \n {bankAcc1.GetAccountBalance()}\n {bankAcc2.GetAccountBalance()}");
        }

        static void Task2()
        {
            Console.WriteLine("Реализовать метод, который в качестве входного параметра принимает строку string, возвращает строку типа string, буквы в которой идут в обратном порядке.");
            Console.Write("Введите строку, чтобы я инверсировал ее: ");
            string? stringToReverse = Console.ReadLine();
            if (string.IsNullOrEmpty(stringToReverse))
            {
                Console.WriteLine("Введена пустая строка или null.");
            }
            else
            {
                string reversedString = ReverseString(stringToReverse);
                Console.WriteLine($"Инверсированная строка: {reversedString}");
            }
        }
        static void Task3()
        {
            Console.Write("Укажите название файла:");
            string fileNamePath = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(fileNamePath))
            {
                Console.WriteLine("Имя файла не может быть пустым.");
                return;
            }
            string fileName = $"../../../{fileNamePath}";
            if (!File.Exists(fileName))
            {
                Console.WriteLine("Файл не существует.");
                return;
            }
            try
            {
                string content = File.ReadAllText(fileName);
                string upperContent = content.ToUpper();
                File.WriteAllText($"../../../TxtFile.txt", upperContent);

                Console.WriteLine("Файл успешно создан с содержимым в верхнем регистре.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }
        static void Task4()
        {
            object obj1 = 88888888;
            object obj2 = "zokjvoiwjeiojfow";
            CheckIFormattable(obj1);
            CheckIFormattable(obj2);
        }
        static void CheckIFormattable(object obj)
        {
            if (obj is IFormattable)
            {
                IFormattable? formattableObj = obj as IFormattable;
                Console.WriteLine("Объект реализует интерфейс IFormattable.");
                Console.WriteLine($"Форматированное представление: {formattableObj?.ToString(null, null)}");
            }
            else
            {
                Console.WriteLine("Объект не реализует интерфейс IFormattable.");
        }
        }

        static void Main(string[] args)
        {
            Task1();
            Task2();
            Task3();
            Task4();
        }
    }
}
