using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary.Utilities
{
    public class DataAccess : IDataAccess
    {
        ILogger _logger;
        public DataAccess(ILogger logger)
        {
            _logger = logger;
        }

        public void LoadData()
        {
            Console.WriteLine("Loading Data");
            _logger.Log("Loading data");
        }

        public void SaveData(string name)
        {
            Console.WriteLine($"Saving { name }");
            _logger.Log("Saving data");
        }
    }
}
