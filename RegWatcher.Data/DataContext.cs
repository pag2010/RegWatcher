using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegWatcher.Data
{
    public class DataContext : IdentityDbContext
    {
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ApplicationRole> ApplicationRoles { get; set; }
        public DbSet<FileExtension> FileExtensions { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Step> Steps { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<FormKind> FormKinds{get;set;}
        public DbSet<Company> Companies { get; set; }
        public DbSet<SafetyDeclaration> SafetyDeclarations { get; set; }
        public DbSet<GTS> GTSs { get; set; }
        public DbSet<DangerKind> DangerKinds { get; set; }
        public DbSet<Checking> Checkings { get; set; }
        public DbSet<CheckingKind> CheckingKinds { get; set; }
        public DbSet<CheckingResult> CheckingResults { get; set; }
        public DbSet<Act> Acts { get; set; }
        public DbSet<Prescription> Prescriptions { get; set;}

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
           
            builder.Entity<Document>()
               .HasIndex(d => d.Number).IsUnique();

            builder.Entity<File>()
                .HasIndex(f => f.Guid).IsUnique();

            builder.Entity<DocumentTag>()
                .HasKey(k => new { k.DocumentId, k.TagId });

            builder.Entity<DocumentTag>()
                .HasOne(dt => dt.Document)
                .WithMany(dt => dt.DocumentTags)
                .HasForeignKey(dt => dt.DocumentId);

            builder.Entity<DocumentTag>()
                .HasOne(dt => dt.Tag)
                .WithMany(dt => dt.DocumentTags)
                .HasForeignKey(dt => dt.TagId);
        }
    }
}
