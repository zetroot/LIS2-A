using System;
using System.Collections.Generic;
using System.Text;

namespace LIS2A.Models
{
    public readonly struct OrderRecord
    {
        public RecordType RecordTypeID => RecordType.TestOrder;
        public int SequenceNumber { get; }
        public string SpecimenID { get; }
        public string InstrumentSpecimenID { get; }
        public TestID UniversalTestID { get; }
        public string Priority { get; }
        public DateTimeField? OrderedAt { get; }
        public DateTimeField? CollectedAt { get; }
        public DateTimeField? CollectionEnd { get; }
        public string CollectionVolume { get; }
        public string CollectorID { get; }
        public ActionCode? ActionCode { get; }
        public string DangerCode { get; }
        public string ClinicalInformation { get; }
        public DateTimeField? ReceivedAt { get; }
        public SpecimenDescriptor? SpecimenDescriptor { get; }
        public string OrderingPhysician { get; }
        public string PhysicianTelephone { get; }
        public string UserField1 { get; }
        public string UserField2 { get; }
        public string LaboratoryField1 { get; }
        public string LaboratoryField2 { get; }
        public DateTimeField 
    }
}
