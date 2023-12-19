using IcaAffären.Application;

namespace IcaAffären
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Scaffold-DbContext "Server=BURKEN;Database=IcaAffären;Trusted_Connection=True;Encrypt=false" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
            // Scaffold-DbContext "Server=BURKEN;Database=IcaAffären;Trusted_Connection=True;Encrypt=false" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
            var affären = new App();
            affären.Run();


        }
    }
}
