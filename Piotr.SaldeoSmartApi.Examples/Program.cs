using System.Threading.Tasks;

namespace Piotr.SaldeoSmartApi.Examples
{
    public static class Program
    {
        static async Task Main(string[] args)
        {
            await new CompanyListVersion0().Run();
            await new DocumentDimensionMergeVersion0().Run();
            await new DocumentListVersion21().Run();
            await new DocumentSearchVersion21().Run();
        }
    }
}
