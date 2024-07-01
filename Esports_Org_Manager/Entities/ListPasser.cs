namespace Esports_Org_Manager.Entities
{
    /// <summary>
    /// a class letting you pass list objects between web pages
    /// </summary>
    public class ListPasser
    {
        public List<Employee> empList { get; set; } = new List<Employee>();
        public List<Team> teamList { get; set; } = new List<Team>();
    }
}
