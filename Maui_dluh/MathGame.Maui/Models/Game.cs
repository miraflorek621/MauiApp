using SQLite;

namespace MathsGame.Models
{
    [Table("game")]
    public class Game
    {
        [PrimaryKey, AutoIncrement, Column("Id")]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public DateTime DatePlayed { get; set; }
    }

}