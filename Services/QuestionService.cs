using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeirdBack.Dtos;
using WeirdBack.Models;

namespace WeirdBack.Services
{
    public interface IQuestionService
    {
        Task<IList<QuestionGetDto>> Get(Guid id);
    }
    public class QuestionService : IQuestionService
    {
        private readonly WeirdBackDbContext _context;
        public QuestionService(WeirdBackDbContext context)
        {
            _context = context;
        }
        public async Task<IList<QuestionGetDto>> Get(Guid id)
        {
            var entity = await (from q in _context.Question
                                where (q.Exam.ExamId == id && q.Exam.IsDeleted!=true)
                                select new QuestionGetDto
                                {
                                    Exam = q.Exam,
                                    QuestionSentence=q.QuestionSentence,
                                    AnswerA=q.AnswerA,
                                    AnswerB=q.AnswerB,
                                    AnswerC=q.AnswerC,
                                    AnswerD=q.AnswerD,
                                    CorrectAnswer = q.CorrectAnswer
                                }).ToListAsync();

            return entity;
        }
    }
}
