using System;
using Microsoft.EntityFrameworkCore;

namespace ShiftLogger.Models
{
    public class shiftLogger
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }
}

