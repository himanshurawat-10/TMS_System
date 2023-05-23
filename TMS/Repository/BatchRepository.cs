using System.Collections;
using TMS.Context;
using TMS.Interface;
using TMS.Models;

namespace TMS.Repository
{
    public class BatchRepository : IBatch
    {
        MyDBContext _db;
        public BatchRepository(MyDBContext db)
        {
            _db = db;
        }
        public Batch Create(Batch batch)
        {
            _db.Batches.Add(batch);
            _db.SaveChanges();
            return batch;
        }



        public int Edit(int id, Batch batch)
        {
            Batch obj = GetBatchById(id);
            if (obj != null)
            {
                foreach (Batch temp in _db.Batches)
                {
                    if (temp.BatchId == id)
                    {
                        temp.StartDate = batch.StartDate;
                        temp.BatchName = batch.BatchName;
                        temp.Trainer = batch.Trainer;
                      
                    }
                }
                _db.SaveChanges();
            }
            return 1;
        }

        public IEnumerable GetBatch()
        {
            return _db.Batches.ToList();
        }

        public Batch GetBatchById(int id)
        {
            return _db.Batches.FirstOrDefault(x => x.BatchId == id);
        }



        public List<BatchViewModel> GetBatches()
        {
            var list = (
            from batch in _db.Batches
            join course in _db.Courses
            on batch.Course.CourseId
            equals course.CourseId
            select new BatchViewModel
            {
                Id = batch.BatchId,
                BatchName = batch.BatchName,
                Trainer = batch.Trainer,
                CourseName = course.CourseName,
                StartDate = batch.StartDate,
                Description = course.Description,
                Duration = course.Duration
            }).ToList();
            return list;
            
        }

       
       

       
    }
}
