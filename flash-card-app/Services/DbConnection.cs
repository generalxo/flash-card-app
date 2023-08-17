using flash_card_app.Models;
using SQLite;

namespace flash_card_app.Services
{
    public class DbConnection
    {
        string _dbPath;
        private static SQLiteConnection dbConnection;

        private void Init()
        {
            if (dbConnection is not null)
            {
                return;
            }
            dbConnection = new SQLiteConnection(_dbPath);

            dbConnection.CreateTable<Models.FlashCardModel>();
        }

        public string StatusMessage { get; set; }

        public DbConnection(string dbPath)
        {
            _dbPath = dbPath;
        }

        public void AddFlashCard(string question, string answer)
        {
            int result = 0;
            try
            {
                Init();

                // basic validation to ensure a name was entered
                if (string.IsNullOrEmpty(question) | string.IsNullOrEmpty(answer))
                    throw new Exception("Valid question & answer required");

                // TODO: Insert the new person into the database
                result = dbConnection.Insert(new FlashCardModel { Question = "test1", Answer = "1" });

                StatusMessage = string.Format($"{result} record(s) added (Question: {question}), (Answer:{answer})");
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format($"Failed to add entry. Error: {ex.Message}");
            }

        }

        public List<FlashCardModel> GetAllFlashCards()
        {
            try
            {
                Init();
                return dbConnection.Table<FlashCardModel>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format($"Failed to retrieve data. Error: {ex.Message}");
            }
            return new List<FlashCardModel>();

        }

    }
}
