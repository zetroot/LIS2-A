using System;
using System.Globalization;

namespace LIS2A.Models
{
    /// <summary>
    /// Сообщение-заголовок
    /// </summary>
    public readonly struct HeaderRecord
    {
        /// <summary>
        /// Тип сообщения
        /// </summary>
        public RecordType RecordTypeID => RecordType.MessageHeader;

        /// <summary>
        /// Разделители - второе поле
        /// </summary>
        public Delimiters Delimiters { get; }

        
        /// <summary>
        /// Уникальный номер или другой идентификатор передаваемого сообщения
        /// </summary>
        public string MessageControlID { get; }

        /// <summary>
        /// Пароль
        /// </summary>
        public string AccessPassword { get; }

        /// <summary>
        /// Идентификатор отправителя
        /// </summary>
        public string SenderID { get; }

        /// <summary>
        /// Адрес отправителя
        /// </summary>
        public string SenderStreetAddress { get; }

        /// <summary>
        /// Зарезервировано
        /// </summary>
        public string Reserved0 { get; }

        /// <summary>
        /// Телефон отправителя
        /// </summary>
        public string SenderTelephoneNumber { get; }

        /// <summary>
        /// Характеристика отправителя
        /// </summary>
        public string SenderCharacteristics { get; }

        /// <summary>
        /// Идентификатор получателя
        /// </summary>
        public string ReceiverID { get; }

        /// <summary>
        /// Комментарий
        /// </summary>
        public string Comment { get; }

        /// <summary>
        /// Тип обработки сообщения
        /// </summary>
        public ProcessingType? ProcessingID { get; }

        /// <summary>
        /// Версия
        /// </summary>
        public string VersionNumber { get; }

        /// <summary>
        /// Дата-время сообщения
        /// </summary>
        public DateTime? MessageDateTime { get; }

        /// <summary>
        /// Внутренний конструктор для работы фабрики
        /// </summary>
        /// <param name="delimiters">структура с разделителями</param>
        /// <param name="messageControlID"></param>
        /// <param name="accessPassword"></param>
        /// <param name="senderID"></param>
        /// <param name="senderStreetAddress"></param>
        /// <param name="reserved0"></param>
        /// <param name="senderTelephoneNumber"></param>
        /// <param name="senderCharacteristics"></param>
        /// <param name="receiverID"></param>
        /// <param name="comment"></param>
        /// <param name="processingID"></param>
        /// <param name="versionNumber"></param>
        /// <param name="messageDateTime"></param>
        internal HeaderRecord(
            Delimiters delimiters,
            string messageControlID,
            string accessPassword,
            string senderID,
            string senderStreetAddress,
            string reserved0,
            string senderTelephoneNumber,
            string senderCharacteristics,
            string receiverID,
            string comment,
            ProcessingType? processingID,
            string versionNumber,
            DateTime? messageDateTime)
        {
            Delimiters = delimiters;
            MessageControlID = messageControlID;
            AccessPassword = accessPassword;
            SenderID = senderID;
            SenderStreetAddress = senderStreetAddress;
            Reserved0 = reserved0;
            SenderTelephoneNumber = senderTelephoneNumber;
            SenderCharacteristics = senderCharacteristics;
            ReceiverID = receiverID;
            Comment = comment;
            ProcessingID = processingID;
            VersionNumber = versionNumber;
            MessageDateTime = messageDateTime;
        }

        public static HeaderRecord Parse(ReadOnlySpan<char> input)
        {
            if (input.Length < 5) throw new ArgumentException("Minimal header length is 5 chars");
            var recordType = RecordType.Parse(input);
            if (recordType != RecordType.MessageHeader) throw new ArgumentException("This is not header record");

            var delimiters = Delimiters.Parse(input.Slice(1, 4));

            var messageControlID = new string(input.GetField(delimiters.FieldDelimiter, 2));
            var accessPassword = new string(input.GetField(delimiters.FieldDelimiter, 3));
            var senderID = new string(input.GetField(delimiters.FieldDelimiter, 4));
            var senderStreetAddress = new string(input.GetField(delimiters.FieldDelimiter, 5));
            var reserved0 = new string(input.GetField(delimiters.FieldDelimiter, 6));
            var senderTelephoneNumber = new string(input.GetField(delimiters.FieldDelimiter, 7));
            var senderCharacteristics = new string(input.GetField(delimiters.FieldDelimiter, 8));
            var receiverID = new string(input.GetField(delimiters.FieldDelimiter, 9));
            var comment = new string(input.GetField(delimiters.FieldDelimiter, 10));
            var processingType = input.GetField(delimiters.FieldDelimiter, 11);
            var processingID = processingType.IsEmpty ? default(ProcessingType?) : ProcessingType.Parse(processingType[0]);
            var versionNumber = new string(input.GetField(delimiters.FieldDelimiter, 12));
            var dateTimeText = input.GetField(delimiters.FieldDelimiter, 13);
            var msgDateTime = default(DateTime?);
            if (DateTime.TryParseExact( s: dateTimeText,
                                        format: "yyyyMMddHHmmss",
                                        provider: CultureInfo.InvariantCulture,
                                        style: DateTimeStyles.AssumeLocal | DateTimeStyles.AllowWhiteSpaces,
                                        result: out DateTime parsed))
                    msgDateTime = parsed;


            return new HeaderRecord(
                delimiters,
                messageControlID,
                accessPassword,
                senderID,
                senderStreetAddress,
                reserved0,
                senderTelephoneNumber,
                senderCharacteristics,
                receiverID,
                comment,
                processingID,
                versionNumber,
                msgDateTime);
        }


    }
}
