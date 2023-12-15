namespace TestGuru.Domain.Entities
{
    public class SingleChoiceQuestion : Question
    {
        public override bool ValidateAnswer(Answer answer)
        {
            throw new NotImplementedException();
        }
    }
}
