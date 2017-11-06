using System;
using System.IO;
using SQLite;
using Xamarin.Forms;
using Cross.Data.SQLite;
using Cross.iOS.Data.SQLite;

[assembly: Dependency(typeof(SQLite_iOS))]

namespace Cross.iOS.Data.SQLite
{
    public class SQLite_iOS : ISQLite
    {
        public SQLite_iOS()
        {
        }

        public SQLiteConnection GetConnection()
        {
            var sqliteFilename = "ParsV.db3";
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
            string libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder
            var path = Path.Combine(libraryPath, sqliteFilename);
            // Create the connection
            var conn = new SQLiteConnection(path);
            // Return the database connection
            return conn;
        }
    }
}