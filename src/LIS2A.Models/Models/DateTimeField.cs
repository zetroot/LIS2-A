using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace LIS2A.Models
{
    /// <summary>
    /// Поле с датой и временем
    /// </summary>
    public readonly struct DateTimeField
    {
        /// <summary>
        /// временная метка представленная полем
        /// </summary>
        public DateTime DateTime { get; }

        internal DateTimeField(DateTime internalDateTime)
        {
            DateTime = internalDateTime;
        }

        /// <summary>
        /// Парсит входящую строку как дату
        /// </summary>
        /// <param name="input">Входящая строка</param>
        /// <returns>Поле с датой</returns>
        public static DateTimeField Parse(ReadOnlySpan<char> input)
        {
            if (DateTime.TryParseExact(s: input,
                                        format: "yyyyMMddHHmmss",
                                        provider: CultureInfo.InvariantCulture,
                                        style: DateTimeStyles.AssumeLocal | DateTimeStyles.AllowWhiteSpaces,
                                        result: out DateTime parsed))
                return new DateTimeField(parsed);
            throw new ArgumentException("Can't parse input as date");
        }
    }
}
