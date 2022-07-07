using System.Reflection;
using Caffe.Models;
using Microsoft.EntityFrameworkCore;

namespace Caffe;

public class CaffeContext : DbContext
{
    public DbSet<Burger> Burgers { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("FileName=Burgers", option =>
        {
            option.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
        });
            
        base.OnConfiguring(optionsBuilder);
    }    
}