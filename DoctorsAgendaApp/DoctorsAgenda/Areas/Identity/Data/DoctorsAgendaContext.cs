using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoctorsAgenda.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DoctorsAgenda.Areas.Identity.Data
{
    public class DoctorsAgendaContext : IdentityDbContext<DoctorsAgendaUser>
    {
        public override DbSet<DoctorsAgendaUser> Users { get; set; }
        public DbSet<Agenda> Agenda { get; set; }
        public DbSet<Appointment> Appointment { get; set; }
        public DbSet<Calendar> Calendar { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DoctorsAgendaContext(DbContextOptions<DoctorsAgendaContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<DoctorsAgendaUser>().ToTable("User");
            builder.Entity<Appointment>().ToTable("Appointment");
            builder.Entity<Patient>().ToTable("Patient");
            builder.Entity<Agenda>().ToTable("Agenda");
            builder.Entity<Calendar>().ToTable("Calendar");

            builder.Entity<DoctorsAgendaUser>()
            .HasIndex(d => new { d.Email }).IsUnique();

            builder.Entity<DoctorsAgendaUser>()
            .HasIndex(d => new { d.UserName }).IsUnique();

            builder.Entity<DoctorsAgendaUser>()
            .HasIndex(d => new { d.PhoneNumber }).IsUnique();

            builder.Entity<Patient>()
            .HasIndex(p => new { p.PatientsName, p.PhoneNumber, p.DoctorsName }).IsUnique(true);

            builder.Entity<Patient>()
            .HasOne(p => p.Agenda)
            .WithMany(a => a.Patients)
            .HasForeignKey(p => p.DoctorsName)
            .HasPrincipalKey(a => a.DoctorsName)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

            builder.Entity<Agenda>()
            .HasOne(a => a.User)
            .WithOne(d => d.Agenda)
            .HasForeignKey<Agenda>(a => a.UserName)
            .HasPrincipalKey<DoctorsAgendaUser>(d => d.UserName)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

            builder.Entity<Agenda>()
            .HasIndex(a => new { a.UserName }).IsUnique();

            builder.Entity<Agenda>()
           .HasIndex(a => new { a.DoctorsName }).IsUnique();

            builder.Entity<Appointment>()
            .HasIndex(a => new { a.AppointmentId }).IsUnique();

            builder.Entity<Appointment>()
           .HasIndex(a => new { a.DoctorsName, a.PatientName, a.StartDateTime, a.EndDateTime }).IsUnique(true);

            builder.Entity<Appointment>()
           .HasOne(a => a.Patient)
           .WithMany(p => p.Appointments)
           .HasForeignKey(a => a.PatientName)
           .HasPrincipalKey(p => p.PatientsName)
           .OnDelete(DeleteBehavior.Restrict)
           .IsRequired();

            builder.Entity<Appointment>()
           .HasOne(a => a.Calendar)
           .WithMany(c => c.Appointments)
           .HasForeignKey(a => a.DoctorsName)
           .HasPrincipalKey(a => a.DoctorsName)
           .OnDelete(DeleteBehavior.Cascade)
           .IsRequired();

            builder.Entity<Calendar>()
             .HasOne(c => c.Agenda)
             .WithOne(a => a.Calendar)
             .HasForeignKey<Calendar>(a => a.DoctorsName)
             .HasPrincipalKey<Agenda>(d => d.DoctorsName)
             .OnDelete(DeleteBehavior.Cascade)
             .IsRequired();

            builder.Entity<Calendar>()
            .HasIndex(c => new { c.DoctorsName }).IsUnique();

            builder.Entity<Calendar>()
            .HasIndex(c => new { c.CalendarId }).IsUnique();
        }
    }
}
