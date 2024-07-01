namespace Esports_Org_Manager.Entities
{
    /// <summary>
    /// interface for employee type ContentCreator
    /// </summary>
    public interface IContentCreator
    {
        public List<string>? channels { get; set; }
        public int? numberOfVideosPerWeek { get; set; }
        public int? numberOfHoursStreamingPerWeek { get; set; }
        public IList<Tourney>? tourneyParticipations { get; }
        public IList<Tourney>? tourneyCasts { get; }

        public double CalculateAllIncome();
        public void MakeCaster(Tourney tourney);
        public void RemoveCaster(Tourney tourney);
        public void MakeParticipant(Tourney tourney);
        public void RemoveParticipant(Tourney tourney);
    }
}
