namespace API.TransferredFiles
{
    public record TransferredFileResponse(Guid Id, string HHAXDocId, string FileName);
    public record TransferredFilesResponse(List<TransferredFileResponse> files);
}
