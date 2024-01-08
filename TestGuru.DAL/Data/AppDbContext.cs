using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TestGuru.Domain.Entities;

namespace TestGuru.DAL.Data
{
    public class AppDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Test> Tests { get; set; }
        public DbSet<TestCollection> TestCollections { get; set; }
        public DbSet<SingleChoiceQuestion> SingleChoiceQuestions { get; set; }
        public DbSet<MultipleChoiceQuestion> MultipleChoiceQuestions { get; set; }
        public DbSet<MatchingQuestion> MatchingQuestions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<AccessControlEntry> AccessControlEntries { get; set; }
        public DbSet<AnswerVisibilityPolicy> AnswerVisibilityPolicies { get; set; }
        public DbSet<TestAttempt> TestAttempts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<TestTaker> TestTakers { get; set; }
        public DbSet<Creator> Creators { get; set; }
        public DbSet<Group> Groups { get; set; }
         
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Question>()
                .HasDiscriminator<string>("QuestionType")
                .HasValue<SingleChoiceQuestion>("SingleChoice")
                .HasValue<MultipleChoiceQuestion>("MultipleChoice")
                .HasValue<MatchingQuestion>("Matching");

            // Answer to Question relationship
            modelBuilder.Entity<Answer>()
                .HasOne(a => a.Question)
                .WithMany(q => q.Answers)
                .HasForeignKey(a => a.QuestionId);

            // Category to Test relationship
            modelBuilder.Entity<Category>()
                .HasOne(c => c.Test)
                .WithMany(t => t.Categories)
                .HasForeignKey(c => c.TestId);

            // Category to Question relationship
            modelBuilder.Entity<Question>()
                .HasOne(q => q.Category)
                .WithMany(c => c.Questions)
                .HasForeignKey(q => q.CategoryId);

            // Test to Question relationship
            modelBuilder.Entity<Question>()
                .HasOne(q => q.Test)
                .WithMany(t => t.Questions)
                .HasForeignKey(q => q.TestId);

            // TestCollection to Test relationship
            modelBuilder.Entity<Test>()
                .HasOne(t => t.TestCollection)
                .WithMany(tc => tc.Tests)
                .HasForeignKey(t => t.TestCollectionId);


            //------------------new changes will need to be considered----------------------------------------

            modelBuilder.Entity<TestAttempt>()
                .HasOne(ta => ta.TestTaker)
                .WithMany(tt => tt.TestAttempts)
                .HasForeignKey(ta => ta.TestTakerId);

            modelBuilder.Entity<TestAttempt>()
                .HasOne(ta => ta.Test)
                .WithMany(t => t.TestAttempts)
                .HasForeignKey(ta => ta.TestId);

            modelBuilder.Entity<AccessControlEntry>()
                .HasOne(ace => ace.Test)
                .WithMany(t => t.AccessControlEntries)
                .HasForeignKey(ace => ace.TestId);

            modelBuilder.Entity<Test>()
                .HasOne(t => t.Creator)
                .WithMany(c => c.CreatedTests)
                .HasForeignKey(t => t.CreatorId)
                .OnDelete(DeleteBehavior.Cascade); 

            modelBuilder.Entity<TestCollection>()
                .HasOne(tc => tc.Creator)
                .WithMany(c => c.TestCollections)
                .HasForeignKey(tc => tc.CreatorId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}