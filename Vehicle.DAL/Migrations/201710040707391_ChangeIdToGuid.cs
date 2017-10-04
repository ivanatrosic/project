namespace Vehicle.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeIdToGuid : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VehicleModel", "MakeId", "dbo.VehicleMake");
            DropIndex("dbo.VehicleModel", new[] { "MakeId" });
            DropPrimaryKey("dbo.VehicleMake");
            DropPrimaryKey("dbo.VehicleModel");
                   DropColumn("dbo.VehicleMake", "Id");
                   AddColumn("dbo.VehicleMake", "Id", c => c.Guid(nullable: false, identity: true));
            DropColumn("dbo.VehicleModel", "Id");
            AddColumn("dbo.VehicleModel", "Id", c => c.Guid(nullable: false, identity: true));
            DropColumn("dbo.VehicleModel", "MakeId");
            AddColumn("dbo.VehicleModel", "MakeId", c => c.Guid(nullable: false, identity: true));

            AddPrimaryKey("dbo.VehicleMake", "Id");
            AddPrimaryKey("dbo.VehicleModel", "Id");
            CreateIndex("dbo.VehicleModel", "MakeId");
            AddForeignKey("dbo.VehicleModel", "MakeId", "dbo.VehicleMake", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VehicleModel", "MakeId", "dbo.VehicleMake");
            DropIndex("dbo.VehicleModel", new[] { "MakeId" });
            DropPrimaryKey("dbo.VehicleModel");
            DropPrimaryKey("dbo.VehicleMake");
                    DropColumn("dbo.VehicleMake", "Id");
                    AddColumn("dbo.VehicleMake", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.VehicleModel", "Id");
            AddColumn("dbo.VehicleModel", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.VehicleModel", "MakeId");
            AddColumn("dbo.VehicleModel", "MakeId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.VehicleModel", "Id");
            AddPrimaryKey("dbo.VehicleMake", "Id");
            CreateIndex("dbo.VehicleModel", "MakeId");
            AddForeignKey("dbo.VehicleModel", "MakeId", "dbo.VehicleMake", "Id");
        }
    }
}
