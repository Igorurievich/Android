using SQLite;

namespace DB_LAB.ORM
{
    [Table("ToDoTasks")]
    public class ToDoTasks
    {
        [PrimaryKey, AutoIncrement,Column("_Id")]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Manufacturer { get; set; }

        [MaxLength(50)]
        public string Model { get; set; }

        [MaxLength(50)]
        public string Android { get; set; }

        [MaxLength(50)]
        public string WWW { get; set; }
    }
}