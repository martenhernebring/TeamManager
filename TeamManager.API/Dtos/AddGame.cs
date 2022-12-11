using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamManager.API.Dtos
{
    public class AddGame
    {
        public string? Team { get; set; }
        public DateTime Time { get; set; }
    }
}