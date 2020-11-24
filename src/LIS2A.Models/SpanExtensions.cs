using System;
using System.Collections.Generic;
using System.Text;

namespace LIS2A.Models
{
    internal static class SpanExtensions
    {
        /// <summary>
        /// Получить поле из диапазона по его идентификтаору
        /// </summary>
        /// <param name="input">обрабатываемый диапазон</param>
        /// <param name="delimiter">разделитель полей</param>
        /// <param name="fieldNum">номер поля с 0</param>
        /// <returns>Диапазон - искомое поле. пустой диапазон если поля нет</returns>
        public static ReadOnlySpan<char> GetField(this ReadOnlySpan<char> input, char delimiter, int fieldNum) => GetFieldRec(input, delimiter, fieldNum);

        private static ReadOnlySpan<char> GetFieldRec(ReadOnlySpan<char> input, char delimiter, int fieldNum)
        {
            var nextDelimiterIdx = input.IndexOf(delimiter);

            if (fieldNum == 0)
            {
                if (nextDelimiterIdx == -1) return input;
                return input.Slice(0, nextDelimiterIdx);
            }
            else
            {
                if (nextDelimiterIdx == -1) return ReadOnlySpan<char>.Empty;
                return GetFieldRec(input.Slice(nextDelimiterIdx + 1), delimiter, --fieldNum);
            }
        }
    }
}
