namespace DataAccessLayer
{
    public interface IDataStoreContextFactory<T> where T : IDataStoreContext
    {
        T CreateDataStoreContext();
    }
}
