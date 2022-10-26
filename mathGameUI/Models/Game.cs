using SQLite;

namespace mathGameUI.Models
{
    [Table("gameTable")]
    public class Game
    {
        [PrimaryKey, AutoIncrement,Column("Id")]
        public int Score { get; set; }
        public int Id { get; set; }
        public GameOperand Type { get; set; }
        public DateTime DatePlayed { get; set; }
       
    }
    public enum GameOperand
    {
        suma,
        resta,
        multiplicacion,
        division,

    }
}
