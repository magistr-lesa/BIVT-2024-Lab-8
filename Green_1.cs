using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Green_1 : Green // Публичный наследник.
    {
        private (char, double)[] _output; // Массив кортежей вывода. 
        public (char, double)[] Output => _output; // Его свойство.
        public Green_1 (string input) : base(input) // Конструктор.
        {
            _output = Array.Empty<(char, double)>();
        }
        public override void Review() // Метод махинаций.
        {
            string text = Input.ToLower();
            char[] letters = new char[] { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й',
                                          'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф',
                                          'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };
            int[] counts = new int[letters.Length];
            int totalLetters = 0;
            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];
                for (int j = 0; j < letters.Length; j++)
                {
                    if (c == letters[j])
                    {
                        counts[j]++;
                        totalLetters++;
                        break;
                    }
                }
            }
            if (totalLetters == 0)
            {
                _output = new (char, double)[0];
                return;
            }
            int nonZeroCount = 0;
            for (int i = 0; i < counts.Length; i++)
            {
                if (counts[i] > 0)
                {
                    nonZeroCount++;
                }
            }
            (char, double)[] res = new (char, double)[nonZeroCount];
            int index = 0;
            for (int i = 0; i < letters.Length; i++)
            {
                if (counts[i] > 0)
                {
                    res[index] = (letters[i], (double)counts[i] / totalLetters);
                    index++;
                }
            }
            _output = res;
        }
        public override string ToString() // Метод обработки итоговых данных.
        {
            return Output == null || Output.Length == 0
                ? string.Empty
                : string.Join("\r\n", Array.ConvertAll(Output, item => $"{item.Item1} - {item.Item2:F4}"));
        }

    }
}