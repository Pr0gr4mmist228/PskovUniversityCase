namespace PskovUniversityCase.DbEntities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DbEntitiesContext : DbContext
    {
        public DbEntitiesContext()
            : base("name=EntityConnection")
        {
        }

        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<Organization> Organization { get; set; }
        public virtual DbSet<OrganizationType> OrganizationType { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Vacancy> Vacancy { get; set; }
        public virtual DbSet<Employer> Employer { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<VacancyResponding> VacancyResponding { get; set; }
        public virtual DbSet<Summary> Summary { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrganizationType>()
    .HasMany(e => e.Organization)
    .WithOptional(e => e.OrganizationType)
    .HasForeignKey(e => e.TypeId);

            modelBuilder.Entity<Organization>()
                .HasMany(e => e.Vacancy)
                .WithRequired(e => e.Organization)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.User)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasOptional(e => e.Student)
                .WithRequired(e => e.User);
            
			modelBuilder.Entity<User>()
				.HasRequired<Employer>(u => u.Employer)
				.WithRequiredDependent(c => c.User);

           modelBuilder.Entity<Student>()
            .HasMany(e => e.Summary)
            .WithRequired(e => e.Student)
            .WillCascadeOnDelete(false);
        }
    }
}
