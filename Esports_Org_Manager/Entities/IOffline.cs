namespace Esports_Org_Manager.Entities
{
    /// <summary>
    /// interface for tourney view type offline
    /// </summary>
    public interface IOffline
    {
        public double? ticketPrice { get; set; }
        public Adress? adress { get; set; }
    }
}
