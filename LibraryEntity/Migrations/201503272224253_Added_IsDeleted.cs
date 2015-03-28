namespace LibraryEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_IsDeleted : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "IsDeleted");
        }
    }
}
