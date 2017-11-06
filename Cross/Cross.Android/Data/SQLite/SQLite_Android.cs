using System.IO;
using SQLite;
using Xamarin.Forms;
using Cross.Data.SQLite;
using Cross.Droid.Data.SQLite;

[assembly: Dependency(typeof(SQLite_Android))]

namespace Cross.Droid.Data.SQLite
{
    public class SQLite_Android : ISQLite
    {
        public SQLite_Android() { }
        public SQLiteConnection GetConnection()
        {
            var sqliteFilename = "ParsV.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
            var path = Path.Combine(documentsPath, sqliteFilename);
            // Create the connection
            var conn = new SQLiteConnection(path);
            // Return the database connection
            return conn;
        }
    }
}