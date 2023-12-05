using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestGuruApi.DataService.Data;
using TestGuruApi.DataService.Repositories.Interfaces;

namespace TestGuruApi.DataService.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext _context;
        private readonly ILogger _logger;

        public ITestRepository Tests { get; private set; }
        public ICategoryRepository Categories { get; private set; }
        public IQuestionRepository Questions { get; private set; }
        public ISingleChoiceQuestionRepository SingleChoiceQuestions { get; private set; }
        public IMultipleChoiceQuestionRepository MultipleChoiceQuestions { get; private set; }
        public IMatchingQuestionRepository MatchingQuestions { get; private set; }
        public IAnswerRepository Answers { get; private set; }
        public ITestCollectionRepository TestCollections { get; private set; }

        public UnitOfWork(
            AppDbContext context,
            ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("Logs");

            Tests = new TestRepository(_context, _logger);
            Categories = new CategoryRepository(_context, _logger);
            Questions = new QuestionRepository(_context, _logger);
            SingleChoiceQuestions = new SingleChoiceQuestionRepository(_context, _logger);
            MultipleChoiceQuestions = new MultipleChoiceQuestionRepository(_context, _logger);
            MatchingQuestions = new MatchingQuestionRepository(_context, _logger);
            Answers = new AnswerRepository(_context, _logger);
            TestCollections = new TestCollectionRepository(_context, _logger);
        }

        public async Task<bool> CompleteAsync()
        {
            var result = await _context.SaveChangesAsync();
            return result>0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
