using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Network
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Country? Country { get; set; }
        public string? OfficialSite { get; set; }


    }
}
