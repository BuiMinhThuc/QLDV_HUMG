﻿// <auto-generated />
using System;
using BigProject.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BigProject.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250312105749_ver1")]
    partial class ver1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BigProject.Entities.ApprovalHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ApprovedById")
                        .HasColumnType("int");

                    b.Property<DateTime>("ApprovedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("HistoryType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAccept")
                        .HasColumnType("bit");

                    b.Property<int?>("RequestToBeOutstandingMemberId")
                        .HasColumnType("int");

                    b.Property<int?>("RewardDisciplineId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApprovedById");

                    b.HasIndex("RequestToBeOutstandingMemberId");

                    b.HasIndex("RewardDisciplineId");

                    b.ToTable("approvalHistories");
                });

            modelBuilder.Entity("BigProject.Entities.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DocumentContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DocumentTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlAvatar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("documents");
                });

            modelBuilder.Entity("BigProject.Entities.EmailConfirm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Exprired")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActiveAccount")
                        .HasColumnType("bit");

                    b.Property<bool>("IsConfirmed")
                        .HasColumnType("bit");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("emailConfirms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "123456",
                            CreateTime = new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Exprired = new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActiveAccount = true,
                            IsConfirmed = true,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Code = "123456",
                            CreateTime = new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Exprired = new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActiveAccount = true,
                            IsConfirmed = true,
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            Code = "123456",
                            CreateTime = new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Exprired = new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActiveAccount = true,
                            IsConfirmed = true,
                            UserId = 3
                        });
                });

            modelBuilder.Entity("BigProject.Entities.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EventEndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EventLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EventName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EventStartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UrlAvatar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("events");
                });

            modelBuilder.Entity("BigProject.Entities.EventJoin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("UserId");

                    b.ToTable("eventJoins");
                });

            modelBuilder.Entity("BigProject.Entities.MemberInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Class")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfJoining")
                        .HasColumnType("datetime2");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsOutstandingMember")
                        .HasColumnType("bit");

                    b.Property<string>("Nation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlaceOfJoining")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PoliticalTheory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("UrlAvatar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("religion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("memberInfos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Birthdate = new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Class = "string",
                            DateOfJoining = new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FullName = "string",
                            IsOutstandingMember = false,
                            Nation = "string",
                            PhoneNumber = "string",
                            PlaceOfJoining = "string",
                            PoliticalTheory = "string",
                            Status = 1,
                            UrlAvatar = "string",
                            UserId = 1,
                            religion = "string"
                        },
                        new
                        {
                            Id = 2,
                            Birthdate = new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Class = "string",
                            DateOfJoining = new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FullName = "string",
                            IsOutstandingMember = false,
                            Nation = "string",
                            PhoneNumber = "string",
                            PlaceOfJoining = "string",
                            PoliticalTheory = "string",
                            Status = 1,
                            UrlAvatar = "string",
                            UserId = 2,
                            religion = "string"
                        },
                        new
                        {
                            Id = 3,
                            Birthdate = new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Class = "string",
                            DateOfJoining = new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FullName = "string",
                            IsOutstandingMember = false,
                            Nation = "string",
                            PhoneNumber = "string",
                            PlaceOfJoining = "string",
                            PoliticalTheory = "string",
                            Status = 1,
                            UrlAvatar = "string",
                            UserId = 3,
                            religion = "string"
                        });
                });

            modelBuilder.Entity("BigProject.Entities.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Exprited")
                        .HasColumnType("datetime2");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("refreshTokens");
                });

            modelBuilder.Entity("BigProject.Entities.RequestToBeOutStandingMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MemberInfoId")
                        .HasColumnType("int");

                    b.Property<string>("RejectReason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MemberInfoId");

                    b.ToTable("requestToBeOutStandingMembers");
                });

            modelBuilder.Entity("BigProject.Entities.RewardDiscipline", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProposerId")
                        .HasColumnType("int");

                    b.Property<int>("RecipientId")
                        .HasColumnType("int");

                    b.Property<string>("RejectReason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("RewardOrDiscipline")
                        .HasColumnType("bit");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProposerId");

                    b.HasIndex("RecipientId");

                    b.ToTable("rewardDisciplines");
                });

            modelBuilder.Entity("BigProject.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Đoàn viên"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Bí thư đoàn viên"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Liên chi đoàn khoa"
                        });
                });

            modelBuilder.Entity("BigProject.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("MaSV")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "admin@gmail.com",
                            IsActive = true,
                            MaSV = "1111111111",
                            Password = "$2a$12$umDEKg3yORpv174r7kzKxO7Z.BVbw0HDzb44jCsvgjHGGn5rM6/Ky",
                            RoleId = 3,
                            Username = "admin"
                        },
                        new
                        {
                            Id = 2,
                            Email = "member@gmail.com",
                            IsActive = true,
                            MaSV = "1111111112",
                            Password = "$2a$12$umDEKg3yORpv174r7kzKxO7Z.BVbw0HDzb44jCsvgjHGGn5rM6/Ky",
                            RoleId = 1,
                            Username = "member"
                        },
                        new
                        {
                            Id = 3,
                            Email = "secretary@gmail.com",
                            IsActive = true,
                            MaSV = "1111111113",
                            Password = "$2a$12$umDEKg3yORpv174r7kzKxO7Z.BVbw0HDzb44jCsvgjHGGn5rM6/Ky",
                            RoleId = 2,
                            Username = "secretary"
                        });
                });

            modelBuilder.Entity("BigProject.Entities.ApprovalHistory", b =>
                {
                    b.HasOne("BigProject.Entities.User", "ApprovedBy")
                        .WithMany()
                        .HasForeignKey("ApprovedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BigProject.Entities.RequestToBeOutStandingMember", "RequestToBeOutstandingMember")
                        .WithMany()
                        .HasForeignKey("RequestToBeOutstandingMemberId");

                    b.HasOne("BigProject.Entities.RewardDiscipline", "RewardDiscipline")
                        .WithMany()
                        .HasForeignKey("RewardDisciplineId");

                    b.Navigation("ApprovedBy");

                    b.Navigation("RequestToBeOutstandingMember");

                    b.Navigation("RewardDiscipline");
                });

            modelBuilder.Entity("BigProject.Entities.Document", b =>
                {
                    b.HasOne("BigProject.Entities.User", "User")
                        .WithMany("documents")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BigProject.Entities.EmailConfirm", b =>
                {
                    b.HasOne("BigProject.Entities.User", "user")
                        .WithMany("emailConfirms")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("BigProject.Entities.EventJoin", b =>
                {
                    b.HasOne("BigProject.Entities.Event", "Event")
                        .WithMany("eventJoints")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BigProject.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BigProject.Entities.MemberInfo", b =>
                {
                    b.HasOne("BigProject.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BigProject.Entities.RefreshToken", b =>
                {
                    b.HasOne("BigProject.Entities.User", "User")
                        .WithMany("refreshTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BigProject.Entities.RequestToBeOutStandingMember", b =>
                {
                    b.HasOne("BigProject.Entities.MemberInfo", "MemberInfo")
                        .WithMany("requestToBeOutStandingMembers")
                        .HasForeignKey("MemberInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MemberInfo");
                });

            modelBuilder.Entity("BigProject.Entities.RewardDiscipline", b =>
                {
                    b.HasOne("BigProject.Entities.User", "Proposer")
                        .WithMany()
                        .HasForeignKey("ProposerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BigProject.Entities.User", "Recipient")
                        .WithMany()
                        .HasForeignKey("RecipientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Proposer");

                    b.Navigation("Recipient");
                });

            modelBuilder.Entity("BigProject.Entities.User", b =>
                {
                    b.HasOne("BigProject.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("BigProject.Entities.Event", b =>
                {
                    b.Navigation("eventJoints");
                });

            modelBuilder.Entity("BigProject.Entities.MemberInfo", b =>
                {
                    b.Navigation("requestToBeOutStandingMembers");
                });

            modelBuilder.Entity("BigProject.Entities.User", b =>
                {
                    b.Navigation("documents");

                    b.Navigation("emailConfirms");

                    b.Navigation("refreshTokens");
                });
#pragma warning restore 612, 618
        }
    }
}
