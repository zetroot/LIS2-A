using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace LIS2A.Models
{
    public class HeaderBuilder
    {
        /// <summary>
        /// Разделители - второе поле
        /// </summary>
        public Delimiters Delimiters { get; set; } = Delimiters.Default;

        /// <summary>
        /// Уникальный номер или другой идентификатор передаваемого сообщения
        /// </summary>
        public string MessageControlID { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        public string AccessPassword { get; set; }

        /// <summary>
        /// Идентификатор отправителя
        /// </summary>
        public string SenderID { get; set; }

        /// <summary>
        /// Адрес отправителя
        /// </summary>
        public string SenderStreetAddress { get; set; }

        /// <summary>
        /// Зарезервировано
        /// </summary>
        public string Reserved0 { get; set; }

        /// <summary>
        /// Телефон отправителя
        /// </summary>
        public string SenderTelephoneNumber { get; set; }

        /// <summary>
        /// Характеристика отправителя
        /// </summary>
        public string SenderCharacteristics { get; set; }

        /// <summary>
        /// Идентификатор получателя
        /// </summary>
        public string ReceiverID { get; set; }

        /// <summary>
        /// Комментарий
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Тип обработки сообщения
        /// </summary>
        public ProcessingType? ProcessingID { get; set; }

        /// <summary>
        /// Версия
        /// </summary>
        public string VersionNumber { get; set; }

        /// <summary>
        /// Дата-время сообщения
        /// </summary>
        public DateTime? MessageDateTime { get; set; }

        /// <summary>
        /// Построить новый заголовок из этого билдера
        /// </summary>
        /// <returns>Новый заголовок</returns>
        public HeaderRecord Build()
        {
            var msgDTField = default(DateTimeField?);
            if (MessageDateTime.HasValue)
                msgDTField = new DateTimeField(MessageDateTime.Value);
            return new HeaderRecord(Delimiters, MessageControlID, AccessPassword, SenderID, SenderStreetAddress, Reserved0, SenderTelephoneNumber, SenderCharacteristics, ReceiverID, Comment, ProcessingID, VersionNumber, msgDTField);
        }
    }
}
