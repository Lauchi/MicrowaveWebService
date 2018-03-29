﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using SqlAdapter;
using System;

namespace SqlAdapter.Migrations.Hangfire
{
    [DbContext(typeof(HangfireContext))]
    partial class HangfireContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("Domain.DomainEventBase", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("CreatedAt");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<Guid>("EntityId");

                    b.HasKey("Id");

                    b.ToTable("EventQueue");

                    b.HasDiscriminator<string>("Discriminator").HasValue("DomainEventBase");
                });

            modelBuilder.Entity("Domain.Posts.PostCreateEvent", b =>
                {
                    b.HasBaseType("Domain.DomainEventBase");


                    b.ToTable("PostCreateEvent");

                    b.HasDiscriminator().HasValue("PostCreateEvent");
                });

            modelBuilder.Entity("Domain.Users.UserAddPostEvent", b =>
                {
                    b.HasBaseType("Domain.DomainEventBase");

                    b.Property<Guid>("Deleted");

                    b.Property<Guid>("PostId");

                    b.ToTable("UserAddPostEvent");

                    b.HasDiscriminator().HasValue("UserAddPostEvent");
                });

            modelBuilder.Entity("Domain.Users.UserCreateEvent", b =>
                {
                    b.HasBaseType("Domain.DomainEventBase");


                    b.ToTable("UserCreateEvent");

                    b.HasDiscriminator().HasValue("UserCreateEvent");
                });

            modelBuilder.Entity("Domain.Users.UserUpdateAgeEvent", b =>
                {
                    b.HasBaseType("Domain.DomainEventBase");

                    b.Property<int>("Age");

                    b.ToTable("UserUpdateAgeEvent");

                    b.HasDiscriminator().HasValue("UserUpdateAgeEvent");
                });

            modelBuilder.Entity("Domain.Users.UserUpdateNameEvent", b =>
                {
                    b.HasBaseType("Domain.DomainEventBase");

                    b.Property<string>("Name");

                    b.ToTable("UserUpdateNameEvent");

                    b.HasDiscriminator().HasValue("UserUpdateNameEvent");
                });
#pragma warning restore 612, 618
        }
    }
}
