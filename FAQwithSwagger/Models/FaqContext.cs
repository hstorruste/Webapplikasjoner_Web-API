namespace Nettbutikk_FAQ.Models
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;

    public class FaqContext : DbContext
    {
       
        public FaqContext()
            : base("name=FaqNettbutikk")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        
        public DbSet<Kategorier> Kategorier { get; set; }
        public DbSet<Faqs> Faqs { get; set; }
        public DbSet<Questions> Questions { get; set; }
    }


    public class Kategorier
    {
        public int Id { get; set; }
        public string Navn { get; set; }

        public virtual List<Faqs> Faqs { get; set; }
    }

    public class Faqs
    {
        public int Id { get; set; }
        public string Sporsmal { get; set; }
        public string Svar { get; set; }

        public virtual Kategorier Kategori { get; set; }
    }

    public class Questions
    {
        public int Id { get; set; }
        public DateTime Dato { get; set; }
        public string Epost { get; set; }
        public string Sporsmal { get; set; }

        public virtual Kategorier Kategori { get; set; }
    }
}