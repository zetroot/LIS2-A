using System;
using System.Collections.Generic;
using System.Text;

namespace LIS2A.Models
{
    public struct PatientRecord
    {
        public RecordType RecordTypeID => RecordType.PatientIdentifying;
        public int SequenceNumber { get; }
        public string PracticeID { get; }
        public string LaboratoryID { get; }
        public string ID3 { get; }
        public string Name { get; }
        public string MothersMaidenName { get; }
        public DateTime Birthdate { get; }
        public PatientSex Sex { get; } 
        public string RaceEthnicOrigin { get; }
        public string Address { get; }
        public string Reserved0 { get; }
        public string Telephone { get; }
        public string PhysicianID { get; }
        public string Special1 { get; }
        public string Special2 { get; }
        public string Height { get; }
        public string Weight { get; }
        public string Diagnosis { get; }
        public string ActiveMedications { get; }
        public string Diet { get; }
        public string PracticeField1 { get; }
        public string PracticeField2 { get; }
        public string AdmissionDischarge { get; }
        public string AdmissionStatus { get; }
        public string Location { get; }
        public string NatureOfAltDiagnosticCode { get; }
        public string AltDiagnosticCode { get; }
        public string Religion { get; }
        public string MartialStatus { get; }
        public string IsolationStatus { get; }
        public string Language { get; }
        public string HospitalService { get; }
        public string HospitalInstitution { get; }
        public string DosageCategory { get; }



    }
}
