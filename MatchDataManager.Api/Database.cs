using System.Data.SQLite;

namespace MatchDataManager.Api
{
    public class Database
    {
        public void CreateDatabase()
        {
            SQLiteConnection.CreateFile("MatchDataManagerDatabase.sqlite");
        }
        public void HandleDatabase()
        {
            SQLiteConnection dbConnection;
            dbConnection = new SQLiteConnection("Data Source= MatchDataManagerDatabase.sqlite;Version=3;");
            dbConnection.Open();
            string CreateTeamTable = "CREATE TABLE Team (ID TEXT, Name TEXT, CoachName TEXT)";
            string CreateLocationTable = "CREATE TABLE Location (ID TEXT, Name TEXT, City TEXT)";

            SQLiteCommand TeamTable = new SQLiteCommand(CreateTeamTable, dbConnection);
            SQLiteCommand LocationTable = new SQLiteCommand(CreateLocationTable, dbConnection);
            TeamTable.ExecuteNonQuery();
            LocationTable.ExecuteNonQuery();

            string TeamTableContent = "INSERT INTO Team (ID, Name, CoachName) VALUES ('556045fc-5c81-462c-9cc0-8e73e53e0dda','FC Barcelona', 'Xavi')";
            SQLiteCommand FillTeamTable = new SQLiteCommand(TeamTableContent, dbConnection);
            FillTeamTable.ExecuteNonQuery();
            string LocationTableContent = "INSERT INTO Location (ID,Name, City) VALUES ('cebe73cf-86e9-41c5-af71-5f0b5e65c183', 'Real Madrid', 'Madrid')";
            SQLiteCommand FillLocationTable = new SQLiteCommand(LocationTableContent, dbConnection);
            FillLocationTable.ExecuteNonQuery();
        }
    }
}
