namespace TestGuru.Domain.Entities
{
    public class Creator : User
    {
        public virtual ICollection<Test> CreatedTests { get; set; }
        public virtual ICollection<TestCollection> TestCollections { get; set; }
    }
}
