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

            await transferredFileRepo.CommitChangesAsync();

            return transferredFile;

        }

        public async Task<ErrorOr<TransferredFile>> GetAsync(Guid transferredFileId)
        {
            TransferredFile? transferredFile = await transferredFileRepo.GetByIdAsync(transferredFileId);
            if(transferredFile is null)
            {
                return Error.NotFound("Transferred File not found");
            }

            return transferredFile;
        }

        public async Task<ErrorOr<List<TransferredFile>>> GetListAsync()
        {
            List<TransferredFile>? transferredFiles = await transferredFileRepo.GetListAsync();
            
            //not an exception when there are none found, filters being added soon
            if(transferredFiles is null)
            {
                return new List<TransferredFile>();
            }

            return transferredFiles;
        }

    }
}
