using TMS.Models;

namespace TMS.Interface
{
    public interface IBatch
    {
        List<BatchViewModel> GetBatches();
        Batch Create(Batch batch);
        int Edit(int id, Batch batch);
        Batch GetBatchById(int id);

    }
}
