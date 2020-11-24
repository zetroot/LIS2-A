using System;
using System.Collections.Generic;
using System.Text;

namespace LIS2A.Models
{
    /// <summary>
    /// Тип обработки сообщения
    /// </summary>
    public readonly struct ProcessingType
    {
        /// <summary>
        /// Обычное сообщение отправленное с производственными целями
        /// </summary>
        public static readonly ProcessingType Production = new ProcessingType('P');

        /// <summary>
        /// Тренировочное/тестовое сообщение - не должно обрабатываться системой
        /// </summary>
        public static readonly ProcessingType Training = new ProcessingType('T');

        /// <summary>
        /// Сообщение отправлено с целью отладки
        /// </summary>
        public static readonly ProcessingType Debugging = new ProcessingType('D');

        /// <summary>
        /// Сообщение с данными контроля качества
        /// </summary>
        public static readonly ProcessingType QualityControl = new ProcessingType('Q');

        private readonly char processingID;

        private ProcessingType(char processingID)
        {
            this.processingID = processingID;
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is ProcessingType processingType)
                return this.processingID == processingType.processingID;
            return false;
        }

        /// <inheritdoc/>
        public override int GetHashCode() => processingID.GetHashCode();
        
        public static bool operator ==(ProcessingType left, ProcessingType right) => left.processingID == right.processingID;

        public static bool operator !=(ProcessingType left, ProcessingType right) => !(left == right);

        public static ProcessingType Parse(char input) => input switch
        {
            'P' => Production,
            'T' => Training,
            'D' => Debugging,
            'Q' => QualityControl,
            _ => throw new ArgumentException("Processing type ID not recognized")
        };
    }
}
