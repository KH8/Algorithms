using System;
using System.Collections.Generic;

namespace RandomizedContraction
{
    public class Vertex
    {
        public int Id { get; set; }
        public List<Vertex> EdgesList;

        public int NunberOfedges
        {
            get { return EdgesList.Count; }
        }

        public Vertex(int id)
        {
            Id = id;
            EdgesList = new List<Vertex>();
        }
    }
}
