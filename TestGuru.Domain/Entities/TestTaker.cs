namespace TestGuru.Domain.Entities
{
    public class TestTaker : User
    {
        public virtual ICollection<Test> CompletedTests { get; set; }
        public virtual ICollection<Test> FavoriteTests { get; set; }
        public virtual ICollection<TestAttempt> TestAttempts { get; set; }
    }
}
