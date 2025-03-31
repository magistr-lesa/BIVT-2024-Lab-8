using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Green_3 : Green // Публичный наследник.
    {
        private string[] _output; // Массив выходных символов.
        private string _posled; // Искомая последовательность.
        public string[] Output => _output; // Свойство выходных символов.
        public Green_3(string input, string posled) : base(input) // Конструктор.
        {
            _output = Array.Empty<string>();
            _posled = posled;
        }
        public override void Review() // Метод махинаций.
        {
            string text = Input;
            char[] delimiters = { ' ', '.', '!', '?', ',', ':', '\"',';',
                                  '–', '(', ')', '[', ']', '{', '}', '/'};
            string[] words = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            int count = 0;
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].IndexOf(_posled, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    count++;
                }
            }
            string[] foundWords = new string[count];
            int index = 0;
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].IndexOf(_posled, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    foundWords[index] = words[i].ToLower();
                    index++;
                }
            }
            _output = foundWords;
        }
        public override string ToString() // Метод обработки итоговых данных.
        {
            return Output == null || Output.Length == 0
                ? string.Empty
                : string.Join("\r\n", Output);
        }
    }
}