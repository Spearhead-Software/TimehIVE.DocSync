using App.TransferredFiles;
using Domain.TransferredFiles;
using Microsoft.AspNetCore.Mvc;

namespace API.TransferredFiles
{
    public class TransferredFilesController : ApiController
    {
        private readonly ITransferredFileService _transferredFileService;
        public TransferredFilesController(ITransferredFileService transferredFileService)
        {
            _transferredFileService = transferredFileService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTransferredFiles()
        {
           ErrorOr<List<TransferredFile>> transferredFilesResults = await _transferredFileService.GetListAsync();

            return transferredFilesResults.Match(
                files => Ok(new TransferredFilesResponse(
                    files.Select(file => new TransferredFileResponse(
                        file.Id,
                        file.HHAXDocId,
                        file.FileName
                    )).ToList())),
                Problem
            );
        }

        [HttpGet("/{id}")]
        public async Task<IActionResult> GetTransferredFile(Guid id)
        {
            ErrorOr<TransferredFile> transferredFileResult = await _transferredFileService.GetAsync(id);


            return transferredFileResult.Match(
                file => Ok(new TransferredFileResponse(file.Id, file.HHAXDocId, file.FileName)),
                Problem
            );
        }

    }
}
