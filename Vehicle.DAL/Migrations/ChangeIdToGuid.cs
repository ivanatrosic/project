using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;

namespace Vehicle.DAL.Migrations
{
    //class ChangeIdToGuid:DbMigration
    //{
    //    public override void Up()
    //    {
    //        DropPrimaryKey("dbo.VehicleMake");

    //        DropColumn("dbo.VehicleMake", "Id");
    //        AddColumn("dbo.VehicleMake", "Id", c => c.Guid(nullable: false, identity: true));

    //        AddPrimaryKey("dbo.VehicleMake", "Id");

    //        DropPrimaryKey("dbo.VehicleModel");

    //        DropColumn("dbo.VehicleModel", "Id");
    //        AddColumn("dbo.VehicleModel", "Id", c => c.Guid(nullable: false, identity: true));

    //        AddPrimaryKey("dbo.VehicleModel", "Id");

    //        DropForeignKey("dbo.VehicleModel", "MakeId");

    //        DropColumn("dbo.VehicleModel", "MakeId");
    //        AddColumn("dbo.VehicleModel", "MakeId", c => c.Guid(nullable: false, identity: true));

    //        AddForeignKey("dbo.VehicleModel", "MakeId", "dbo.VehicleMake");
    //    }

    //    public override void Down()
    //    {
    //        DropPrimaryKey("dbo.VehicleMake");

    //        DropColumn("dbo.VehicleMake", "Id");
    //        AddColumn("dbo.VehicleMake", "Id", c => c.Int(nullable: false, identity: true));

    //        AddPrimaryKey("dbo.VehicleMake", "Id");

    //        DropPrimaryKey("dbo.VehicleModel");

    //        DropColumn("dbo.VehicleModel", "Id");
    //        AddColumn("dbo.VehicleModel", "Id", c => c.Int(nullable: false, identity: true));

    //        AddPrimaryKey("dbo.VehicleModel", "Id");

    //        DropForeignKey("dbo.VehicleModel", "MakeId");
    //        DropColumn("dbo.VehicleModel", "MakeId");
    //        AddColumn("dbo.VehicleModel", "MakeId", c => c.Int(nullable: false, identity: true));
    //        AddForeignKey("dbo.VehicleModel", "MakeId", "dbo.VehicleMake");
    //    }
    //}
}
