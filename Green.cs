using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    abstract public class Green // Абстрактно-публичный класс.
    {
        private string _input; // Входная строка.
        public string Input // Свойство входной строки.
        {
            get { return _input ?? string.Empty; }
        }
        public Green(string input) // Конструктор.
        {
            _input = input;
        }
        public abstract void Review(); // Абстрактный метод для всех действий.
        public abstract string ToString(); // Абстрактный метод для работы с итоговыми данными.
    }
}