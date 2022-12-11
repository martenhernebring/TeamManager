using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamManager.API.Dtos
{
    public class PlayerDto
    {
        public string? Team { get; set; }
        public int Jersey { get; set; }
    }
}