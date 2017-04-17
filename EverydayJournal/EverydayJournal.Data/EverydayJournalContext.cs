namespace EverydayJournal.Data
{
    using Models;
    using System.Data.Entity;

    public class EverydayJournalContext : DbContext
    {
        public EverydayJournalContext()
            : base("name=EverydayJournalContext")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<EverydayJournalContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>()
                .HasRequired(t => t.Date)
                .WithMany(d => d.Tasks)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Food>()
                .HasRequired(f => f.Date)
                .WithMany(d => d.Foods)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(p => p.Foods)
                .WithMany(f => f.People)
                .Map(av => av.ToTable("PeopleFoods")
                    .MapLeftKey("FoodId")
                    .MapRightKey("PeopleId"));

            modelBuilder.Entity<Person>()
                .HasMany(p => p.Tasks)
                .WithRequired(f => f.Person)
                .WillCascadeOnDelete(false);
        }

        public virtual DbSet<Person> People { get; set; }

        public virtual DbSet<Food> Foods { get; set; }

        public virtual DbSet<Task> Tasks { get; set; }

        public virtual DbSet<Date> Dates { get; set; }   

        public virtual DbSet<PhysicalCondition> PhysicalConditions { get; set; }

        public static EverydayJournalContext Create()
        {
            return new EverydayJournalContext();
        }
    }
}