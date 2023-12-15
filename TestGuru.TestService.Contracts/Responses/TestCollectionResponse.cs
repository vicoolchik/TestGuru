namespace TestGuru.TestService.Contracts.Responses
{
    public class TestCollectionResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<TestResponse> Tests { get; set; }
    }
}
