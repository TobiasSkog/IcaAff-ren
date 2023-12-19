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

        }
    }
}
