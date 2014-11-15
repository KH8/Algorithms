using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCCs
{
    public class Vertex
    {
        public int Id;
        public Boolean IsExplored;
        public int LeaderId;
        public Collection<int> Edges;
        public int FinishingTime;

        public Vertex(int id)
        {
            Id = id;
            IsExplored = false;
            LeaderId = 0;
            Edges = new Collection<int>();
            FinishingTime = 0;
        }
    }
}
