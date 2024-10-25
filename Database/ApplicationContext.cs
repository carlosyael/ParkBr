using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Model;
using Microsoft.EntityFrameworkCore;
namespace Database
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) :base(options) { }

        public DbSet<Users> Users { get; set; }
        public DbSet<ParkingSpots> ParkingSpots { get; set; }
        public DbSet<ParkingRequests> ParkingRequests { get; set; }
        public DbSet<ParkingAuditLogs> ParkingAuditLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent Api
            #region Tables
            modelBuilder.Entity<Users>().ToTable("Users");
            modelBuilder.Entity<ParkingSpots>().ToTable("ParkingSpots");
            modelBuilder.Entity<ParkingRequests>().ToTable("ParkingRequests");
            modelBuilder.Entity<ParkingAuditLogs>().ToTable("ParkingAuditLogs");
            #endregion

            #region  Primary key
            modelBuilder.Entity<Users>().HasKey(Users => Users.Id);
            modelBuilder.Entity<ParkingRequests>().HasKey(ParkingRequests => ParkingRequests.Id);
            modelBuilder.Entity<ParkingAuditLogs>().HasKey(ParkingAuditLogs => ParkingAuditLogs.Id);
            modelBuilder.Entity<ParkingSpots>().HasKey(ParkingSpots => ParkingSpots.Id);
            #endregion


            #region Relationship
            #region Primary Key
            modelBuilder.Entity<Users>()
                .HasOne(User=>User.ParkingSpots)
                .WithOne(ParkingSpot=>ParkingSpot.users)
                .HasForeignKey<ParkingSpots>(ParkingSpot=>ParkingSpot.AssignedTo).OnDelete(DeleteBehavior.SetNull);
           
            modelBuilder.Entity<ParkingSpots>()
                .HasMany<ParkingRequests>(ParkingSpot => ParkingSpot.parkingRequests)
                .WithOne(ParkingRequest => ParkingRequest.ParkingSpots)
                .HasForeignKey(ParkingRequest => ParkingRequest.ParkingSpot_Id).OnDelete(DeleteBehavior.SetNull);
            
            modelBuilder.Entity<Users>()
                .HasMany<ParkingRequests>(User=>User.parkingRequests)
                .WithOne(ParkingRequest => ParkingRequest.Users)
                .HasForeignKey(ParkingRequest =>ParkingRequest.User_Id).OnDelete(DeleteBehavior.SetNull);
            
            modelBuilder.Entity<ParkingSpots>()
                .HasMany<ParkingAuditLogs>(ParkingSpot => ParkingSpot.parkingAuditLogs)
                .WithOne(ParkingAuditLog => ParkingAuditLog.ParkingSpots)
                .HasForeignKey(ParkingAuditLog => ParkingAuditLog.ParkingSpot_Id).OnDelete(DeleteBehavior.SetNull);
            
            modelBuilder.Entity<Users>()
                .HasMany<ParkingAuditLogs>(User => User.parkingAuditLogs)
                .WithOne(ParkingAuditLog => ParkingAuditLog.Users)
                .HasForeignKey(ParkingAuditLog => ParkingAuditLog.User_Id).OnDelete(DeleteBehavior.SetNull);


            #endregion

            #endregion



        }

    }
}