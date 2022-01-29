using System;
using System.Threading.Tasks;
using ShopApp.Helpers;

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
            }
        }
    }
}
