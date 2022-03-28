using com.mobiquity.packer.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace com.mobiquity.packer
{
    public class Packer
    {
        private readonly IDataParser _parser;
        private readonly ISolver _solver;

        public Packer(ISolver solver, IDataParser parser)
        {
            _parser = parser;
            _solver = solver;
        }

        public static string Pack(string filePath)
        {
            var provider = BuildServiceProvider();

            var packer = new Packer(provider.GetService<ISolver>(), provider.GetService<IDataParser>());
            return packer.PackInner(filePath);          
        }

        private string PackInner(string filePath)
        {            
            var data = _parser.Parse(filePath);
            return _solver.Solve(data);
        }

        private static ServiceProvider BuildServiceProvider()
        {
            var services = new ServiceCollection();
            services.AddTransient<ISolver, Solver>();
            services.AddTransient<IDataParser, DataParser>();
            services.AddTransient<IDataValidator, DataValidator>();
            services.AddTransient<IFileValidator, FileValidator>();
            services.AddTransient<IPresenter, Presenter>();

            return services.BuildServiceProvider();
        }
    }
}
