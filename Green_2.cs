using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Green_2 : Green // Публичный наследник.
    {
        private char[] _output; // Массив выходных символов.
        public char[] Output => _output; // Его свойство.

        public Green_2(string input) : base(input) // Конструктор.
        {
            _output = Array.Empty<char>();
        }
        public override void Review() // Метод махинаций.
        {
            string text = Input.ToLower();
            char[] letters = new char[] { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й',
                                  'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф',
                                  'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я',
                                  'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
                                  'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't',
                                  'u', 'v', 'w', 'x', 'y', 'z'};
            char[] delimiters = { ' ', '.', '!', '?', ',', ':', '\"',';',
                                  '–', '(', ')', '[', ']', '{', '}', '/'};
            string[] words = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            int[] counts = new int[letters.Length];
            int totalWords = 0;
            for (int i = 0; i < words.Length; i++)
            {
                char first = words[i][0];
                for (int j = 0; j < letters.Length; j++)
                {
                    if (first == letters[j])
                    {
                        counts[j]++;
                        totalWords++;
                        break;
                    }
                }
            }
            if (totalWords == 0)
            {
                _output = new char[0];
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
            (char, int)[] vrem = new (char, int)[nonZeroCount];
            int index = 0;
            for (int i = 0; i < letters.Length; i++)
            {
                if (counts[i] > 0)
                {
                    vrem[index] = (letters[i], counts[i]);
                    index++;
                }
            }
            bool swapped;
            do
            {
                swapped = false;
                for (int i = 0; i < vrem.Length - 1; i++)
                {
                    if (vrem[i].Item2 < vrem[i + 1].Item2 ||
                       (vrem[i].Item2 == vrem[i + 1].Item2 && vrem[i].Item1 > vrem[i + 1].Item1))
                    {
                        var temp = vrem[i];
                        vrem[i] = vrem[i + 1];
                        vrem[i + 1] = temp;
                        swapped = true;
                    }
                }
            } while (swapped);
            _output = new char[vrem.Length];
            for (int i = 0; i < vrem.Length; i++)
            {
                _output[i] = vrem[i].Item1;
            }
        }
        public override string ToString() // Метод обработки итоговых данных.
        {
            return Output == null || Output.Length == 0
                ? string.Empty
                : string.Join(", ", _output);
        }
    }
}
