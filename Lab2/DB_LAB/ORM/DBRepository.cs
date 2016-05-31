using System;
using System.IO;
using SQLite;
using System.Collections.Generic;

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
                //db.DeleteAll<ToDoTasks>();
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
        public string InsertRecord(string Manufacturer, string Model, string Android, string WWW)
        {
            try
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "ORMDB.db3");
                var db = new SQLiteConnection(dbPath);

                ToDoTasks item = new ToDoTasks();
                item.Manufacturer = Manufacturer;
                item.Model = Model;
                item.Android = Android;
                item.WWW = WWW;
                db.Insert(item);
                return "Record added";
            }
            catch (Exception ex )
            {
                return "Error : " + ex.Message;
            }
        }
        //code to retrieve all records 
        public List<ToDoTasks> GetAllRecords()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "ORMDB.db3");
            var db = new SQLiteConnection(dbPath);

            List<ToDoTasks> item =new List<ToDoTasks>(db.Table<ToDoTasks>());
            //string output = "";
            //output += "Retrieving the data using ORM...";
            //var table = db.Table<ToDoTasks>();
            //foreach (var item in table)
            //{
            //    output += "\n" + item.Id + " --- " + item.Manufacturer;
            //}
            return item;
        }
        //code to retrieve specific data 
        public ToDoTasks GetTaskById(int id)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "ORMDB.db3");
            var db = new SQLiteConnection(dbPath);

            var item = db.Get<ToDoTasks>(id);
            return item;
        }

        //code to update 
        public string UpdateRecord(int id, ToDoTasks task)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "ORMDB.db3");
            var db = new SQLiteConnection(dbPath);

            //var item = db.Get<ToDoTasks>(id);
            //item.Manufacturer = task;
            db.Update(task);
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