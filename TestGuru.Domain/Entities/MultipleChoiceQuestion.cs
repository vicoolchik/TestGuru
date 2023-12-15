namespace TestGuru.Domain.Entities
{
    public class MultipleChoiceQuestion : Question
    {
        public override bool ValidateAnswer(Answer answer)
        {
            throw new NotImplementedException();
        }
    }
}
