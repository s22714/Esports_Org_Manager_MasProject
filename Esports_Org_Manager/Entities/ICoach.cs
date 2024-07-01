namespace Esports_Org_Manager.Entities
{
    /// <summary>
    /// interface for employee type coach
    /// </summary>
    public interface ICoach
    {
        public Dictionary<int, int>? placementBonuses { get; set; }
        public double CalculateAllIncome();
    }
}
