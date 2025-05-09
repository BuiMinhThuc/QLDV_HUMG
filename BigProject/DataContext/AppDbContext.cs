﻿using BigProject.Entities;
using BigProject.Enums;
using Microsoft.EntityFrameworkCore;
using System;

namespace BigProject.DataContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Thiết lập quan hệ không xóa cascade
            modelBuilder.Entity<RewardDiscipline>()
                .HasOne(x => x.Proposer)
                .WithMany()
                .HasForeignKey(x => x.ProposerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RewardDiscipline>()
                .HasOne(x => x.Recipient)
                .WithMany()
                .HasForeignKey(x => x.RecipientId)
                .OnDelete(DeleteBehavior.Restrict);

            // Mật khẩu là 123456789@A
            var password = "$2a$12$umDEKg3yORpv174r7kzKxO7Z.BVbw0HDzb44jCsvgjHGGn5rM6/Ky";
            var user1 = new User { Id = 1, Username = "admin", Email = "admin@gmail.com", Password = password, RoleId = 3, MaSV = "1111111111", IsActive = true };
            var user2 = new User { Id = 2, Username = "member", Email = "member@gmail.com", Password = password, RoleId = 1, MaSV = "1111111112", IsActive = true };
            var user3 = new User { Id = 3, Username = "secretary", Email = "secretary@gmail.com", Password = password, RoleId = 2, MaSV = "1111111113", IsActive = true };
            modelBuilder.Entity<User>().HasData(user1, user2, user3);

            var user1MemberInfo = new MemberInfo { Id = 1, Class = "string", Birthdate = DateTime.UtcNow, FullName = "string", Nation = "string", religion = "string", PhoneNumber = "string", UrlAvatar = "string", PoliticalTheory = "string", DateOfJoining = DateTime.UtcNow, PlaceOfJoining = "string", IsOutstandingMember = false, Status = MemberInfoEnum.studying, UserId = 1 };
            var user2MemberInfo = new MemberInfo { Id = 2, Class = "string", Birthdate = DateTime.UtcNow, FullName = "string", Nation = "string", religion = "string", PhoneNumber = "string", UrlAvatar = "string", PoliticalTheory = "string", DateOfJoining = DateTime.UtcNow, PlaceOfJoining = "string", IsOutstandingMember = false, Status = MemberInfoEnum.studying, UserId = 2 };
            var user3MemberInfo = new MemberInfo { Id = 3, Class = "string", Birthdate = DateTime.UtcNow, FullName = "string", Nation = "string", religion = "string", PhoneNumber = "string", UrlAvatar = "string", PoliticalTheory = "string", DateOfJoining = DateTime.UtcNow, PlaceOfJoining = "string", IsOutstandingMember = false, Status = MemberInfoEnum.studying, UserId = 3 };
            modelBuilder.Entity<MemberInfo>().HasData(user1MemberInfo, user2MemberInfo, user3MemberInfo);

            var role1 = new Role { Id = 1, Name = "Đoàn viên" };
            var role2 = new Role { Id = 2, Name = "Bí thư đoàn viên" };
            var role3 = new Role { Id = 3, Name = "Liên chi đoàn khoa" };
            modelBuilder.Entity<Role>().HasData(role1, role2, role3);

            var user1AccountActive = new EmailConfirm { Id = 1, Code = "123456", IsActiveAccount = true, CreateTime = DateTime.UtcNow, IsConfirmed = true, Exprired = DateTime.UtcNow.AddDays(1), UserId = 1 };
            var user2AccountActive = new EmailConfirm { Id = 2, Code = "123456", IsActiveAccount = true, CreateTime = DateTime.UtcNow, IsConfirmed = true, Exprired = DateTime.UtcNow.AddDays(1), UserId = 2 };
            var user3AccountActive = new EmailConfirm { Id = 3, Code = "123456", IsActiveAccount = true, CreateTime = DateTime.UtcNow, IsConfirmed = true, Exprired = DateTime.UtcNow.AddDays(1), UserId = 3 };
            modelBuilder.Entity<EmailConfirm>().HasData(user1AccountActive, user2AccountActive, user3AccountActive);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<EmailConfirm> emailConfirms { get; set; }
        public DbSet<Event> events { get; set; }
        public DbSet<EventJoin> eventJoins { get; set; }
        public DbSet<RefreshToken> refreshTokens { get; set; }
        public DbSet<RewardDiscipline> rewardDisciplines { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<MemberInfo> memberInfos { get; set; }
        public DbSet<Document> documents { get; set; }
        public DbSet<RequestToBeOutStandingMember> requestToBeOutStandingMembers { get; set; }
        public DbSet<ApprovalHistory> approvalHistories { get; set; }
    }
}
