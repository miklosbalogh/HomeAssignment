using System;

namespace DataAccessLayer.Implementation
{
    public class DataStoreContextFactory : IDataStoreContextFactory<IDataStoreContext>
    {
        public IDataStoreContext CreateDataStoreContext()
        {
            if (string.IsNullOrWhiteSpace(ConnectionString))
            {
                throw new ArgumentException($"Error in {nameof(CreateDataStoreContext)}: Connection String is null or empty");
            }
            return new PresentationJsonFileContext(ConnectionString);
        }

        public string ConnectionString { get; set; }
    }
}
