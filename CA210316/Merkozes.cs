using System;

namespace CA210316
{
    class Merkozes
    {
        public string Hazai { get; set; }
        public string Idegen { get; set; }
        public int HazaiPont { get; set; }
        public int IdegenPont { get; set; }
        public string Helyszin { get; set; }
        public DateTime Idopont { get; set; }

        public Merkozes(string r)
        {
            var t = r.Split(';');
            Hazai = t[0];
            Idegen = t[1];
            HazaiPont = int.Parse(t[2]);
            IdegenPont = int.Parse(t[3]);
            Helyszin = t[4];
            Idopont = DateTime.Parse(t[5]);
        }
    }
}
