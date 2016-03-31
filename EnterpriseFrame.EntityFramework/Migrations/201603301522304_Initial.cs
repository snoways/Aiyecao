namespace EnterpriseFrame.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminID = c.Int(nullable: false, identity: true),
                        RoleID = c.Int(),
                        AdminName = c.String(nullable: false, maxLength: 20),
                        AdminPwd = c.String(nullable: false, maxLength: 20),
                        CreateTime = c.DateTime(),
                        LastLoginTime = c.DateTime(),
                        LoginCount = c.Int(),
                        IsEnable = c.Boolean(),
                    })
                .PrimaryKey(t => t.AdminID)
                .ForeignKey("dbo.Roles", t => t.RoleID)
                .Index(t => t.RoleID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleID = c.Int(nullable: false, identity: true),
                        RoleName = c.String(nullable: false, maxLength: 20),
                        RoleDesc = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.RoleID);
            
            CreateTable(
                "dbo.Role_Permission",
                c => new
                    {
                        RmID = c.Int(nullable: false, identity: true),
                        PermissionID = c.Int(),
                        RoleID = c.Int(),
                    })
                .PrimaryKey(t => t.RmID)
                .ForeignKey("dbo.Permission", t => t.PermissionID)
                .ForeignKey("dbo.Roles", t => t.RoleID)
                .Index(t => t.PermissionID)
                .Index(t => t.RoleID);
            
            CreateTable(
                "dbo.Permission",
                c => new
                    {
                        PermissionID = c.Int(nullable: false, identity: true),
                        ModuleName = c.String(maxLength: 20),
                        ModuleUrl = c.String(maxLength: 20),
                        ParentID = c.Int(),
                    })
                .PrimaryKey(t => t.PermissionID);
            
            CreateTable(
                "dbo.ArticleInfo",
                c => new
                    {
                        ArtID = c.Int(nullable: false, identity: true),
                        TypeID = c.Int(),
                        ArtTitle = c.String(maxLength: 300),
                        ArtDesc = c.String(),
                        ArtContent = c.String(unicode: false, storeType: "text"),
                        ArtAuthor = c.String(maxLength: 20),
                        ArtState = c.Boolean(),
                        CreateTime = c.DateTime(),
                        ReleaseTime = c.DateTime(),
                        ArtImgUrl = c.String(maxLength: 300),
                        ArtTags = c.String(maxLength: 300),
                        ArtSource = c.String(maxLength: 300),
                    })
                .PrimaryKey(t => t.ArtID)
                .ForeignKey("dbo.ArticleType", t => t.TypeID)
                .Index(t => t.TypeID);
            
            CreateTable(
                "dbo.ArticleRelation",
                c => new
                    {
                        RelationID = c.Int(nullable: false, identity: true),
                        ArtID = c.Int(),
                        BrowseNum = c.Int(),
                        ZambiaNum = c.Int(),
                    })
                .PrimaryKey(t => t.RelationID)
                .ForeignKey("dbo.ArticleInfo", t => t.ArtID)
                .Index(t => t.ArtID);
            
            CreateTable(
                "dbo.ArticleType",
                c => new
                    {
                        TypeID = c.Int(nullable: false, identity: true),
                        TypeName = c.String(maxLength: 20),
                        TypeDesc = c.String(),
                        ParentID = c.Int(),
                    })
                .PrimaryKey(t => t.TypeID);
            
            CreateTable(
                "dbo.FriendsLink",
                c => new
                    {
                        LinkID = c.Int(nullable: false, identity: true),
                        LinkTitle = c.String(maxLength: 100),
                        LinkUrl = c.String(maxLength: 300),
                        IsShow = c.Boolean(),
                        Top = c.Int(),
                    })
                .PrimaryKey(t => t.LinkID);
            
            CreateTable(
                "dbo.SiteALlConfig",
                c => new
                    {
                        ConfigID = c.Int(nullable: false, identity: true),
                        Key = c.String(maxLength: 100),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.ConfigID);
            
            CreateTable(
                "dbo.SiteMessage",
                c => new
                    {
                        MsgID = c.Int(nullable: false, identity: true),
                        MsgUserName = c.String(maxLength: 20),
                        MsgPhone = c.String(maxLength: 20),
                        MsgQQ = c.String(maxLength: 20),
                        MsgContent = c.String(unicode: false, storeType: "text"),
                        MsgReply = c.String(unicode: false, storeType: "text"),
                        MsgIsShow = c.Boolean(),
                        MsgTime = c.DateTime(),
                        ReplyTime = c.DateTime(),
                        IP = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.MsgID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ArticleInfo", "TypeID", "dbo.ArticleType");
            DropForeignKey("dbo.ArticleRelation", "ArtID", "dbo.ArticleInfo");
            DropForeignKey("dbo.Role_Permission", "RoleID", "dbo.Roles");
            DropForeignKey("dbo.Role_Permission", "PermissionID", "dbo.Permission");
            DropForeignKey("dbo.Admins", "RoleID", "dbo.Roles");
            DropIndex("dbo.ArticleRelation", new[] { "ArtID" });
            DropIndex("dbo.ArticleInfo", new[] { "TypeID" });
            DropIndex("dbo.Role_Permission", new[] { "RoleID" });
            DropIndex("dbo.Role_Permission", new[] { "PermissionID" });
            DropIndex("dbo.Admins", new[] { "RoleID" });
            DropTable("dbo.SiteMessage");
            DropTable("dbo.SiteALlConfig");
            DropTable("dbo.FriendsLink");
            DropTable("dbo.ArticleType");
            DropTable("dbo.ArticleRelation");
            DropTable("dbo.ArticleInfo");
            DropTable("dbo.Permission");
            DropTable("dbo.Role_Permission");
            DropTable("dbo.Roles");
            DropTable("dbo.Admins");
        }
    }
}
