using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AdessoRideShare.Migrations
{
    public partial class Initial_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Longitude = table.Column<int>(type: "integer", nullable: false),
                    Latitude = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.Sql("INSERT INTO 'Cities' VALUES (1,'A1',10,5),(2,'A2',9,5),(3,'A3',8,5),(4,'A4',7,5),(5,'A5',6,5),(6,'A6',5,5),(7,'A7',4,5),(8,'A8',3,5),(9,'A9',2,5),(10,'A10',1,5),(11,'A11',-1,5),(12,'A12',-2,5),(13,'A13',-3,5),(14,'A14',-4,5),(15,'A15',-5,5),(16,'A16',-6,5),(17,'A17',-7,5),(18,'A18',-8,5),(19,'A19',-9,5),(20,'A20',-10,5),(21,'B1',10,4),(22,'B2',9,4),(23,'B3',8,4),(24,'B4',7,4),(25,'B5',6,4),(26,'B6',5,4),(27,'B7',4,4),(28,'B8',3,4),(29,'B9',2,4),(30,'B10',1,4),(31,'B11',-1,4),(32,'B12',-2,4),(33,'B13',-3,4),(35,'B15',-5,4),(36,'B16',-6,4),(37,'B17',-7,4),(38,'B18',-8,4),(39,'B19',-9,4),(40,'B20',-10,4),(41,'C1',10,3),(42,'C2',9,3),(43,'C3',8,3),(44,'C4',7,3),(45,'C5',6,3),(46,'C6',5,3),(47,'C7',4,3),(48,'C8',3,3),(49,'C9',2,3),(50,'C10',1,3),(51,'C11',-1,3),(52,'C12',-2,3),(53,'C13',-3,3),(54,'C14',-4,3),(55,'C15',-5,3),(56,'C16',-6,3),(57,'C17',-7,3),(58,'C18',-8,3),(59,'C19',-9,3),(60,'C20',-10,3),(61,'D1',10,2),(62,'D2',9,2),(63,'D3',8,2),(64,'D4',7,2),(65,'D5',6,2),(66,'D6',5,2),(67,'D7',4,2),(68,'D8',3,2),(69,'D9',2,2),(70,'D10',1,2),(71,'D11',-1,2),(72,'D12',-2,2),(73,'D13',-3,2),(74,'D14',-4,2),(75,'D15',-5,2),(76,'D16',-6,2),(77,'D17',-7,2),(78,'D18',-8,2),(79,'D19',-9,2),(80,'D20',-10,2),(81,'E1',10,1),(82,'E2',9,1),(83,'E3',8,1),(84,'E4',7,1),(85,'E5',6,1),(86,'E6',5,1),(87,'E7',4,1),(88,'E8',3,1),(89,'E9',2,1),(90,'E10',1,1),(91,'E11',-1,1),(92,'E12',-2,1),(93,'E13',-3,1),(94,'E14',-4,1),(95,'E15',-5,1),(96,'E16',-6,1),(97,'E17',-7,1),(98,'E18',-8,1),(99,'E19',-9,1),(100,'E20',-10,1),(101,'F1',10,-1),(102,'F2',9,-1),(103,'F3',8,-1),(104,'F4',7,-1),(105,'F5',6,-1),(106,'F6',5,-1),(107,'F7',4,-1),(108,'F8',3,-1),(109,'F9',2,-1),(110,'F10',1,-1),(111,'F11',-1,-1),(112,'F12',-2,-1),(113,'F13',-3,-1),(114,'F14',-4,-1),(115,'F15',-5,-1),(116,'F16',-6,-1),(117,'F17',-7,-1),(118,'F18',-8,-1),(119,'F19',-9,-1),(120,'F20',-10,-1),(121,'G1',10,-2),(122,'G2',9,-2),(123,'G3',8,-2),(124,'G4',7,-2),(125,'G5',6,-2),(126,'G6',5,-2),(127,'G7',4,-2),(128,'G8',3,-2),(129,'G9',2,-2),(130,'G10',1,-2),(131,'G11',-1,-2),(132,'G12',-2,-2),(133,'G13',-3,-2),(134,'G14',-4,-2),(135,'G15',-5,-2),(136,'G16',-6,-2),(137,'G17',-7,-2),(138,'G18',-8,-2),(139,'G19',-9,-2),(140,'G20',-10,-2),(141,'H1',10,-3),(142,'H2',9,-3),(143,'H3',8,-3),(144,'H4',7,-3),(145,'H5',6,-3),(146,'H6',5,-3),(147,'H7',4,-3),(148,'H8',3,-3),(149,'H9',2,-3),(150,'H10',1,-3),(151,'H11',-1,-3),(152,'H12',-2,-3),(153,'H13',-3,-3),(154,'H14',-4,-3),(155,'H15',-5,-3),(156,'H16',-6,-3),(157,'H17',-7,-3),(158,'H18',-8,-3),(159,'H19',-9,-3),(160,'H20',-10,-3),(161,'I1',10,-4),(162,'I2',9,-4),(163,'I3',8,-4),(164,'I4',7,-4),(165,'I5',6,-4),(166,'I6',5,-4),(167,'I7',4,-4),(168,'I8',3,-4),(169,'I9',2,-4),(170,'I10',1,-4),(171,'I11',-1,-4),(172,'I12',-2,-4),(173,'I13',-3,-4),(174,'I14',-4,-4),(175,'I15',-5,-4),(176,'I16',-6,-4),(177,'I17',-7,-4),(178,'I18',-8,-4),(179,'I19',-9,-4),(180,'I20',-10,-4),(181,'J1',10,-5),(182,'J2',9,-5),(183,'J3',8,-5),(184,'J4',7,-5),(185,'J5',6,-5),(186,'J6',5,-5),(187,'J7',4,-5),(188,'J8',3,-5),(189,'J9',2,-5),(190,'J10',1,-5),(191,'J11',-1,-5),(192,'J12',-2,-5),(193,'J13',-3,-5),(194,'J14',-4,-5),(195,'J15',-5,-5),(196,'J16',-6,-5),(197,'J17',-7,-5),(198,'J18',-8,-5),(199,'J19',-9,-5),(200,'J20',-10,-5);  ");
           
            migrationBuilder.CreateTable(
                name: "RidePlans",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FromId = table.Column<int>(type: "integer", nullable: false),
                    WhereId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    NumberOfSeats = table.Column<int>(type: "integer", nullable: false),
                    IsPublished = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RidePlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RidePlans_Cities_FromId",
                        column: x => x.FromId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RidePlans_Cities_WhereId",
                        column: x => x.WhereId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SharedRides",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RidePlanId = table.Column<long>(type: "bigint", nullable: false),
                    PassengerName = table.Column<string>(type: "text", nullable: false),
                    PassengerSurName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SharedRides", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SharedRides_RidePlans_RidePlanId",
                        column: x => x.RidePlanId,
                        principalTable: "RidePlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RidePlans_FromId",
                table: "RidePlans",
                column: "FromId");

            migrationBuilder.CreateIndex(
                name: "IX_RidePlans_WhereId",
                table: "RidePlans",
                column: "WhereId");

            migrationBuilder.CreateIndex(
                name: "IX_SharedRides_RidePlanId",
                table: "SharedRides",
                column: "RidePlanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SharedRides");

            migrationBuilder.DropTable(
                name: "RidePlans");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
