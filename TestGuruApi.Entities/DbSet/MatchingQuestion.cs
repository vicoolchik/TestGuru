namespace TestGuruApi.Entities.DbSet
{
    public class MatchingQuestion : Question
    {
        public virtual ICollection<string> LeftColumn { get; set; } = new List<string>();
        public virtual ICollection<string> RightColumn { get; set; } = new List<string>();

        public override bool ValidateAnswer(Answer answer)
        {
            throw new NotImplementedException();
        }
    }
}
