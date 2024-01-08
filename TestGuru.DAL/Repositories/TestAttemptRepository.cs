using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TestGuru.DAL.Data;
using TestGuru.DAL.Repositories.Interfaces;
using TestGuru.Domain.Entities;

namespace TestGuru.DAL.Repositories
{
    public class TestAttemptRepository : GenericRepository<TestAttempt>, ITestAttemptRepository
    {
        public TestAttemptRepository(AppDbContext context, ILogger<TestAttemptRepository> logger)
           : base(context, logger)
        {
        }

        public async Task StartAttempt(Guid attemptId)
        {
            var attempt = await _context.TestAttempts
                .Include(ta => ta.TestTaker)
                .Include(ta => ta.Test)
                .FirstOrDefaultAsync(ta => ta.Id == attemptId);

            if (attempt == null)
            {
                throw new InvalidOperationException("Attempt not found.");
            }

            if (attempt.Status == Status.Active || attempt.Status == Status.Paused)
            {
                throw new InvalidOperationException("Attempt is already started or paused.");
            }

            // Find the number of attempts already made for this test by this test taker
            int previousAttemptsCount = await _context.TestAttempts
                .CountAsync(ta => ta.TestId == attempt.TestId && ta.TestTakerId == attempt.TestTakerId);

            // Set the attempt number to one more than the number of previous attempts
            attempt.AttemptNumber = previousAttemptsCount + 1;

            attempt.StartTime = DateTime.UtcNow;
            attempt.Status = Status.Active;

            await _context.SaveChangesAsync();
        }

        public async Task<bool> EndAttempt(Guid attemptId)
        {
            var attempt = await _context.TestAttempts.FindAsync(attemptId);
            if (attempt == null)
            {
                throw new InvalidOperationException("Attempt not found.");
            }

            if (attempt.Status != Status.Active)
            {
                throw new InvalidOperationException("Attempt is not active.");
            }

            attempt.EndTime = DateTime.UtcNow;
            attempt.Duration += DateTime.UtcNow - attempt.StartTime;
            attempt.Status = Status.Completed;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> PauseAttempt(Guid attemptId)
        {
            var attempt = await _context.TestAttempts.FindAsync(attemptId);
            if (attempt == null)
            {
                throw new InvalidOperationException("Attempt not found.");
            }

            if (attempt.Status != Status.Active)
            {
                throw new InvalidOperationException("Attempt is not active.");
            }

            attempt.EndTime = DateTime.UtcNow;
            attempt.Duration += DateTime.UtcNow - attempt.StartTime;
            attempt.Status = Status.Paused;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ResumeAttempt(Guid attemptId)
        {
            var attempt = await _context.TestAttempts.FindAsync(attemptId);
            if (attempt == null)
            {
                throw new InvalidOperationException("Attempt not found.");
            }

            if (attempt.Status != Status.Paused)
            {
                throw new InvalidOperationException("Attempt is not paused.");
            }

            attempt.StartTime = DateTime.UtcNow;
            attempt.EndTime = null;
            attempt.Status = Status.Active;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> SubmitResponse(Guid attemptId, Guid questionId, Answer answer)
        {
            var attempt = await _context.TestAttempts
                .Include(ta => ta.Responses)
                .FirstOrDefaultAsync(ta => ta.Id == attemptId);

            if (attempt == null)
            {
                throw new InvalidOperationException("Attempt not found.");
            }

            var existingAnswer = attempt.Responses.FirstOrDefault(ans => ans.QuestionId == questionId);
            if (existingAnswer != null)
            {
                _context.Answers.Remove(existingAnswer);
            }

            answer.QuestionId = questionId;
            attempt.Responses.Add(answer);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<float> CalculateScore(Guid attemptId)
        {
            var attempt = await _context.TestAttempts
                .Include(ta => ta.Responses)
                .Include(ta => ta.Test)
                .ThenInclude(test => test.Questions)
                .FirstOrDefaultAsync(ta => ta.Id == attemptId);

            if (attempt == null)
            {
                throw new InvalidOperationException("Test attempt not found.");
            }

            int totalQuestions = attempt.Test.TotalQuestionsCount;
            int correctAnswersCount = attempt.Responses.Count(a => a.IsCorrect);
            int incorrectAnswersCount = attempt.Responses.Count(a => !a.IsCorrect);
            int skippedAnswersCount = totalQuestions - attempt.Responses.Count;

            float score = totalQuestions > 0 ? ((float)correctAnswersCount / totalQuestions) * 100 : 0;

            attempt.CorrectAnswersCount = correctAnswersCount;
            attempt.IncorrectAnswersCount = incorrectAnswersCount;
            attempt.SkippedAnswersCount = skippedAnswersCount;
            attempt.Score = score;
            attempt.IsSuccessful = score >= attempt.Test.MinimumPassingScore;

            await _context.SaveChangesAsync();

            return score;
        }

        public async Task<bool> IsTimeExceeded(Guid attemptId)
        {
            var attempt = await _context.TestAttempts
                .Include(a => a.Test)
                .FirstOrDefaultAsync(a => a.Id == attemptId);

            if (attempt == null)
            {
                throw new InvalidOperationException("Attempt not found.");
            }

            // If there's no time limit set for the test, then time can't be exceeded.
            if (!attempt.Test.Duration.HasValue)
            {
                return false;
            }

            TimeSpan activeDuration = attempt.Duration;
            if (attempt.Status == Status.Active)
            {
                activeDuration += DateTime.UtcNow - attempt.StartTime;
            }

            // Safely handle the nullable TimeSpan using the Value property
            TimeSpan testDurationLimit = attempt.Test.Duration.Value;
            return activeDuration > testDurationLimit;
        }

    }
}
