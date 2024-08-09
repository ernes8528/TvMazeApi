using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class WebChannel
    {
        public int Id { get; set; }
        public string name { get; set; }
        public Country? country { get; set; }
        public string? officialSite { get; set; }
    }
}
