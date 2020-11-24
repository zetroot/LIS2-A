using System;
using System.Globalization;

namespace LIS2A.Models
{
    /// <summary>
    /// Сообщение-заголовок
    /// </summary>
    public struct HeaderRecord
    {
        /// <summary>
        /// Тип сообщения
        /// </summary>
        public RecordType RecordTypeID => RecordType.MessageHeader;

        /// <summary>
        /// Символ-разделитель полей
        /// </summary>
        public char FieldDelimiter { get; private set; }

        /// <summary>
        /// Символ разделитель пвторяющихся записей
        /// </summary>
        public char RepeatDelimiter { get; private set; }

        /// <summary>
        /// Символ-разделитель компонент записи
        /// </summary>
        public char ComponentDelimiter { get; private set; }

        /// <summary>
        /// Escape-символ
        /// </summary>
        public char EscapeCharacter { get; private set; }

        /// <summary>
        /// Уникальный номер или другой идентификатор передаваемого сообщения
        /// </summary>
        public string MessageControlID { get; private set; }

        /// <summary>
        /// Пароль
        /// </summary>
        public string AccessPassword { get; private set; }

        /// <summary>
        /// Идентификатор отправителя
        /// </summary>
        public string SenderID { get; private set; }

        /// <summary>
        /// Адрес отправителя
        /// </summary>
        public string SenderStreetAddress { get; private set; }

        /// <summary>
        /// Зарезервировано
        /// </summary>
        public string Reserved0 { get; private set; }

        /// <summary>
        /// Телефон отправителя
        /// </summary>
        public string SenderTelephoneNumber { get; private set; }

        /// <summary>
        /// Характеристика отправителя
        /// </summary>
        public string SenderCharacteristics { get; private set; }

        /// <summary>
        /// Идентификатор получателя
        /// </summary>
        public string ReceiverID { get; private set; }

        /// <summary>
        /// Комментарий
        /// </summary>
        public string Comment { get; private set; }

        /// <summary>
        /// Тип обработки сообщения
        /// </summary>
        public ProcessingType ProcessingID { get; private set; }

        /// <summary>
        /// Версия
        /// </summary>
        public string VersionNumber { get; private set; }

        /// <summary>
        /// Дата-время сообщения
        /// </summary>
        public DateTime MessageDateTime { get; private set; }

        public static HeaderRecord Parse(ReadOnlySpan<char> input)
        {
            if (input.Length < 5) throw new ArgumentException("Minimal header length is 5 chars");
            var recordType = RecordType.Parse(input);
            if (recordType != RecordType.MessageHeader) throw new ArgumentException("This is not header record");

            var mutableResult = new HeaderRecord();

            var delimiter = input[1];
            mutableResult.FieldDelimiter = input[1];
            mutableResult.RepeatDelimiter = input[2];
            mutableResult.ComponentDelimiter = input[3];
            mutableResult.EscapeCharacter = input[4];

            if (input.Length > 6)
            {
                mutableResult.MessageControlID = new string(input.GetField(delimiter, 2));
                mutableResult.AccessPassword = new string(input.GetField(delimiter, 3));
                mutableResult.SenderID = new string(input.GetField(delimiter, 4));
                mutableResult.SenderStreetAddress = new string(input.GetField(delimiter, 5));
                mutableResult.Reserved0 = new string(input.GetField(delimiter, 6));
                mutableResult.SenderTelephoneNumber = new string(input.GetField(delimiter, 7));
                mutableResult.SenderCharacteristics = new string(input.GetField(delimiter, 8));
                mutableResult.ReceiverID = new string(input.GetField(delimiter, 9));
                mutableResult.Comment = new string(input.GetField(delimiter, 10));
                var processingType = input.GetField(delimiter, 11);
                mutableResult.ProcessingID = processingType.IsEmpty ? ProcessingType.Production : ProcessingType.Parse(processingType[0]);
                mutableResult.VersionNumber = new string(input.GetField(delimiter, 12));
                var dateTimeText = input.GetField(delimiter, 13);
                if (DateTime.TryParseExact( s: dateTimeText,
                                            format: "yyyyMMddHHmmss",
                                            provider: CultureInfo.InvariantCulture,
                                            style: DateTimeStyles.AssumeLocal | DateTimeStyles.AllowWhiteSpaces,
                                            result: out DateTime parsed))
                    mutableResult.MessageDateTime = parsed;
            }

            return mutableResult;
        }


    }
}
