using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoctorsAgenda.Areas.Identity.Data;
using DoctorsAgenda.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DoctorsAgenda.Data
{
    public class DocAgendaContext : IdentityDbContext<DoctorsAgendaUser>
    {
        public DocAgendaContext(DbContextOptions<DocAgendaContext> options)
            : base(options)
        {
        }

        public override DbSet<DoctorsAgendaUser> Users { get; set; }
        public DbSet<Agenda> Agenda { get; set; }
        public DbSet<Appointment> Appointment { get; set; }
        public DbSet<Calendar> Calendar { get; set; }
        public DbSet<Patient> Patient { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<DoctorsAgendaUser>().ToTable("User");


            builder.Entity<DoctorsAgendaUser>()
            .Property(d => d.Id)
            .ValueGeneratedOnAdd();


            builder.Entity<DoctorsAgendaUser>()
           .HasIndex(d => new { d.Email }).IsUnique();

            builder.Entity<DoctorsAgendaUser>()
           .HasIndex(d => new { d.UserName }).IsUnique();

            builder.Entity<DoctorsAgendaUser>()
           .HasIndex(d => new { d.PhoneNumber }).IsUnique();

            builder.Entity<Calendar>().ToTable("Calendar");
            builder.Entity<Appointment>().ToTable("Appointment");
            builder.Entity<Patient>().ToTable("Patient");
            builder.Entity<Agenda>().ToTable("Agenda");

            builder.Entity<Patient>()
           .HasOne(a => a.Agenda)
           .WithMany(p => p.Patients)
           .HasForeignKey(p => p.AgendasName)
           .HasPrincipalKey(a => a.AgendasName)
           .OnDelete(DeleteBehavior.Cascade)
           .IsRequired();

            builder.Entity<Patient>()
           .HasIndex(p => new { p.PatientName, p.PhoneNumber, p.AgendasName }).IsUnique(true);

            builder.Entity<Patient>()
           .Property(p => p.PatientId)
           .ValueGeneratedOnAdd();

            builder.Entity<Appointment>()
             .HasOne(c => c.Calendar)
             .WithMany(a => a.Appointments)
             .HasForeignKey(a => a.CalendarsName)
             .HasPrincipalKey(c => c.CalendarsName)
             .OnDelete(DeleteBehavior.Cascade)
             .IsRequired();

            builder.Entity<Appointment>()
           .HasIndex(a => new { a.StartDateTime, a.EndDateTime, a.PatientName, a.CalendarsName }).IsUnique(true);

            builder.Entity<Appointment>()
           .Property(a => a.AppointmentId)
           .ValueGeneratedOnAdd();

            builder.Entity<Calendar>()
            .HasOne(c => c.Agenda)
            .WithOne(a => a.Calendar)
            .HasForeignKey<Calendar>(c => c.AgendasName)
            .HasPrincipalKey<Agenda>(a => a.AgendasName)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

            builder.Entity<Calendar>()
           .HasIndex(c => new { c.AgendasName, c.CalendarsName }).IsUnique(true);

            builder.Entity<Calendar>()
            .Property(c => c.CalendarId)
            .ValueGeneratedOnAdd();

            builder.Entity<Agenda>()
           .HasOne(a => a.User)
           .WithOne(d => d.Agenda)
           .HasForeignKey<Agenda>(a => a.UserId)
           .HasPrincipalKey<DoctorsAgendaUser>(d => d.Id)
           .OnDelete(DeleteBehavior.Cascade)
           .IsRequired();

            builder.Entity<Agenda>()
           .HasIndex(a => new {a.AgendasName, a.UserId }).IsUnique(true);

            builder.Entity<Agenda>()
            .Property(c => c.AgendaId)
            .ValueGeneratedOnAdd();

        }
    }
}
