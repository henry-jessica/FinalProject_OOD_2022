namespace FinalProject_OOD_2022.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PetData : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pets", "Appointment_ID", "dbo.Appointments");
            DropIndex("dbo.Pets", new[] { "Appointment_ID" });
            DropColumn("dbo.Pets", "Appointment_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pets", "Appointment_ID", c => c.Int());
            CreateIndex("dbo.Pets", "Appointment_ID");
            AddForeignKey("dbo.Pets", "Appointment_ID", "dbo.Appointments", "ID");
        }
    }
}
