using System;
using System.Collections.Generic;
using System.Text;

namespace LIS2A.Models
{
    /// <summary>
    /// Тип передаваемого сообщения
    /// </summary>
    public readonly struct RecordType
    {
        /// <summary>
        /// Заголовок сообщения - Message Header Record (H)
        /// Эта запись должна содержать информацию об отправителе и получателе (приборе и ЛИС которые осуществляют обмен)
        /// Так же она содержит информацию о символах используемых как разделители полей, повторения в поле, разделителя компонент
        /// </summary>
        public static readonly RecordType MessageHeader = new RecordType('H');

        /// <summary>
        /// Запись идентифицирующая пациента - Patient Identifying Record (P)
        /// В этом типе записи передается информация идентифицирующая пациента
        /// </summary>
        public static readonly RecordType PatientIdentifying = new RecordType('P');

        /// <summary>
        /// Заказ исследований - Test Order Record (O)
        /// </summary>
        public static readonly RecordType TestOrder = new RecordType('O');

        /// <summary>
        /// Результаты исследования - Result Record (R) 
        /// </summary>
        public static readonly RecordType Result = new RecordType('R');

        /// <summary>
        /// Комментарий - Comment Record (C) 
        /// </summary>
        public static readonly RecordType Comment = new RecordType('C');

        /// <summary>
        /// Запрос информации - Request Information Record (Q) 
        /// </summary>
        public static readonly RecordType RequestInformation = new RecordType('Q');

        /// <summary>
        /// Исследовательские цели - Scientific Record (S) 
        /// </summary>
        public static readonly RecordType Scientific = new RecordType('S');

        /// <summary>
        /// Информация от производителя - Manufacturer Information Record (M)
        /// </summary>
        public static readonly RecordType ManufacturerInformation = new RecordType('M');

        /// <summary>
        /// Символ отображающий тип заголовка
        /// </summary>
        private readonly char typeID;

        private RecordType(char typeID)
        {
            this.typeID = typeID;
        }

        public override bool Equals(object obj)
        {
            if (obj is RecordType recordType)
                return this.typeID.Equals(recordType.typeID);
            return false;
        }

        public override int GetHashCode() => typeID.GetHashCode();

        public static bool operator ==(RecordType left, RecordType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(RecordType left, RecordType right)
        {
            return !(left == right);
        }
    }
}
