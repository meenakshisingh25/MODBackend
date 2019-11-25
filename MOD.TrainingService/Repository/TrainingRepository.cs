using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MOD.TrainingService.Context;
using MOD.TrainingService.Models;

namespace MOD.TrainingService.Repository
{
    public class TrainingRepository : ITrainingRepository
    {
        private readonly TrainingServiceContext _context;

        public TrainingRepository(TrainingServiceContext context)
        {
            _context = context;
        }

        public List<Training> CompleteTraining(string Mentor_ID)
        {
            var obj = _context.Trainings.Where(s => s.Mentor_ID == Mentor_ID && s.Training_status == "complete").ToList();
            return obj;
        }

        public List<Training> CurrentTraining(string Mentor_ID)
        {
            var obj = _context.Trainings.Where(s => s.Mentor_ID == Mentor_ID && s.Training_status == "current").ToList();
            return obj;
        }

        public List<Training> UserCompleteTraining(string User_ID)
        {
            var obj = _context.Trainings.Where(s => s.User_ID == User_ID && s.Training_status == "complete").ToList();
            return obj;
        }

        public List<Training> UserCurrentTraining(string User_ID)
        {
            var obj = _context.Trainings.Where(s => s.User_ID == User_ID && s.Training_status == "current").ToList();
            return obj;
        }

        public IEnumerable<Training> GetAll()
        {
            return _context.Trainings.ToList();
        }

        public void Training_Add(Training item)
        {
            _context.Trainings.Add(item);
            _context.SaveChanges();
        }

        public void Training_Update(Training item)
        {
            _context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
