using Domain.TransferredFiles;

namespace App.TransferredFiles
{
    public interface ITransferredFileService
    {
        Task<ErrorOr<TransferredFile>> CreateAsync(string fileName, string HHAXDocID);

        Task<ErrorOr<TransferredFile>> GetAsync(Guid transferredFileId);

        //TODO filters
        Task<ErrorOr<List<TransferredFile>>> GetListAsync();
    }
}
