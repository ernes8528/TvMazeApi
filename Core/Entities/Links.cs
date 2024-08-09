using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Links
    {
        public int Id { get; set; }
        public Self Self { get; set; }
        public PreviousEpisode PreviousEpisode { get; set; }
    }
}
