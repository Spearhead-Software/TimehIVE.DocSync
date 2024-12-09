
namespace Domain.TransferredFiles
{
    public class TransferredFile : BaseEntity
    {
        public string FileName { get; set; } = string.Empty;
        public string HHAXDocId { get; set; } = string.Empty;


        public static ErrorOr<TransferredFile> Create(string fileName, string HHAXDocId)
        {
            TransferredFile transferredFile = new();

            ErrorOr<Success> fileNameRes = transferredFile.SetFileName(fileName);
            if (fileNameRes.IsError) return fileNameRes.Errors;

            ErrorOr<Success> docIdRes = transferredFile.SetHHAXDocId(HHAXDocId);
            if(docIdRes.IsError) return docIdRes.Errors;

            return transferredFile;
        }

        private ErrorOr<Success> SetHHAXDocId(string docId)
        {
            HHAXDocId = docId;
            return Result.Success;
        }

        private ErrorOr<Success> SetFileName(string fileName)
        {
            if (!fileName.ToLower().EndsWith(".pdf"))
            {
                return TransferredFileErrors.FileTypeMustBePDF;
            }

            FileName = fileName;
            return Result.Success;
        }


        private TransferredFile() { }
    }
}
