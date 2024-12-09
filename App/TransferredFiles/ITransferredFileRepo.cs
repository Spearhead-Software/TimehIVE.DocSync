using Domain.TransferredFiles;

namespace App.TransferredFiles
{
    public interface ITransferredFileRepo
    {
        Task AddAsync(TransferredFile file);

        Task AddCollectionAsync(List<TransferredFile> files);

        Task<TransferredFile?> GetByIdAsync(Guid id);

        Task<List<TransferredFile>?> GetListAsync();
    }
}
