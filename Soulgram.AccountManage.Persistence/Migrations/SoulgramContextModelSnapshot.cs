﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Soulgram.AccountManage.Persistence;

#nullable disable

namespace Soulgram.AccountManage.Persistence.Migrations
{
    [DbContext(typeof(SoulgramContext))]
    partial class SoulgramContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Soulgram.AccountManage.Domain.Entities.Hobby", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CountOfUsage")
                        .HasColumnType("int");

                    b.Property<string>("Desription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsGroupOnly")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasDatabaseName("UX_Hobby_Name");

                    SqlServerIndexBuilderExtensions.IsClustered(b.HasIndex("Name"), false);

                    b.ToTable("Hobbies");
                });

            modelBuilder.Entity("Soulgram.AccountManage.Domain.Entities.HobbyImage", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("HobbyId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ImgUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HobbyId");

                    b.ToTable("HobbyImages");
                });

            modelBuilder.Entity("Soulgram.AccountManage.Domain.Entities.ProfileImage", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImgUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ProfileImages");
                });

            modelBuilder.Entity("Soulgram.AccountManage.Domain.Entities.UserHobby", b =>
                {
                    b.Property<string>("HobbieId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("HobbieId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserHobbies");
                });

            modelBuilder.Entity("Soulgram.AccountManage.Domain.Entities.UserInfo", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("UserInfos");
                });

            modelBuilder.Entity("Soulgram.AccountManage.Domain.Entities.HobbyImage", b =>
                {
                    b.HasOne("Soulgram.AccountManage.Domain.Entities.Hobby", "Hobby")
                        .WithMany("HobbyImages")
                        .HasForeignKey("HobbyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hobby");
                });

            modelBuilder.Entity("Soulgram.AccountManage.Domain.Entities.ProfileImage", b =>
                {
                    b.HasOne("Soulgram.AccountManage.Domain.Entities.UserInfo", "UserInfo")
                        .WithMany("ProfileImages")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserInfo");
                });

            modelBuilder.Entity("Soulgram.AccountManage.Domain.Entities.UserHobby", b =>
                {
                    b.HasOne("Soulgram.AccountManage.Domain.Entities.Hobby", "Hobby")
                        .WithMany("UserHobbies")
                        .HasForeignKey("HobbieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Soulgram.AccountManage.Domain.Entities.UserInfo", "UserInfo")
                        .WithMany("UserHobbies")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hobby");

                    b.Navigation("UserInfo");
                });

            modelBuilder.Entity("Soulgram.AccountManage.Domain.Entities.Hobby", b =>
                {
                    b.Navigation("HobbyImages");

                    b.Navigation("UserHobbies");
                });

            modelBuilder.Entity("Soulgram.AccountManage.Domain.Entities.UserInfo", b =>
                {
                    b.Navigation("ProfileImages");

                    b.Navigation("UserHobbies");
                });
#pragma warning restore 612, 618
        }
    }
}
