using System;
using System.Collections.Generic;
using System.Text;

namespace LIS2A.Models
{
    public struct PatientRecord
    {
        public RecordType RecordTypeID => RecordType.PatientIdentifying;
        public int SequenceNumber { get; private set; }
        public string PracticeID { get; private set; }
        public string LaboratoryID { get; private set; }
        public string ID3 { get; private set; }
        public string Name { get; private set; }
        public string MothersMaidenName { get; private set; }
    }
}
