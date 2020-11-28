using System;
using System.Collections.Generic;
using System.Text;

namespace LIS2A.Models
{
    /// <summary>
    /// Разделители
    /// </summary>
    public struct Delimiters
    {
        public static readonly Delimiters Default = new Delimiters('|', '\\', '^', '&');
        /// <summary>
        /// Символ-разделитель полей
        /// </summary>
        public char FieldDelimiter { get; }

        /// <summary>
        /// Символ разделитель пвторяющихся записей
        /// </summary>
        public char RepeatDelimiter { get; }

        /// <summary>
        /// Символ-разделитель компонент записи
        /// </summary>
        public char ComponentDelimiter { get; }

        /// <summary>
        /// Escape-символ
        /// </summary>
        public char EscapeCharacter { get; }

        public Delimiters(char fieldDelimiter, char repeatDelimiter, char componentDelimiter, char escapeCharacter)
        {
            FieldDelimiter = fieldDelimiter;
            RepeatDelimiter = repeatDelimiter;
            ComponentDelimiter = componentDelimiter;
            EscapeCharacter = escapeCharacter;
        }

        /// <summary>
        /// Парсит из массива символов
        /// </summary>
        /// <param name="input">Исходный массив символов</param>
        /// <returns>Построенный объект разделителей</returns>
        public static Delimiters Parse(ReadOnlySpan<char> input)
        {
            if (input.IsEmpty) throw new ArgumentException("Can't parse delimiters from empty span");
            if (input.Length < 4) throw new ArgumentException("Span is too short. Need 4 chars at least.");
            return new Delimiters(input[0], input[1], input[2], input[3]);
        }
    }
}
