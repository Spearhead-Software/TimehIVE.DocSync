namespace Domain.TransferredFiles
{
    internal class TransferredFileErrors : Errors<TransferredFile>
    {
        public static readonly Error FileTypeMustBePDF = Validation("File type must be PDF");
    }
}
