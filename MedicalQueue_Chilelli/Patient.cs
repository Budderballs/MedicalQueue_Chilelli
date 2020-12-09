namespace MedicalQueue_Chilelli
{
    class Patient
    {
        public int prio { get; }
        public string name { get; }

        public Patient(string name, int prio)
        {
            this.name = name;
            this.prio = prio;
        }
    }
}