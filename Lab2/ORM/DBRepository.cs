using System;
using System.Data;
using System.IO;
using SQLite;


namespace DB_LAB.ORM
{
    public class DBRepository
    {
        public string CreateDB()
        {
            var output = "";
            output += "Creating Database if it is doesnt exist...";
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "ORMDB.db3");
            var db = new SQLiteConnection(dbPath);
            output += "\nDatabase Created...";
            return output;
        }
        //code to create the table
        public string CreateTable()
        {
            try
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "ORMDB.db3");
                var db = new SQLiteConnection(dbPath);
                db.CreateTable<ToDoTasks>();
                string result = "Table Created Succesfully...";
                return result;
            }
            catch (Exception ex)
            {
                return "Error : " + ex.Message;
            }
        }
        //code to insert the record
        public string InsertRecord(string Task)
        {
            try
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "ORMDB.db3");
                var db = new SQLiteConnection(dbPath);

                ToDoTasks item = new ToDoTasks();
                item.Task = Task;
                db.Insert(item);
                return "Record added";
            }
            catch (Exception ex )
            {
                return "Error : " + ex.Message;
            }
        }
        //code to retrieve all records 
        public string GetAllRecords()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "ORMDB.db3");
            var db = new SQLiteConnection(dbPath);

            string output = "";
            output += "Retrieving the data using ORM...";
            var table = db.Table<ToDoTasks>();
            foreach (var item in table)
            {
                output += "\n" + item.Id + " --- " + item.Task;
            }
            return output;
        }
        //code to retrieve specific data 
        public string GetTaskById(int id)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "ORMDB.db3");
            var db = new SQLiteConnection(dbPath);

            var item = db.Get<ToDoTasks>(id);
            return item.Task;
        }

        //code to update 
        public string UpdateRecord(int id, string task)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "ORMDB.db3");
            var db = new SQLiteConnection(dbPath);

            var item = db.Get<ToDoTasks>(id);
            item.Task = task;
            db.Update(item);
            return "Record updated...";
        }

        //code to remove the record 
        public string RemoveTask(int id)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "ORMDB.db3");
            var db = new SQLiteConnection(dbPath);
            var item = db.Get<ToDoTasks>(id);
            db.Delete(item);
            return "Record Deleted...";
        }





    }
}