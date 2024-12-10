using Domain.TransferredFiles;

namespace App.TransferredFiles
{
    public class TransferredFileService(ITransferredFileRepo transferredFileRepo) : ITransferredFileService
    {
        public async Task<ErrorOr<TransferredFile>> CreateAsync(string fileName, string HHAXDocID)
        {
            //Create valid TransferredFile object
            ErrorOr<TransferredFile> transferredFile = TransferredFile.Create(fileName, HHAXDocID);

            if (transferredFile.IsError)
            {
                return transferredFile.Errors;
            }

            await transferredFileRepo.AddAsync(transferredFile.Value);

            //await savechanges 

        }

        public Task<ErrorOr<TransferredFile>> GetAsync(Guid transferredFileId)
        {
            throw new NotImplementedException();
        }

        public Task<ErrorOr<List<TransferredFile>>> GetListAsync()
        {
            throw new NotImplementedException();
        }

    }
}
