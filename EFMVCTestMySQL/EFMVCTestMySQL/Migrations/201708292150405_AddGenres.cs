namespace EFMVCTestMySQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO genres (Id ,Name) VALUES (1,'Comedy')");
            Sql("INSERT INTO genres (Id ,Name) VALUES (2,'Action')");
            Sql("INSERT INTO genres (Id ,Name) VALUES (3,'Family')");
            Sql("INSERT INTO genres (Id ,Name) VALUES (4,'Romance')");
            Sql("INSERT INTO genres (Id ,Name) VALUES (5,'Sci-Fi')");
        }
        
        public override void Down()
        {
        }
    }
}
