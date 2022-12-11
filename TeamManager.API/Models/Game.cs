using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamManager.API.Models
{
    public interface Game{
        public int Id { get; set; }
        public string? Team { get; set; }
        public DateTime Time { get; set; }
    }
}