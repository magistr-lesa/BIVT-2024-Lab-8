using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Green_4 : Green // Публичный наследник.
    {
        private string[] _output; // Массив выходных символов.
        private string _input; // Вводная строка.
        public string[] Output => _output; // Свойство выходных символов.
        public Green_4(string input) : base(input) // Конструктор.
        {
            _input = input;
            _output = Array.Empty<string>();
        }
        public override void Review() // Метод махинаций.
        {
            string[] surnames;
            string[] parts = _input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
            surnames = new string[parts.Length];
            for (int i = 0; i < parts.Length; i++)
            {
                surnames[i] = parts[i].Trim();
            }
            bool swapped;
            do
            {
                swapped = false;
                for (int i = 0; i < surnames.Length - 1; i++)
                {
                    if (CompareStrings(surnames[i], surnames[i + 1]) > 0)
                    {
                        string temp = surnames[i];
                        surnames[i] = surnames[i + 1];
                        surnames[i + 1] = temp;
                        swapped = true;
                    }
                }
            } while (swapped);
            _output = surnames;
        }
        private int CompareStrings(string a, string b) // Собственный метод для сравнения по Unicode номерам.
        {
            int minLength = Math.Min(a.Length, b.Length);
            for (int i = 0; i < minLength; i++)
            {
                if (a[i] != b[i]) return Math.Sign(a[i] - b[i]);
            }
            return Math.Sign(a.Length - b.Length);
        }
        public override string ToString() // Метод обработки итоговых данных.
        {
            return Output == null || Output.Length == 0
                ? string.Empty
                : string.Join("\r\n", Output);
        }
    }
}