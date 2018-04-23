namespace OnBoardManagmentSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Mentors",
                c => new
                    {
                        M_Id = c.Int(nullable: false, identity: true),
                        M_Name = c.String(),
                    })
                .PrimaryKey(t => t.M_Id);
            
            CreateTable(
                "dbo.OnBoarders",
                c => new
                    {
                        O_Id = c.Int(nullable: false, identity: true),
                        O_Name = c.String(),
                        O_RotationNo = c.String(),
                        ReportingManager = c.String(),
                        M_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.O_Id);
            
            CreateTable(
                "dbo.ProjectAssignments",
                c => new
                    {
                        PA_Id = c.Int(nullable: false, identity: true),
                        P_Id = c.Int(nullable: false),
                        O_Id = c.Int(nullable: false),
                        O_RotationNo = c.String(),
                        StartDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PA_Id);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        P_Id = c.Int(nullable: false, identity: true),
                        P_Name = c.String(),
                        P_Technology = c.String(),
                        M_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.P_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        U_Id = c.Int(nullable: false, identity: true),
                        U_Username = c.String(),
                        U_Password = c.String(),
                        U_Role = c.String(),
                    })
                .PrimaryKey(t => t.U_Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Projects");
            DropTable("dbo.ProjectAssignments");
            DropTable("dbo.OnBoarders");
            DropTable("dbo.Mentors");
        }
    }
}
