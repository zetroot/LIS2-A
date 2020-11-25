namespace LIS2A.Models
{
    public struct PatientSex
    {
        public static PatientSex Male = new PatientSex('M');
        public static PatientSex Female = new PatientSex('F');
        public static PatientSex Undefined = new PatientSex('U');

        private readonly char sexChar;

        private PatientSex(char sexChar)
        {
            this.sexChar = sexChar;
        }

        public override bool Equals(object obj)
        {
            if (obj is PatientSex patientSex)
                return this.sexChar == patientSex.sexChar;
            return false;
        }

        public override int GetHashCode() => sexChar.GetHashCode();

        public static bool operator ==(PatientSex left, PatientSex right) => left.sexChar == right.sexChar;

        public static bool operator !=(PatientSex left, PatientSex right) => !(left == right);
    }
}