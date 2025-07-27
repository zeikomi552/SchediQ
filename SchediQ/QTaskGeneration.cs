using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchediQ
{
    public class QTaskGeneration : List<QTaskWorkerCollection>
    {
        public QTaskGeneration()
        {
        }
        public QTaskGeneration(List<QTaskWorkerCollection> collection) : base(collection)
        {
        }
    }
}
