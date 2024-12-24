using App.TransferredFiles;
using Domain.TransferredFiles;
using Infra.Common;
using Infra.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infra.TransferredFiles
{
    public class TransferredFilesRepo : RepoBase, ITransferredFileRepo
    {
        private readonly AppDBContext _db;

        public TransferredFilesRepo(AppDBContext dbContext) : base(dbContext)
        {
            _db = dbContext;
        }

        public async Task AddAsync(TransferredFile file)
        {
            await _db.TransferredFiles.AddAsync(file);
        }

        public async Task AddCollectionAsync(List<TransferredFile> files)
        {
            await _db.TransferredFiles.AddRangeAsync(files);
        }

        public async Task<TransferredFile?> GetByIdAsync(Guid id)
        {
            return await _db.TransferredFiles.SingleAsync(tf => tf.Id == id);
        }

        public async Task<List<TransferredFile>?> GetListAsync()
        {
            return await _db.TransferredFiles.ToListAsync();
        }
    }
}
