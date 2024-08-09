﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Core.Entities
{
    public class Show
    {
        /*[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]*/
        public int Id { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Language { get; set; }
        public List<string> Genres { get; set; }
        public string Status { get; set; }
        public int? Runtime { get; set; }
        public int? AverageRuntime { get; set; }
        public DateTime? Premiered { get; set; }
        public DateTime? Ended { get; set; }
        public string? OfficialSite { get; set; }
        public Schedule? Schedule { get; set; }
        public Rating? Rating { get; set; }
        public int? Weight { get; set; }
        public Network? Network { get; set; }
        public WebChannel? WebChannel { get; set; }
        public DvdCountry? DvdCountry { get; set; }
        public Externals? Externals { get; set; }
        public Image? Image { get; set; }
        public string Summary { get; set; }
        public long Updated { get; set; }
        public Links? Links { get; set; }
    }
}
