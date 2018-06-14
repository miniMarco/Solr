using System.Collections.Generic;

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
                new Core{ CoreId = 3, Nome = "Core3" },
                new Core{ CoreId = 4, Nome = "Core4" },
                new Core{ CoreId = 5, Nome = "Core5" },
                new Core{ CoreId = 6, Nome = "Core6" },
                new Core{ CoreId = 7, Nome = "Core7" },
                new Core{ CoreId = 8, Nome = "Core8" },
                new Core{ CoreId = 9, Nome = "Core9" },
                new Core{ CoreId = 10, Nome = "Core10" },
                new Core{ CoreId = 11, Nome = "Core11" },
                new Core{ CoreId = 12, Nome = "Core12" }
            };
        }

    }

    public enum CoresId
    {
        Core1 = 1,
        Core2,
        Core3,
        Core4,
        Core5,
        Core6,
        Core7,
        Core8,
        Core9,
        Core10,
        Core11,
        Core12
    }
}