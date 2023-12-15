using Microsoft.EntityFrameworkCore;
using TestGuru.Domain.Entities;

namespace TestGuru.DAL.Data
{
    public class AppDbContext : DbContext
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
        }
    }
}