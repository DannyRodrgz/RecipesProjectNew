using System;
using System.Collections.Generic;
using System.Text;

namespace Recipes.Model
{
    public class Result
    {
        public string q { get; set; }
        public int from { get; set; }
        public int to { get; set; }
        public Params @params { get; set; }
        public bool more { get; set; }
        public int count { get; set; }
        public List<Hit> hits { get; set; }
    }
}
