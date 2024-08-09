using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Schedule
    {
        public int Id { get; set; }
        public string Time { get; set; }
        public List<string> Days { get; set; }
    }
}
