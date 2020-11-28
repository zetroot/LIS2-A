using System;

namespace LIS2A.Models
{
    /// <summary>
    /// Сообщение с информацией о пациенте
    /// </summary>
    public readonly struct PatientRecord
    {
        /// <summary>
        /// Тип сообщения 
        /// </summary>
        public RecordType RecordTypeID => RecordType.PatientIdentifying;

        /// <summary>
        /// Последовательный номер пациента в сообщении
        /// </summary>
        public int SequenceNumber { get; }

        /// <summary>
        /// Идентификатор пациента в медицинской системе
        /// </summary>
        public string PracticeID { get; }

        /// <summary>
        /// Идентификатор пациента в лаборатории
        /// </summary>
        public string LaboratoryID { get; }

        /// <summary>
        /// Третий тип идентификатора
        /// </summary>
        public string ID3 { get; }

        /// <summary>
        /// Имя пациента
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Девичья фамилия матери пациента
        /// </summary>
        public string MothersMaidenName { get; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateField? Birthdate { get; }

        /// <summary>
        /// Пол пациента
        /// </summary>
        public PatientSex? Sex { get; }
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

        public static PatientRecord Parse(ReadOnlySpan<char> input, Delimiters delimiters)
        {
            if (input.Length < 3) throw new ArgumentException("Minimal patient record length is 3 chars");
            var seqNumber = int.Parse(input.GetField(delimiters.FieldDelimiter, 2));
            var practiceID = new string(input.GetField(delimiters.FieldDelimiter, 3));
            var labID = new string(input.GetField(delimiters.FieldDelimiter, 4));
            var id3 = new string(input.GetField(delimiters.FieldDelimiter, 5));
            var name = new string(input.GetField(delimiters.FieldDelimiter, 6));
            var mothersMaidenName = new string(input.GetField(delimiters.FieldDelimiter, 7));
            var birthdate = ParseBirthdate(input, delimiters);
            var patsex = ParseSex(input, delimiters);

            // TODO parse other fields

            return new PatientRecord(seqNumber, practiceID, labID, id3, name, mothersMaidenName, birthdate, patsex, null, null, null, null, null, null, null, null, null, null, null, null, null,null, null,null,null,null,null,null,null,null,null,null,null,null);
        }

        private static DateField? ParseBirthdate(ReadOnlySpan<char> input, Delimiters delimiters)
        {
            var bdField = input.GetField(delimiters.FieldDelimiter, 8);
            var birthdate = default(DateField?);
            if (!bdField.IsEmpty) birthdate = DateField.Parse(bdField);
            return birthdate;
        }

        private static PatientSex? ParseSex(ReadOnlySpan<char> input, Delimiters delimiters)
        {
            var sexfield = input.GetField(delimiters.FieldDelimiter, 9);
            if (sexfield.IsEmpty) return null;
            return sexfield[0] switch
            {
                'M' => PatientSex.Male,
                'm' => PatientSex.Male,
                'F' => PatientSex.Female,
                'f' => PatientSex.Female,
                'U' => PatientSex.Undefined,
                'u' => PatientSex.Undefined,
                _ => throw new ArgumentException("Unknown sex")
            };
        }

        internal PatientRecord(
            int sequenceNumber,
            string practiceID,
            string laboratoryID,
            string iD3,
            string name,
            string mothersMaidenName,
            DateField? birthdate,
            PatientSex? sex,
            string raceEthnicOrigin,
            string address,
            string reserved0,
            string telephone,
            string physicianID,
            string special1,
            string special2,
            string height,
            string weight,
            string diagnosis,
            string activeMedications,
            string diet,
            string practiceField1,
            string practiceField2,
            string admissionDischarge,
            string admissionStatus,
            string location,
            string natureOfAltDiagnosticCode,
            string altDiagnosticCode,
            string religion,
            string martialStatus,
            string isolationStatus,
            string language,
            string hospitalService,
            string hospitalInstitution,
            string dosageCategory)
        {
            SequenceNumber = sequenceNumber;
            PracticeID = practiceID;
            LaboratoryID = laboratoryID;
            ID3 = iD3;
            Name = name;
            MothersMaidenName = mothersMaidenName;
            Birthdate = birthdate;
            Sex = sex;
            RaceEthnicOrigin = raceEthnicOrigin;
            Address = address;
            Reserved0 = reserved0;
            Telephone = telephone;
            PhysicianID = physicianID;
            Special1 = special1;
            Special2 = special2;
            Height = height;
            Weight = weight;
            Diagnosis = diagnosis;
            ActiveMedications = activeMedications;
            Diet = diet;
            PracticeField1 = practiceField1;
            PracticeField2 = practiceField2;
            AdmissionDischarge = admissionDischarge;
            AdmissionStatus = admissionStatus;
            Location = location;
            NatureOfAltDiagnosticCode = natureOfAltDiagnosticCode;
            AltDiagnosticCode = altDiagnosticCode;
            Religion = religion;
            MartialStatus = martialStatus;
            IsolationStatus = isolationStatus;
            Language = language;
            HospitalService = hospitalService;
            HospitalInstitution = hospitalInstitution;
            DosageCategory = dosageCategory;
        }
    }
}
