﻿using HotelProjectEntityLayer.Concrete;
using HotelProjectWebApi.Controllers;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProjectDataAccessLayer.Concrete
{

    public class Context: IdentityDbContext< AppUser,AppRole,int>
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-7AVL9GC\\SQLSERVER2022;Database=HotelReservationDB;Trusted_Connection=True;TrustServerCertificate=True;");

        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Service> Sevices { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<SendMessage> SendMessages { get; set; }
        public DbSet<MessageCategory> MessageCategories { get; set; }
        public DbSet<WorkLocation> WorkLocations { get; set; }

    }
}
