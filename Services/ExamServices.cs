using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeirdBack.Dtos;
using WeirdBack.Helper;
using WeirdBack.Models;

namespace WeirdBack.Services
{
    public interface IExamService
    {
        Task<ApiResults> Add(ExamAddDto model);
        Task<List<ExamGetDto>> Get();
        Task<ApiResults> Delete(Guid id);
        Task<TopicGetDto> GetWithId(Guid id);
    }
    public class ExamServices : IExamService
    {
        private readonly WeirdBackDbContext _context;
        public ExamServices(WeirdBackDbContext context)
        {
            _context = context;
        }
        public async Task<ApiResults> Add(ExamAddDto model)
        {
            var entityExam = new Exam
            {
                ExamId = Guid.NewGuid(),
                IsCreated = DateTime.Now
            };

            entityExam.Name = model.Name;
            await _context.Exam.AddAsync(entityExam);

            foreach (var question in model.Questions)
            {
                var entityQuestion = new Question
                {
                    QuestionId = Guid.NewGuid(),
                    IsCreated = DateTime.Now
                };
                entityQuestion.QuestionSentence = question.QuestionSentence;
                entityQuestion.AnswerA = question.AnswerA;
                entityQuestion.AnswerB = question.AnswerB;
                entityQuestion.AnswerC = question.AnswerC;
                entityQuestion.AnswerD = question.AnswerD;
                entityQuestion.CorrectAnswer = question.CorrectAnswer;
                entityQuestion.Exam = entityExam;

                await _context.Question.AddAsync(entityQuestion);

            }


            await _context.SaveChangesAsync();

            return new ApiResults { Data = entityExam, Message = ApiResultMessages.Ok };
        }

        public async Task<ApiResults> Delete(Guid id)
        {
            var entity = await _context.Exam.Where(x => x.IsDeleted != true && x.ExamId == id).FirstOrDefaultAsync();

            if (entity == null)
                return new ApiResults { Data = id, Message = ApiResultMessages.ExW001 };

            entity.IsDeleted = true;

            await _context.SaveChangesAsync();

            return new ApiResults { Data = entity, Message = ApiResultMessages.Ok };
        }

        public async Task<List<ExamGetDto>> Get()
        {
            var entities = await (from e in _context.Exam
                                  where (e.IsDeleted != true)
                                  select new ExamGetDto
                                  {
                                      ExamId = e.ExamId,
                                      Name = e.Name,
                                      IsCreated = e.IsCreated,
                                      IsCreatedString = e.IsCreatedString
                                  }).ToListAsync();

            return entities;
        }



        public async Task<TopicGetDto> GetWithId(Guid id)
        {
            var entities = await _context.Exam.Where(x => !x.IsDeleted && x.ExamId == id).FirstOrDefaultAsync();


            var topicEntity = await (from t in _context.Topic
                                     where (t.Header == entities.Name)
                                     select new TopicGetDto
                                     {
                                         Header = t.Header,
                                         Content = t.Content
                                     }).FirstOrDefaultAsync();

            return topicEntity;




        }
    }
}
