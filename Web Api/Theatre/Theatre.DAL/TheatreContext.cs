using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Theatre.DAL
{
    public partial class TheatreContext : DbContext
    {
        public TheatreContext()
            : base("name=TheatreContext")
        {
        }

        public virtual DbSet<Personnel> Personnel { get; set; }
        public virtual DbSet<Proprietor> Proprietor { get; set; }
        public virtual DbSet<Show> Show { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Theatre> Theatre { get; set; }
        public virtual DbSet<TheatrePersonnel> TheatrePersonnel { get; set; }
        public virtual DbSet<Ticket> Ticket { get; set; }
        public virtual DbSet<TicketUsers> TicketUsers { get; set; }
        public virtual DbSet<UserAddress> UserAddress { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personnel>()
                .Property(e => e.PersonnelName)
                .IsUnicode(false);

            modelBuilder.Entity<Personnel>()
                .Property(e => e.Surname)
                .IsUnicode(false);

            modelBuilder.Entity<Personnel>()
                .Property(e => e.Position)
                .IsUnicode(false);

            modelBuilder.Entity<Personnel>()
                .HasMany(e => e.TheatrePersonnel)
                .WithRequired(e => e.Personnel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Proprietor>()
                .Property(e => e.ProprietorName)
                .IsUnicode(false);

            modelBuilder.Entity<Proprietor>()
                .Property(e => e.Surname)
                .IsUnicode(false);

            modelBuilder.Entity<Show>()
                .Property(e => e.TicketPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Theatre>()
                .HasMany(e => e.TheatrePersonnel)
                .WithRequired(e => e.Theatre)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ticket>()
                .Property(e => e.TicketId)
                .IsUnicode(false);

            modelBuilder.Entity<Ticket>()
                .Property(e => e.Cost)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Ticket>()
                .Property(e => e.NicknameOfUser)
                .IsUnicode(false);

            modelBuilder.Entity<Ticket>()
                .HasMany(e => e.TicketUsers)
                .WithRequired(e => e.Ticket)
                .HasForeignKey(e => e.TicketNumber)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserAddress>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<UserAddress>()
                .Property(e => e.StreetName)
                .IsUnicode(false);

            modelBuilder.Entity<UserAddress>()
                .Property(e => e.HouseNumber)
                .IsUnicode(false);

            modelBuilder.Entity<UserInfo>()
                .Property(e => e.UserInfoName)
                .IsUnicode(false);

            modelBuilder.Entity<UserInfo>()
                .Property(e => e.Surname)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.UserTicketNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.UserId)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.UserPaymentMethod)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.TicketUsers)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.UserUniqueId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.UserAddress)
                .WithOptional(e => e.Users)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<Users>()
                .HasOptional(e => e.UserInfo)
                .WithRequired(e => e.Users);
        }
    }
}
