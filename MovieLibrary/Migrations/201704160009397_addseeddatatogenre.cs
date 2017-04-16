namespace MovieLibrary.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class addseeddatatogenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Jazz')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Country')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Blues')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Rock')");
        }

        public override void Down()
        {
        }
    }
}
