// ==================================================
// Storage Repository Factory Interface
// ==================================================

namespace CloudAgnosticStorageAPI.Interface
{
    public interface IStorageRepositoryFactory
    {
        public IStorageRepository GetStorgeRepository(string repostory);
    }
}
