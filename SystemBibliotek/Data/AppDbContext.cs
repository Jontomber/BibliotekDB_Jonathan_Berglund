using Microsoft.EntityFrameworkCore;
using SystemBibliotek.Models;

public class AppDbContext : DbContext
{
    public DbSet<Aurthor> Aurthors {get; set;}
    public DbSet<Book> Books {get; set;}
    public DbSet<BookAurthor> BookAurthors {get; set;}
    public DbSet<Loan> Loans {get; set;}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=SystemBiblotek;Trusted_Connection=True;");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookAurthor>()
            .HasKey(ba => new {ba.BookID, ba.AurthorID }); 

        modelBuilder.Entity<BookAurthor>()
            .HasOne(ba => ba.Book)
            .WithMany(ba => ba.BookAurthors)
            .HasForeignKey(ba => ba.BookID);
        
        modelBuilder.Entity<BookAurthor>()
            .HasOne(ba => ba.Aurthor)
            .WithMany(ba => ba.BookAurthors)
            .HasForeignKey(ba => ba.AurthorID);
        
        modelBuilder.Entity<Loan>()
            .HasKey(l => l.LoanID);
    }
}

