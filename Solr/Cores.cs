using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Solr
{
    public class Core
    {
        public int CoreId { get; set; }
        public string Nome { get; set; }

        public List<Core> ListaCores()
        {
            return new List<Core> {
                new Core{ CoreId = 1, Nome = "Core1" },
                new Core{ CoreId = 2, Nome = "Core2" },
                new Core{ CoreId = 3, Nome = "Core3" }
            };
        }

    }

    public enum CoresId
    {
        Core1 = 1,
        Core2 = 2,
        Core3 = 3
    }
}