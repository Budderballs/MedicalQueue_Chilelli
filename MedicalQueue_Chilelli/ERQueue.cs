using System.Collections.Generic;
using System.Linq;

namespace MedicalQueue_Chilelli
{
    class ERQueue
    {
        private List<Patient> queuedPatients = new List<Patient>();
        public int Enqueue(Patient newPerson) // Returns the number of patients in the queue after adding, or, if an error occurred, returned a -1
        {
            if (limitSize() >= 13)
            {
                return -1;
            }
            else
            {
                queuedPatients.Add(newPerson);
                List<Patient> sortedPatients = queuedPatients.OrderBy(sorted => sorted.prio).ToList();
                queuedPatients = sortedPatients;
                return limitSize();
            }
        }
        public string Dequeue() // Returns a queue item which should be shown to the user
        {
            if (limitSize() <= 0)
            {
                return Words.incorrect;
            }
            else
            {
                string beingRemoved = queuedPatients.First().name;
                queuedPatients.RemoveAt(0);
                return beingRemoved;
            }
        }
        override public string ToString() // Returns a list of users/priorities and their position in the queue
        {
            string returnList = "";
            foreach (Patient p in queuedPatients)
            {
                returnList += p.name + " " + p.prio + "\n";
            }
            return returnList;
        }
        public int limitSize()
        {
            return queuedPatients.Count;
        }
    }
}