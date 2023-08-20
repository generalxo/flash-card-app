using flash_card_app.Models;
using SQLite;

namespace flash_card_app.Services
{
    public class DbContext
    {
        private SQLiteConnection conn;
        string _dbPath;

        public string StatusMessage { get; set; }

        // TODO: Add variable for the SQLite connection

        private void Init()
        {
            if (conn != null)
                return;

            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<CollectionModel>();
        }

        public DbContext(string dbPath)
        {
            _dbPath = dbPath;
        }

        public void AddNewCollection(string name)
        {
            int result = 0;
            try
            {
                Init();

                // basic validation to ensure a name was entered
                if (string.IsNullOrEmpty(name))
                    throw new Exception("Valid name required");

                // TODO: Insert the new person into the database
                result = conn.Insert(new CollectionModel { Name = name });

                StatusMessage = string.Format("{0} record(s) added (Name: {1})", result, name);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", name, ex.Message);
            }

        }

        public List<CollectionModel> GetAllCollections()
        {
            // TODO: Init then retrieve a list of Person objects from the database into a list
            try
            {
                Init();
                return conn.Table<CollectionModel>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<CollectionModel>();
        }


    }
}
