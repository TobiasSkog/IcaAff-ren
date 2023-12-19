using IcaAffären.Application.Data;

namespace IcaAffären.Application
{
    internal class App
    {
        private DatabaseManager db { get; set; }
        public App()
        {
            db = new();
        }

        public void Run()
        {
            Console.WriteLine("Hämtar alla Avdelningar och Personal på Avdelningarna");
            db.GetAllAvdelningar();

            Console.WriteLine("Vilken avdelning vill du hämta information om:");
            var avdelningsNamnList = db.GetAllAvdelningsNamn();
            var avdelningsValDictionary = new Dictionary<string, string>();
            int counter = 1;
            foreach (var namn in avdelningsNamnList)
            {
                avdelningsValDictionary.Add(counter.ToString(), namn);
                Console.WriteLine($"{counter}) {namn}");
                counter++;
            }
            var val = Console.ReadLine();
            db.GetAllPersonalOnAvdelning(avdelningsValDictionary[val]);


        }
    }
}
