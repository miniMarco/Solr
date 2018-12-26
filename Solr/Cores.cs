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
                new Core{ CoreId = 1, Nome = "Core_3" },
                new Core{ CoreId = 2, Nome = "Core_4" },
                new Core{ CoreId = 3, Nome = "Core_5" },
                new Core{ CoreId = 4, Nome = "Core_sem" },
                new Core{ CoreId = 13, Nome = "Core Original" },
                new Core{ CoreId = 14, Nome = "Core_sum" }
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
        Core12,
        Core13,
        Core14
    }
}