using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomizedContraction
{
    class Vortex
    {
        public int Id { get; set; }
        public List<Vortex> EdgesList;

        public int NunberOfedges
        {
            get { return EdgesList.Count; }
        }

        public Vortex(int id)
        {
            Id = id;
            EdgesList = new List<Vortex>();
        }

        public void Contract(Vortex vortex)
        {
            
        }
    }
}
