using TMS.Models;

namespace TMS.Interface
{
    public interface IRequest
    {
        Request Create(Request request);
        List<RequestViewModel> GetReqData();
        void Accept(int id);
        void Reject(int id);
    }
}
