namespace GPFormula1.Web.Models
{
    public class GrandePremio
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Local { get; set; } = string.Empty;
        public string Circuito { get; set; } = string.Empty;
        public DateTime Data { get; set; }
        public int TemporadaId { get; set; }
    }

    public class DriverStanding
    {
        public int Position { get; set; }
        public string DriverName { get; set; } = string.Empty;
        public string TeamName { get; set; } = string.Empty;
        public int Points { get; set; }
    }

    public class TeamStanding
    {
        public int Position { get; set; }
        public string TeamName { get; set; } = string.Empty;
        public int Points { get; set; }
        public string Color { get; set; } = "#000000";
    }
}
