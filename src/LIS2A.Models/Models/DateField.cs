using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace LIS2A.Models
{
    /// <summary>
    /// Тип поля - только дата
    /// </summary>
    public readonly struct DateField
    {
        /// <summary>
        /// Дата представленная полем
        /// </summary>
        public DateTime Date { get; }

        internal DateField(DateTime internalDateTime)
        {
            Date = internalDateTime.Date;
        }

        /// <summary>
        /// Парсит входящую строку как дату
        /// </summary>
        /// <param name="input">Входящая строка</param>
        /// <returns>Поле с датой</returns>
        public static DateField Parse(ReadOnlySpan<char> input)
        {            
            if (DateTime.TryParseExact(s: input,
                                        format: "yyyyMMdd",
                                        provider: CultureInfo.InvariantCulture,
                                        style: DateTimeStyles.AssumeLocal | DateTimeStyles.AllowWhiteSpaces,
                                        result: out DateTime parsed))
                return new DateField(parsed);
            throw new ArgumentException("Can't parse input as date");
        }
    }
}
