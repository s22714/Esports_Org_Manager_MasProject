namespace Esports_Org_Manager.Entities
{
    /// <summary>
    /// interface for employee type Player
    /// </summary>
    public interface IPlayer
    {
        public int? procentageOfWinnings {  get; set; }
        public double CalculateAllIncome();
    }
}
