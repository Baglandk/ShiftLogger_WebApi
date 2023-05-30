using System;
using Microsoft.EntityFrameworkCore;
using ShiftLogger.Models;

namespace ShiftLogger.Data
{
    public class shiftLoggerContext : DbContext
    {
        public shiftLoggerContext(DbContextOptions<shiftLoggerContext> options) : base(options)
        {
        }
        public DbSet<shiftLogger> Items { get; set; }
    }
}

