using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwesomeDelivery.Customers.Infrastructure.Persistence
{
    public class MongoDBOptions
    {
        public string Database { get; set; }
        public string ConnectionString { get; set; }
    }
}