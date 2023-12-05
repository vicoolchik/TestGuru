namespace TestGuruApi.Entities.DbSet
{
    public class MultipleChoiceQuestion : Question
    {
        public override bool ValidateAnswer(Answer answer)
        {
            throw new NotImplementedException();
        }
    }
}
