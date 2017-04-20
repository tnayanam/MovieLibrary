namespace MovieLibrary.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class seeduser : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO[dbo].[AspNetUsers]([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'02d0ae7c-21f8-45cd-8640-c04109f8671d', N'admin@vidly.com', 0, N'AOHoVzofD+yZeLzOiwkreCKUp/0ixmSfssmTYUbOmCncq/bfmteX3PcAJrXqrBXsxg==', N'b4d85462-b1b9-41a3-87ff-d2388b0e5b9b', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                INSERT INTO[dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'ed93c0c6-77ed-469e-b2df-f56ff44d5a91', N'guest@vidly.com', 0, N'ALhOY59E1zFSKQa8ifd8NkDvkFcrOrKHR6dKtevTlf7FUJLTfMBh9qj2CqP+V1itKA==', N'da83f5f8-8556-4958-bee8-20d318d2cf18', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'c24a2c4c-462b-4e1d-abcb-311a0851ad3a', N'CanManageMovies')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'02d0ae7c-21f8-45cd-8640-c04109f8671d', N'c24a2c4c-462b-4e1d-abcb-311a0851ad3a')
                ");
        }

        public override void Down()
        {
        }
    }
}
