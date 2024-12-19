using App.TransferredFiles;

namespace API.TransferredFiles
{
    public class TransferredFilesController : ApiController
    {
        private readonly ITransferredFileService _transferredFileService;
        public TransferredFilesController(ITransferredFileService transferredFileService)
        {
            _transferredFileService = transferredFileService;
        }
    }
}
