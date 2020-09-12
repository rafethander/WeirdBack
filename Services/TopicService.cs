using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeirdBack.Dtos;
using WeirdBack.Models;

namespace WeirdBack.Services
{
    public interface ITopicService
    {
        Task<List<TopicGetDto>> Get();
    }
    public class TopicService : ITopicService
    {
        private readonly WeirdBackDbContext _context;
        public TopicService(WeirdBackDbContext context)
        {
            _context = context;
        }
        public async Task<List<TopicGetDto>> Get()
        {
            var entities = await (from t in _context.Topic
                                  select new TopicGetDto
                                  {
                                      Content = t.Content,
                                      Header = t.Header
                                  }).ToListAsync();

            return entities;
        }
    }
}
