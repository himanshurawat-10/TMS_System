using TMS.Context;
using TMS.Interface;
using TMS.Models;

namespace TMS.Repository
{
    public class RequestRepository : IRequest
    {
        MyDBContext _db;

        public RequestRepository(MyDBContext db)
        {
            _db = db;
        }

        public void Accept(int id)
        {
            var obj = _db.Requests.FirstOrDefault(x => x.RequestId == id);

            if (obj != null)
            {
                obj.Status = "Accepted";
                _db.SaveChanges();
                Console.WriteLine("making changes");
            }

           // Console.WriteLine("Changes done..");
            
        }

        public void Reject(int id)
        {
            var obj = _db.Requests.FirstOrDefault(x => x.RequestId == id);

            if (obj != null)
            {
                obj.Status = "Rejected";
                _db.SaveChanges();
                Console.WriteLine("making changes");
            }

            // Console.WriteLine("Changes done..");

        }

        public Request Create(Request request)
        {
            _db.Add(request);
            _db.SaveChanges();
            return request;
        }

        public List<RequestViewModel> GetBatches()
        {
            throw new NotImplementedException();
        }

        public List<RequestViewModel> GetReqData()
        {
            var list = (
           from request in _db.Requests
           join batch in _db.Batches 
           on  request.batch.BatchId equals batch.BatchId
           join user in _db.Users 
           on request.user.UId equals user.UId
         
           select new RequestViewModel
           {
               Id = request.RequestId,
               UserName = user.Name,
               BatchName = batch.BatchName,
               Trainer = batch.Trainer,
               CourseName = batch.Course.CourseName,
               Description = batch.Course.Description,
               Duration = batch.Course.Duration,
               Status = request.Status,
           }).ToList();
            return list;

         //   throw new NotImplementedException();
        }
    }
}
