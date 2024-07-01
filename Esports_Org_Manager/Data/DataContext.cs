using Esports_Org_Manager.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using System.Linq.Expressions;

namespace Esports_Org_Manager.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Tourney> Tourneys { get; set; }
        public DbSet<SoloTourney> SoloTourneys { get; set; }
        public DbSet<TeamTourney> TeamTourneys { get; set; }
        public DbSet<IndependentContractor> IndependentContractos { get; set; }

        public string DbPath { get; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            DbPath = Path.Combine(Directory.GetCurrentDirectory(), "DB\\maslo.db");
        }

        private static readonly TaggedQueryCommandInterceptor _interceptor = new TaggedQueryCommandInterceptor();

        protected override void OnConfiguring(DbContextOptionsBuilder options)
                    => options.UseSqlite($"Data Source={DbPath}").AddInterceptors(_interceptor).EnableSensitiveDataLogging();
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Organization>(org =>
            {
                org.HasKey(o => o.name);

                org.Property(o => o.creationDate).IsRequired();
                org.Property(o => o.logo);

                org.Property(o => o.teams).HasConversion(d => JsonConvert.SerializeObject(d),s => JsonConvert.DeserializeObject<Dictionary<string, Team>>(s));

                org.ToTable("Organizations");
            });

            modelBuilder.Entity<Team>(team =>
            {
                team.HasKey(t => t.id);

                team.HasOne(t => t.organization)
                        .WithMany(o => o.virtTeams)
                        .HasForeignKey(t => t.organizationName);

                team.Ignore(t => t.status);

                team.ToTable("Teams");
            });

            modelBuilder.Entity<Employee>(emp =>
            {
                emp.HasKey(e => e.id);

                emp.Property(e => e.channels).HasConversion(v => JsonConvert.SerializeObject(v), db => JsonConvert.DeserializeObject<List<string>>(db));
                emp.Property(e => e.placementBonuses).HasConversion(v => JsonConvert.SerializeObject(v), db => JsonConvert.DeserializeObject<Dictionary<int,int>>(db));
                emp.Property(e => e.adress).HasConversion(v => JsonConvert.SerializeObject(v), db => JsonConvert.DeserializeObject<Adress>(db));

                emp.Property(e => e.status).HasConversion(v => v.ToString(), db => Enum.Parse<AvailabilityStatus>(db));
                emp.Property(e => e.employeeTypeDiscriminator).HasConversion(v => v.ToString(), db => Enum.Parse<EmployeeType>(db));

                emp.HasOne(e => e.organization).WithMany(o => o.employees).HasForeignKey(e => e.organizationName);

                emp.ToTable("Employees");

                
            });

            modelBuilder.Entity<Membership>(mem =>
            {
                mem.HasKey(m => m.id);

                mem.HasOne(m => m.team)
                        .WithMany(t => t.memberships)
                        .HasForeignKey(m => m.teamId);

                mem.HasOne(m => m.employee)
                        .WithMany(e => e.memberships)
                        .HasForeignKey(m => m.employeeId);
               

                mem.ToTable("Memberships");
            });

            modelBuilder.Entity<Contract>(con =>
            {
                con.HasKey(c => c.id);

                con.HasOne(c => c.membership)
                    .WithMany(m => m.contracts)
                    .HasForeignKey(c => c.membershipId);
                
                con.ToTable("Contracts");
            });

            modelBuilder.Entity<Tourney>(tour =>
            {
                tour.HasKey(t => t.id);

                tour.HasDiscriminator<string>("competitionType")
                        .HasValue<SoloTourney>("solo")
                        .HasValue<TeamTourney>("team");
                tour.Property(t => t.state).HasConversion(v => v.ToString(), db => Enum.Parse<TourneyState>(db));
                tour.Property(t => t.procentPerPlace).HasConversion(v => JsonConvert.SerializeObject(v), db => JsonConvert.DeserializeObject<List<int>>(db));
                tour.Property(t => t.streamLinks).HasConversion(v => JsonConvert.SerializeObject(v), db => JsonConvert.DeserializeObject<List<string>>(db));
                tour.Property(t => t.adress).HasConversion(v => JsonConvert.SerializeObject(v), db => JsonConvert.DeserializeObject<Adress>(db));
                tour.Property(t => t.viewTypeDiscriminator).HasConversion(v => JsonConvert.SerializeObject(v), db => JsonConvert.DeserializeObject<HashSet<ViewingType>>(db));
                tour.Property(t => t.organizerDiscriminator).HasConversion(v => v.ToString(), db => Enum.Parse<OrganizerType>(db));

                tour.HasOne(t => t.independentOrganizer).WithMany(o => o.tourneys).HasForeignKey(t => t.independentOrganizerId);

                tour.HasMany(t => t.ownOrganizers).WithMany(e => e.tourneyParticipations).UsingEntity("EmployeeTourneysOrganised");
                tour.HasMany(t => t.casters).WithMany(e => e.tourneyCasts).UsingEntity("EmployeeTourneysCasters");

                tour.ToTable("Tourneys");
            });

            modelBuilder.Entity<TeamTourney>(tt =>
            {
                tt.Property(t => t.placements).HasConversion(v => JsonConvert.SerializeObject(v), db => JsonConvert.DeserializeObject<Dictionary<int, int>>(db));

                tt.HasMany(t => t.teams).WithMany(t => t.tourneys).UsingEntity("TeamsPlayTourneys");

                var proc = new List<int> { 50, 30, 20 };
                var vi = new HashSet<string> { "Offlie" };

            });

            modelBuilder.Entity<SoloTourney>(st =>
            {
                st.Property(t => t.placements).HasConversion(v => JsonConvert.SerializeObject(v), db => JsonConvert.DeserializeObject<Dictionary<int,int>>(db));

                st.HasMany(t => t.employees).WithMany(t => t.tourneysPlayed).UsingEntity("EmployeesPlayTourneys");
            });

            modelBuilder.Entity<IndependentContractor>(ic =>
            {
                ic.HasKey(i => i.id);


                ic.ToTable("IndependentContractors");
            });
        }
    }
}
