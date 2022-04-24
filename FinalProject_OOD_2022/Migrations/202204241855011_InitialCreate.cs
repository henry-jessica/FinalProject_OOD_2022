namespace FinalProject_OOD_2022.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        ZipCode = c.String(nullable: false, maxLength: 128),
                        Street = c.String(),
                        Town = c.String(),
                        County = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.ZipCode);
            
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PetID = c.Int(nullable: false),
                        VetID = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Time = c.Time(nullable: false, precision: 7),
                        Status = c.Int(nullable: false),
                        Appointment_PathWay = c.Int(nullable: false),
                        Bill_billingId = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Bills", t => t.Bill_billingId)
                .ForeignKey("dbo.Vets", t => t.VetID, cascadeDelete: true)
                .Index(t => t.VetID)
                .Index(t => t.Bill_billingId);
            
            CreateTable(
                "dbo.Bills",
                c => new
                    {
                        billingId = c.Int(nullable: false, identity: true),
                        price = c.Double(nullable: false),
                        Description = c.String(),
                        DatePayment = c.DateTime(nullable: false),
                        StatusPayment = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.billingId);
            
            CreateTable(
                "dbo.Pets",
                c => new
                    {
                        PetID = c.Int(nullable: false, identity: true),
                        PetName = c.String(),
                        PetImage = c.String(),
                        PetDBO = c.DateTime(nullable: false),
                        PetType = c.Int(nullable: false),
                        OwnerID = c.Int(nullable: false),
                        GenderType = c.Int(nullable: false),
                        Appointment_ID = c.Int(),
                    })
                .PrimaryKey(t => t.PetID)
                .ForeignKey("dbo.Appointments", t => t.Appointment_ID)
                .ForeignKey("dbo.PetOwners", t => t.OwnerID, cascadeDelete: true)
                .Index(t => t.OwnerID)
                .Index(t => t.Appointment_ID);
            
            CreateTable(
                "dbo.PetOwners",
                c => new
                    {
                        OwnerID = c.Int(nullable: false, identity: true),
                        OwnerFirstName = c.String(),
                        OwnerLastName = c.String(),
                        OwnerDBO = c.DateTime(nullable: false),
                        Address_ZipCode = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.OwnerID)
                .ForeignKey("dbo.Addresses", t => t.Address_ZipCode)
                .Index(t => t.Address_ZipCode);
            
            CreateTable(
                "dbo.Vets",
                c => new
                    {
                        VetID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        SecondName = c.String(),
                        VetSpeciality = c.Int(nullable: false),
                        DBO = c.DateTime(nullable: false),
                        Address_ZipCode = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.VetID)
                .ForeignKey("dbo.Addresses", t => t.Address_ZipCode)
                .Index(t => t.Address_ZipCode);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "VetID", "dbo.Vets");
            DropForeignKey("dbo.Vets", "Address_ZipCode", "dbo.Addresses");
            DropForeignKey("dbo.Pets", "OwnerID", "dbo.PetOwners");
            DropForeignKey("dbo.PetOwners", "Address_ZipCode", "dbo.Addresses");
            DropForeignKey("dbo.Pets", "Appointment_ID", "dbo.Appointments");
            DropForeignKey("dbo.Appointments", "Bill_billingId", "dbo.Bills");
            DropIndex("dbo.Vets", new[] { "Address_ZipCode" });
            DropIndex("dbo.PetOwners", new[] { "Address_ZipCode" });
            DropIndex("dbo.Pets", new[] { "Appointment_ID" });
            DropIndex("dbo.Pets", new[] { "OwnerID" });
            DropIndex("dbo.Appointments", new[] { "Bill_billingId" });
            DropIndex("dbo.Appointments", new[] { "VetID" });
            DropTable("dbo.Vets");
            DropTable("dbo.PetOwners");
            DropTable("dbo.Pets");
            DropTable("dbo.Bills");
            DropTable("dbo.Appointments");
            DropTable("dbo.Addresses");
        }
    }
}
