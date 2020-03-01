namespace SeminarskiRad.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ba2572b2-72d4-4374-ab86-5a10ace38ab1', N'admin@uciliste.com', 0, N'AK5/KlvcWOLySnzXlDEhZjycbVnGQbr/Efb5Ez7p03YxIScRYodxttck+LFd6wY3dg==', N'7c67825e-68a7-4685-aa9d-c8ac5eaf79e0', NULL, 0, 0, NULL, 1, 0, N'admin@uciliste.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'eb51f9d1-796a-46e2-8b5a-0abf4e6865ec', N'zaposlenik1@it-uciliste.com', 0, N'ALIph7RhZxUHGdLdRM7YwU/ajXXQTqJBGu6WN6+RFXraLecXLri0FlGHtTZ6x6rwSQ==', N'675b4be2-96c6-467b-b217-d43189a6087b', NULL, 0, 0, NULL, 1, 0, N'zaposlenik1@it-uciliste.com')
                
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'81782677-b68b-449c-b6b6-92e80c0e1cf2', N'Admin')
                
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ba2572b2-72d4-4374-ab86-5a10ace38ab1', N'81782677-b68b-449c-b6b6-92e80c0e1cf2')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
