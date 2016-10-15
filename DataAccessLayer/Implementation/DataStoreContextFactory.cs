namespace DataAccessLayer.Implementation
{
    public class DataStoreContextFactory : IDataStoreContextFactory<IDataStoreContext>
    {
        public IDataStoreContext CreateDataStoreContext()
        {
            return new PresentationJsonFileContext(ConnectionString);
        }

        //TODO: GET IT FROM CONFIG FILE
        public string ConnectionString { get; set; } = "";
    }
}
