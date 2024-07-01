﻿// <auto-generated />
using System;
using Esports_Org_Manager.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Esports_Org_Manager.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240615222524_placements")]
    partial class placements
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0-preview.5.24306.3");

            modelBuilder.Entity("EmployeeTourneysCasters", b =>
                {
                    b.Property<int>("castersid")
                        .HasColumnType("INTEGER");

                    b.Property<int>("tourneyCastsid")
                        .HasColumnType("INTEGER");

                    b.HasKey("castersid", "tourneyCastsid");

                    b.HasIndex("tourneyCastsid");

                    b.ToTable("EmployeeTourneysCasters");
                });

            modelBuilder.Entity("EmployeeTourneysOrganised", b =>
                {
                    b.Property<int>("ownOrganizersid")
                        .HasColumnType("INTEGER");

                    b.Property<int>("tourneyParticipationsid")
                        .HasColumnType("INTEGER");

                    b.HasKey("ownOrganizersid", "tourneyParticipationsid");

                    b.HasIndex("tourneyParticipationsid");

                    b.ToTable("EmployeeTourneysOrganised");
                });

            modelBuilder.Entity("EmployeesPlayTourneys", b =>
                {
                    b.Property<int>("employeesid")
                        .HasColumnType("INTEGER");

                    b.Property<int>("tourneysPlayedid")
                        .HasColumnType("INTEGER");

                    b.HasKey("employeesid", "tourneysPlayedid");

                    b.HasIndex("tourneysPlayedid");

                    b.ToTable("EmployeesPlayTourneys");
                });

            modelBuilder.Entity("Esports_Org_Manager.Entities.Contract", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("isRenegotiable")
                        .HasColumnType("INTEGER");

                    b.Property<int>("membershipId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("signDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("validityPeriod")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("membershipId");

                    b.ToTable("Contracts", (string)null);
                });

            modelBuilder.Entity("Esports_Org_Manager.Entities.Employee", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("adress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("channels")
                        .HasColumnType("TEXT");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("employeeTypeDiscriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("nick")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("numberOfHoursStreamingPerWeek")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("numberOfVideosPerWeek")
                        .HasColumnType("INTEGER");

                    b.Property<string>("organizationName")
                        .HasColumnType("TEXT");

                    b.Property<string>("placementBonuses")
                        .HasColumnType("TEXT");

                    b.Property<int?>("procentageOfWinnings")
                        .HasColumnType("INTEGER");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("wage")
                        .HasColumnType("REAL");

                    b.HasKey("id");

                    b.HasIndex("organizationName");

                    b.ToTable("Employees", (string)null);

                    b.HasData(
                        new
                        {
                            id = 1,
                            adress = "{\"cityName\":\"Paris\",\"streetName\":\"d'trance\",\"number\":23}",
                            email = "jan.kajszczak@gmail.com",
                            employeeTypeDiscriminator = "Player",
                            lastName = "Touret",
                            name = "Axel",
                            nick = "Vatira",
                            organizationName = "karmine corp",
                            procentageOfWinnings = 23,
                            status = "available",
                            wage = 1200.0
                        },
                        new
                        {
                            id = 2,
                            adress = "{\"cityName\":\"Lisbon\",\"streetName\":\"R. Luis Monteiro\",\"number\":4}",
                            email = "jan.kajszczak@gmail.com",
                            employeeTypeDiscriminator = "Player",
                            lastName = "Ferguson",
                            name = "Finley",
                            nick = "Rise",
                            organizationName = "karmine corp",
                            procentageOfWinnings = 25,
                            status = "available",
                            wage = 1120.0
                        },
                        new
                        {
                            id = 3,
                            adress = "{\"cityName\":\"Brussels\",\"streetName\":\"Rue Emile Steeno\",\"number\":12}",
                            email = "jan.kajszczak@gmail.com",
                            employeeTypeDiscriminator = "Player",
                            lastName = "Soyez",
                            name = "Tristan",
                            nick = "Atow",
                            organizationName = "karmine corp",
                            procentageOfWinnings = 25,
                            status = "unavailable",
                            wage = 1120.0
                        },
                        new
                        {
                            id = 9,
                            adress = "{\"cityName\":\"Bruss\",\"streetName\":\"RuEmieSteeno\",\"number\":12}",
                            channels = "[\"youtube.com\"]",
                            email = "jan.kajszczak@gmail.com",
                            employeeTypeDiscriminator = "ContentCreator",
                            lastName = "Soy",
                            name = "Adam",
                            nick = "Zen",
                            numberOfHoursStreamingPerWeek = 1,
                            numberOfVideosPerWeek = 3,
                            organizationName = "karmine corp",
                            status = "available",
                            wage = 1120.0
                        },
                        new
                        {
                            id = 10,
                            adress = "{\"cityName\":\"Brels\",\"streetName\":\"Reno\",\"number\":12}",
                            channels = "[\"youtube.com\"]",
                            email = "jan.kajszczak@gmail.com",
                            employeeTypeDiscriminator = "ContentCreator",
                            lastName = "oyez",
                            name = "Ttan",
                            nick = "Flip",
                            numberOfHoursStreamingPerWeek = 4,
                            numberOfVideosPerWeek = 2,
                            organizationName = "karmine corp",
                            status = "available",
                            wage = 1120.0
                        },
                        new
                        {
                            id = 11,
                            adress = "{\"cityName\":\"sels\",\"streetName\":\"Re Steeno\",\"number\":12}",
                            channels = "[\"youtube.com\"]",
                            email = "jan.kajszczak@gmail.com",
                            employeeTypeDiscriminator = "ContentCreator",
                            lastName = "Sez",
                            name = "opoon",
                            nick = "chaotic",
                            numberOfHoursStreamingPerWeek = 5,
                            numberOfVideosPerWeek = 2,
                            organizationName = "karmine corp",
                            status = "unavailable",
                            wage = 1120.0
                        },
                        new
                        {
                            id = 12,
                            adress = "{\"cityName\":\"Brusse\",\"streetName\":\"Rue Emino\",\"number\":12}",
                            channels = "[\"youtube.com\"]",
                            email = "jan.kajszczak@gmail.com",
                            employeeTypeDiscriminator = "ContentCreator",
                            lastName = "Soy",
                            name = "Trst",
                            nick = "chaser",
                            numberOfHoursStreamingPerWeek = 3,
                            numberOfVideosPerWeek = 2,
                            organizationName = "karmine corp",
                            status = "available",
                            wage = 1120.0
                        });
                });

            modelBuilder.Entity("Esports_Org_Manager.Entities.IndependentContractor", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("price")
                        .HasColumnType("REAL");

                    b.HasKey("id");

                    b.ToTable("IndependentContractors", (string)null);

                    b.HasData(
                        new
                        {
                            id = 1,
                            email = "MVL@gmail.com",
                            name = "MVL sp z.o.o",
                            price = 23000.0
                        });
                });

            modelBuilder.Entity("Esports_Org_Manager.Entities.Membership", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("employeeId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("endDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("startDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("teamId")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("employeeId");

                    b.HasIndex("teamId");

                    b.ToTable("Memberships", (string)null);

                    b.HasData(
                        new
                        {
                            id = 1,
                            employeeId = 1,
                            endDate = new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            startDate = new DateTime(2020, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            teamId = 3
                        },
                        new
                        {
                            id = 2,
                            employeeId = 2,
                            endDate = new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            startDate = new DateTime(2021, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            teamId = 3
                        },
                        new
                        {
                            id = 3,
                            employeeId = 3,
                            endDate = new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            startDate = new DateTime(2021, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            teamId = 3
                        },
                        new
                        {
                            id = 9,
                            employeeId = 9,
                            endDate = new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            startDate = new DateTime(2021, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            teamId = 3
                        },
                        new
                        {
                            id = 10,
                            employeeId = 10,
                            endDate = new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            startDate = new DateTime(2021, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            teamId = 3
                        },
                        new
                        {
                            id = 11,
                            employeeId = 11,
                            endDate = new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            startDate = new DateTime(2021, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            teamId = 3
                        },
                        new
                        {
                            id = 12,
                            employeeId = 12,
                            endDate = new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            startDate = new DateTime(2021, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            teamId = 3
                        });
                });

            modelBuilder.Entity("Esports_Org_Manager.Entities.Organization", b =>
                {
                    b.Property<string>("name")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("creationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("logo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("name");

                    b.ToTable("Organizations", (string)null);

                    b.HasData(
                        new
                        {
                            name = "karmine corp",
                            creationDate = new DateTime(2012, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            logo = "\\Logos\\karmine-corp-2021.png"
                        },
                        new
                        {
                            name = "moist esports",
                            creationDate = new DateTime(2018, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            logo = "\\Logos\\mst.jpg"
                        });
                });

            modelBuilder.Entity("Esports_Org_Manager.Entities.Team", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("creationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("gamePlayed")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("logo")
                        .HasColumnType("TEXT");

                    b.Property<int>("minimalAgeEligibility")
                        .HasColumnType("INTEGER");

                    b.Property<int>("minimalNumberOfPlayers")
                        .HasColumnType("INTEGER");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("organizationName")
                        .HasColumnType("TEXT");

                    b.Property<string>("region")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.HasIndex("organizationName");

                    b.ToTable("Teams", (string)null);

                    b.HasData(
                        new
                        {
                            id = 1,
                            creationDate = new DateTime(2019, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            gamePlayed = "rocket league",
                            minimalAgeEligibility = 16,
                            minimalNumberOfPlayers = 3,
                            name = "mst rl",
                            organizationName = "moist esports",
                            region = "NA",
                            status = "available"
                        },
                        new
                        {
                            id = 2,
                            creationDate = new DateTime(2020, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            gamePlayed = "valorant",
                            minimalAgeEligibility = 16,
                            minimalNumberOfPlayers = 5,
                            name = "mst valo",
                            organizationName = "moist esports",
                            region = "NA",
                            status = "available"
                        },
                        new
                        {
                            id = 3,
                            creationDate = new DateTime(2015, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            gamePlayed = "valorant",
                            minimalAgeEligibility = 16,
                            minimalNumberOfPlayers = 5,
                            name = "kc rant",
                            organizationName = "karmine corp",
                            region = "NA",
                            status = "available"
                        });
                });

            modelBuilder.Entity("Esports_Org_Manager.Entities.Tourney", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("adress")
                        .HasColumnType("TEXT");

                    b.Property<double>("awardPool")
                        .HasColumnType("REAL");

                    b.Property<string>("competitionType")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("date")
                        .HasColumnType("TEXT");

                    b.Property<string>("format")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("independentOrganizerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("organizerDiscriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("procentPerPlace")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("state")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("streamLinks")
                        .HasColumnType("TEXT");

                    b.Property<double?>("ticketPrice")
                        .HasColumnType("REAL");

                    b.Property<string>("timeUntill")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("viewTypeDiscriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.HasIndex("independentOrganizerId");

                    b.ToTable("Tourneys", (string)null);

                    b.HasDiscriminator<string>("competitionType").HasValue("Tourney");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("TeamsPlayTourneys", b =>
                {
                    b.Property<int>("teamsid")
                        .HasColumnType("INTEGER");

                    b.Property<int>("tourneysid")
                        .HasColumnType("INTEGER");

                    b.HasKey("teamsid", "tourneysid");

                    b.HasIndex("tourneysid");

                    b.ToTable("TeamsPlayTourneys");
                });

            modelBuilder.Entity("Esports_Org_Manager.Entities.SoloTourney", b =>
                {
                    b.HasBaseType("Esports_Org_Manager.Entities.Tourney");

                    b.Property<bool>("allowCoaching")
                        .HasColumnType("INTEGER");

                    b.Property<string>("placements")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.ToTable("Tourneys", t =>
                        {
                            t.Property("placements")
                                .HasColumnName("SoloTourney_placements");
                        });

                    b.HasDiscriminator().HasValue("solo");
                });

            modelBuilder.Entity("Esports_Org_Manager.Entities.TeamTourney", b =>
                {
                    b.HasBaseType("Esports_Org_Manager.Entities.Tourney");

                    b.Property<string>("placements")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("playerChangePointsPenalty")
                        .HasColumnType("INTEGER");

                    b.HasDiscriminator().HasValue("team");

                    b.HasData(
                        new
                        {
                            id = 1,
                            adress = "{\"cityName\":\"Kopenhagen\",\"streetName\":\"Sankt Gertruds\",\"number\":12}",
                            awardPool = 200000.0,
                            date = new DateTime(2024, 5, 27, 0, 25, 23, 721, DateTimeKind.Local).AddTicks(3677),
                            format = "NFL",
                            independentOrganizerId = 1,
                            name = "Summer champions",
                            organizerDiscriminator = "Independent",
                            procentPerPlace = "[50,30,20]",
                            state = "Finished",
                            ticketPrice = 120.0,
                            timeUntill = "-",
                            viewTypeDiscriminator = "[1]",
                            placements = "{}",
                            playerChangePointsPenalty = 12
                        });
                });

            modelBuilder.Entity("EmployeeTourneysCasters", b =>
                {
                    b.HasOne("Esports_Org_Manager.Entities.Employee", null)
                        .WithMany()
                        .HasForeignKey("castersid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Esports_Org_Manager.Entities.Tourney", null)
                        .WithMany()
                        .HasForeignKey("tourneyCastsid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EmployeeTourneysOrganised", b =>
                {
                    b.HasOne("Esports_Org_Manager.Entities.Employee", null)
                        .WithMany()
                        .HasForeignKey("ownOrganizersid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Esports_Org_Manager.Entities.Tourney", null)
                        .WithMany()
                        .HasForeignKey("tourneyParticipationsid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EmployeesPlayTourneys", b =>
                {
                    b.HasOne("Esports_Org_Manager.Entities.Employee", null)
                        .WithMany()
                        .HasForeignKey("employeesid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Esports_Org_Manager.Entities.SoloTourney", null)
                        .WithMany()
                        .HasForeignKey("tourneysPlayedid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Esports_Org_Manager.Entities.Contract", b =>
                {
                    b.HasOne("Esports_Org_Manager.Entities.Membership", "membership")
                        .WithMany("contracts")
                        .HasForeignKey("membershipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("membership");
                });

            modelBuilder.Entity("Esports_Org_Manager.Entities.Employee", b =>
                {
                    b.HasOne("Esports_Org_Manager.Entities.Organization", "organization")
                        .WithMany("employees")
                        .HasForeignKey("organizationName");

                    b.Navigation("organization");
                });

            modelBuilder.Entity("Esports_Org_Manager.Entities.Membership", b =>
                {
                    b.HasOne("Esports_Org_Manager.Entities.Employee", "employee")
                        .WithMany("memberships")
                        .HasForeignKey("employeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Esports_Org_Manager.Entities.Team", "team")
                        .WithMany("memberships")
                        .HasForeignKey("teamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("employee");

                    b.Navigation("team");
                });

            modelBuilder.Entity("Esports_Org_Manager.Entities.Team", b =>
                {
                    b.HasOne("Esports_Org_Manager.Entities.Organization", "organization")
                        .WithMany("virtTeams")
                        .HasForeignKey("organizationName");

                    b.Navigation("organization");
                });

            modelBuilder.Entity("Esports_Org_Manager.Entities.Tourney", b =>
                {
                    b.HasOne("Esports_Org_Manager.Entities.IndependentContractor", "independentOrganizer")
                        .WithMany("tourneys")
                        .HasForeignKey("independentOrganizerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("independentOrganizer");
                });

            modelBuilder.Entity("TeamsPlayTourneys", b =>
                {
                    b.HasOne("Esports_Org_Manager.Entities.Team", null)
                        .WithMany()
                        .HasForeignKey("teamsid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Esports_Org_Manager.Entities.TeamTourney", null)
                        .WithMany()
                        .HasForeignKey("tourneysid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Esports_Org_Manager.Entities.Employee", b =>
                {
                    b.Navigation("memberships");
                });

            modelBuilder.Entity("Esports_Org_Manager.Entities.IndependentContractor", b =>
                {
                    b.Navigation("tourneys");
                });

            modelBuilder.Entity("Esports_Org_Manager.Entities.Membership", b =>
                {
                    b.Navigation("contracts");
                });

            modelBuilder.Entity("Esports_Org_Manager.Entities.Organization", b =>
                {
                    b.Navigation("employees");

                    b.Navigation("virtTeams");
                });

            modelBuilder.Entity("Esports_Org_Manager.Entities.Team", b =>
                {
                    b.Navigation("memberships");
                });
#pragma warning restore 612, 618
        }
    }
}
