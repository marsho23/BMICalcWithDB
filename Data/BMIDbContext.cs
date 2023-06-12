using BMICalcWithJquery.Models;
using Microsoft.EntityFrameworkCore;

namespace BMICalcWithJquery.Data
{
    public class BMIDbContext:DbContext
    {
        public BMIDbContext(DbContextOptions<BMIDbContext> options) : base(options) { }

        public DbSet<BMIEntity> BMIs { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var connectingString = @"data source=DELLLAPTOP;initial catalog=BMIdb;integrated security=true";
        //    optionsBuilder.UseSqlServer(connectingString);
        //    base.OnConfiguring(optionsBuilder); 
        //}
    }
}
