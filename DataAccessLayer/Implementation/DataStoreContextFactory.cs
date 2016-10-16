namespace DataAccessLayer.Implementation
{
    public class DataStoreContextFactory : IDataStoreContextFactory<IDataStoreContext>
    {
        public IDataStoreContext CreateDataStoreContext()
        {
            return new PresentationJsonFileContext(ConnectionString);
        }

        public string ConnectionString { get; set; }
    }
}
