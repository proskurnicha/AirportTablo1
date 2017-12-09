namespace AirportTablo1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Adddata : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Flights VALUES   ('GJB', '2017-12-14 15:00', 0, 6, 1, 'Варшава', 'Киев', 'Комета', '2017-12-14 15:00')");
            Sql("INSERT INTO Flights VALUES  ('SDG', '2017-12-14 14:05', 1, 6, 2, 'Киев', 'Москва', 'Летай легко', '2017-12-14 14:05')");
            Sql("INSERT INTO Flights VALUES  ('FBS', '2017-12-14 14:30', 0, 6, 3,'Лондон', 'Киев', 'Комета', '2017-12-14 14:30')");
            Sql("INSERT INTO Flights VALUES  ('LUW', '2017-12-14 14:20', 1, 6, 5, 'Киев', 'Минск', 'Полёты без ограничений', '2017-12-14 14:20')");
            Sql("INSERT INTO Flights VALUES  ('PTW', '2017-12-14 14:10', 1, 6, 4, 'Киев', 'Афины', 'Быстрый полёт', '2017-12-14 14:10')");
            Sql("INSERT INTO Flights VALUES  ('PHD', '2017-12-14 14:50', 0, 6, 1, 'Амстердам', 'Киев', 'Полетели', '2017-12-14 14:50')");
            Sql("INSERT INTO Flights VALUES  ('VTR', '2017-12-14 14:40', 1, 6, 2, 'Киев', 'Париж', 'Летим с нами', '2017-12-14 14:40')");

        }

        public override void Down()
        {
        }
    }
}
