using System;
using System.Data;
using System.IO;
using SQLite;

namespace DB_LAB.ORM
{
    [Table("ToDoTasks")]
    public class ToDoTasks
    {
        [PrimaryKey, AutoIncrement,Column("_Id")]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Task { get; set; }
    }
}