using System;
using System.Threading.Tasks;
using ShopApp.Helpers;
using ShopApp.Queries;

namespace ShopApp.Main
{
    public class Program
    {
        public Program()
        {
        }

        public static async Task Main(string[] args)
        {
            await using (var context = new ContextFactory().CreateDbContext(args))
            {
                await new OnInitialize(context).Initialize();

                await new Queries.Queries(context).FirstQuery();
                Console.WriteLine();
                await new Queries.Queries(context).SecondQuery();
                Console.WriteLine();
                await new Queries.Queries(context).ThirdQuery();
            }
        }
    }
}
