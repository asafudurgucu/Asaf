using Microsoft.EntityFrameworkCore;
using PartyApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyApp.Data.Concrete
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }
        public DbSet<Invitation>  Invitations { get; set; }
        public DbSet<Participant>  Participants { get; set; }
        public DbSet<InvitationParticipant>  InvitationParticipants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region InvitationHasData
            List<Invitation> ınvitations = [

                    new Invitation
                    {
                        Id = 1,
                        EventName = "TESTESTESRE PARTİSİ",
                        EventDate = new DateTime(2024, 12, 25),
                    },
                    new Invitation
                    {
                        Id = 2,
                        EventName = "DGKO PARTİSİ",
                        EventDate = new DateTime(2024, 12, 30),
                    }

                ];
            modelBuilder.Entity<Invitation>().HasData(ınvitations);
            #endregion

            #region PartycipantsHasData
            List<Participant> participants = [
                        new(){
                            Id = 1,
                            FullName = "Asaf",
                            Age = 18,
                            Email = "a12ıdwdıj@gmail.com",
                            NumberOfPeople = 1,
                            PhoneNumber = "39283834"
                        },
                        new(){
                            Id = 2,
                            FullName = "Kemal",
                            Age = 19,
                            Email = "aıdwdı22j@gmail.com",
                            NumberOfPeople = 2,
                            PhoneNumber = "3928383224"
                        },
                        new(){
                            Id = 3,
                            FullName = "Ömer",
                            Age = 28,
                            Email = "a12ıdwdıj@gmail.com",
                            NumberOfPeople = 1,
                            PhoneNumber = "3928321834"
                        },
                        new(){
                            Id = 4,
                            FullName = "Selim",
                            Age = 18,
                            Email = "aıdw221dıj@gmail.com",
                            NumberOfPeople = 1,
                            PhoneNumber = "392813834"
                        },
                        new(){
                            Id = 5,
                            FullName = "Hakkı",
                            Age = 18,
                            Email = "aıd12wdıj@gmail.com",
                            NumberOfPeople = 1,
                            PhoneNumber = "319283834"
                        },
                        new(){
                            Id = 6,
                            FullName = "Büşra",
                            Age = 18,
                            Email = "aıd12wdıj@gmail.com",
                            NumberOfPeople = 1,
                            PhoneNumber = "392838343"
                        },
                        new(){
                            Id = 7,
                            FullName = "Ayşe",
                            Age = 22,
                            Email = "ayse@example.com",
                            NumberOfPeople = 3,
                            PhoneNumber = "39838345"
                        },
                        new(){
                            Id = 8,
                            FullName = "Mehmet",
                            Age = 30,
                            Email = "mehmet@example.com",
                            NumberOfPeople = 1,
                            PhoneNumber = "39183837"
                        },
                        new(){
                            Id = 9,
                            FullName = "Fatma",
                            Age = 25,
                            Email = "fatma@example.com",
                            NumberOfPeople = 2,
                            PhoneNumber = "39283839"
                        },
                        new(){
                            Id = 10,
                            FullName = "Ali",
                            Age = 24,
                            Email = "ali@example.com",
                            NumberOfPeople = 1,
                            PhoneNumber = "39383831"
                        }
  ];
            modelBuilder.Entity<Participant>().HasData(participants);



            #endregion

            #region InvitationPartycipantHasData

            List<InvitationParticipant> invitationParticipants = [

              
                            new(){
                                Id = 1,
                                InvitationId = 1,
                                ParticipantId = 1
                            },
                            new(){
                                Id = 2,
                                InvitationId = 2,
                                ParticipantId = 2
                            },
                            new(){
                                Id = 3,
                                InvitationId = 1,
                                ParticipantId = 3
                            },
                            new(){
                                Id = 4,
                                InvitationId = 2,
                                ParticipantId = 4
                            },
                            new(){
                                Id = 5,
                                InvitationId = 1,
                                ParticipantId = 5
                            },
                            new(){
                                Id = 6,
                                InvitationId = 2,
                                ParticipantId = 6
                            },
                            new(){
                                Id = 7,
                                InvitationId = 1,
                                ParticipantId = 7
                            },
                            new(){
                                Id = 8,
                                InvitationId = 2,
                                ParticipantId = 8
                            },
                            new(){
                                Id = 9,
                                InvitationId = 1,
                                ParticipantId = 9
                            },
                            new(){
                                Id = 10,
                                InvitationId = 2,
                                ParticipantId = 10
                            }


                       
                ];
            modelBuilder.Entity<InvitationParticipant>().HasData(invitationParticipants);
            #endregion

            #region InvitationConfigures

            modelBuilder.Entity<Invitation>().HasKey(x => x.Id);
            modelBuilder.Entity<Invitation>().Property(x => x.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Invitation>().Property(x=> x.EventName)
                .IsRequired(true)
                .HasMaxLength(100);

            modelBuilder.Entity<Invitation>().ToTable("Invitations");



            #endregion

            #region PartycipantConfigures
            modelBuilder.Entity<Participant>().HasKey(x => x.Id);
            modelBuilder.Entity<Participant>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Participant>().Property(x => x.FullName)
                .IsRequired(true)
                .HasMaxLength(100);
            modelBuilder.Entity<Participant>().Property(x => x.Email)
                .IsRequired(true)
                .HasMaxLength(300);    
            modelBuilder.Entity<Participant>().Property(x => x.Age).IsRequired(false);
            modelBuilder.Entity<Participant>().Property(x => x.PhoneNumber).IsRequired(false);
            modelBuilder.Entity<Participant>().Property(x => x.NumberOfPeople).IsRequired(true);
            modelBuilder.Entity<Participant>().ToTable("Partycipants");
            #endregion

            #region InvitationPartycipantConfigures

            modelBuilder.Entity<InvitationParticipant>().HasKey(x => new {x.InvitationId,x.ParticipantId});
            #endregion


            base.OnModelCreating(modelBuilder);
        }


    }
}
