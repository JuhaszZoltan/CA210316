using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA210316
{
    class Program
    {
        static void Main()
        {
            var merkozesek = new List<Merkozes>();

            //2. feladat ::: beolvasas
            var sr = new StreamReader(@"../../RES/eredmenyek.csv", Encoding.UTF8);
            sr.ReadLine();
            while (!sr.EndOfStream) merkozesek.Add(new Merkozes(sr.ReadLine()));
            sr.Close();

            //3. feladat ::: Real Madrid
            Console.WriteLine("3. feladat: Real Madrid: " +
                $"Hazai: {merkozesek.Count(x => x.Hazai == "Real Madrid")}, " +
                $"Idegen: {merkozesek.Count(x => x.Idegen == "Real Madrid")}");

            //4. feladat ::: Döntetlen
            Console.WriteLine("4. feladat: Volt döntetlen? " +
                $"{(merkozesek.Any(x => x.IdegenPont == x.HazaiPont) ? "Igen" : "Nem")}");

            //5. feladat ::: Barcelona
            Console.WriteLine("5. feladat: barcelonai csapat neve: " +
                $"{merkozesek.Find(x => x.Hazai.Contains("Barcelona")).Hazai}");

            //6. feladat ::: 2004-11-04 eredmenyek
            Console.WriteLine("6. feladat:");
            merkozesek.Where(x => x.Idopont == new DateTime(2004, 11, 21)).ToList()
                .ForEach(m => Console.WriteLine($"\t{m.Hazai} - {m.Idegen} ({m.HazaiPont}:{m.IdegenPont})"));

            //7. feladat ::: 20-bál több mérkőzéses stadionok
            Console.WriteLine("7. feladat: ");
            merkozesek.GroupBy(x => x.Helyszin)
                .Where(x => x.Count() > 20).ToList()
                .ForEach(x => Console.WriteLine($"\t{x.Key}: {x.Count()}"));

            Console.ReadKey();
        }
    }
}
