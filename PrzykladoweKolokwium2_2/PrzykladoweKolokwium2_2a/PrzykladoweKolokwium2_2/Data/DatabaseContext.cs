using Microsoft.EntityFrameworkCore;
using PrzykladoweKolokwium2_2.Models;

namespace PrzykladoweKolokwium2_2.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Procedure> Procedures { get; set; }
        public DbSet<AnimalClass> AnimalClasses { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<ProcedureAnimal> ProcedureAnimals { get; set; }
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        protected DatabaseContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Owner>().HasData(new List<Owner>
            {
                new Owner {
                    ID = 1,
                    FirstName = "Jan",
                    LastName = "Kowalski"
                },
                new Owner {
                    ID = 2,
                    FirstName = "Anna",
                    LastName = "Nowak"
                }
            });

            modelBuilder.Entity<AnimalClass>().HasData(new List<AnimalClass>()
            {
                new AnimalClass {
                    ID = 1,
                    Name = "Mammal"
                },
                new AnimalClass {
                    ID = 2,
                    Name = "Bird"
                }
            });

            modelBuilder.Entity<Procedure>().HasData(new List<Procedure>()
            {
                new Procedure
                {
                    ID = 1,
                    Name = "Endoscopy",
                    Description = "Lorem ipsum ..."
                },
                new Procedure
                {
                    ID = 2,
                    Name = "Cholecystectomy",
                    Description = "Lorem ipsum ..."
                }
            });

            modelBuilder.Entity<Animal>().HasData(new List<Animal>()
            {
                new Animal
                {
                    ID = 1,
                    Name = "AnimalName",
                    AdmissionDate = DateTime.Parse("2023-05-13"),
                    OwnerID = 1,
                    AnimalClassID = 1
                }
            });

            modelBuilder.Entity<ProcedureAnimal>().HasData(new List<ProcedureAnimal>()
            {
                new ProcedureAnimal
                {
                    ProcedureID = 1,
                    AnimalID = 1,
                    Date = DateTime.Parse("2023-05-14")
                },
                new ProcedureAnimal
                {
                    ProcedureID = 2,
                    AnimalID = 1,
                    Date = DateTime.Parse("2023-05-15")
                }
            });
        }
    }
}
