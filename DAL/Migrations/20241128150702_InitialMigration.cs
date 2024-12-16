using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PartAllProcessData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartAllProcessData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AutoScrewingProcessData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HoleNumber = table.Column<int>(type: "int", nullable: false),
                    DateTimeStarted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Torque = table.Column<float>(type: "real", nullable: true),
                    Angle = table.Column<float>(type: "real", nullable: true),
                    OK = table.Column<bool>(type: "bit", nullable: true),
                    NOK = table.Column<bool>(type: "bit", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    DateTimeFinished = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoScrewingProcessData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AutoScrewingProcessData_PartAllProcessData_PartId",
                        column: x => x.PartId,
                        principalTable: "PartAllProcessData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConductivityProcessData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTimeStarted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Min = table.Column<float>(type: "real", nullable: true),
                    Value = table.Column<float>(type: "real", nullable: true),
                    Max = table.Column<float>(type: "real", nullable: true),
                    OK = table.Column<bool>(type: "bit", nullable: true),
                    NOK = table.Column<bool>(type: "bit", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    DateTimeFinished = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConductivityProcessData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConductivityProcessData_PartAllProcessData_PartId",
                        column: x => x.PartId,
                        principalTable: "PartAllProcessData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FitAndFunctionProcessData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTimeStarted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OK = table.Column<bool>(type: "bit", nullable: true),
                    NOK = table.Column<bool>(type: "bit", nullable: true),
                    OverallStatus = table.Column<int>(type: "int", nullable: true),
                    LeftOK = table.Column<bool>(type: "bit", nullable: true),
                    LeftNOK = table.Column<bool>(type: "bit", nullable: true),
                    LeftStatus = table.Column<int>(type: "int", nullable: true),
                    RightOK = table.Column<bool>(type: "bit", nullable: true),
                    RightNOK = table.Column<bool>(type: "bit", nullable: true),
                    RightStatus = table.Column<int>(type: "int", nullable: true),
                    DateTimeFinished = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FitAndFunctionProcessData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FitAndFunctionProcessData_PartAllProcessData_PartId",
                        column: x => x.PartId,
                        principalTable: "PartAllProcessData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ManualScrewingProcessData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HoleNumber = table.Column<int>(type: "int", nullable: true),
                    DateTimeStarted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Torque = table.Column<float>(type: "real", nullable: true),
                    Angle = table.Column<float>(type: "real", nullable: true),
                    OK = table.Column<bool>(type: "bit", nullable: true),
                    NOK = table.Column<bool>(type: "bit", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    DateTimeFinished = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManualScrewingProcessData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManualScrewingProcessData_PartAllProcessData_PartId",
                        column: x => x.PartId,
                        principalTable: "PartAllProcessData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NgAutoScrewingProcessData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NgAutoScrewingProcessData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NgAutoScrewingProcessData_PartAllProcessData_PartId",
                        column: x => x.PartId,
                        principalTable: "PartAllProcessData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PressingProcessData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HoleNumber = table.Column<int>(type: "int", nullable: true),
                    DateTimeStarted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Force = table.Column<float>(type: "real", nullable: true),
                    Position = table.Column<float>(type: "real", nullable: true),
                    OK = table.Column<bool>(type: "bit", nullable: true),
                    NOK = table.Column<bool>(type: "bit", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    DateTimeFinished = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PressingProcessData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PressingProcessData_PartAllProcessData_PartId",
                        column: x => x.PartId,
                        principalTable: "PartAllProcessData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PressingReworkProcessData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    In1 = table.Column<bool>(type: "bit", nullable: true),
                    In2 = table.Column<bool>(type: "bit", nullable: true),
                    In3 = table.Column<bool>(type: "bit", nullable: true),
                    Rework1 = table.Column<bool>(type: "bit", nullable: true),
                    Rework2 = table.Column<bool>(type: "bit", nullable: true),
                    Rework3 = table.Column<bool>(type: "bit", nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PressingReworkProcessData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PressingReworkProcessData_PartAllProcessData_PartId",
                        column: x => x.PartId,
                        principalTable: "PartAllProcessData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScanProcessData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SerialNumberProduct = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FFF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartIdent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlantCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeQuality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScanProcessData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScanProcessData_PartAllProcessData_PartId",
                        column: x => x.PartId,
                        principalTable: "PartAllProcessData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FitAndFunctionMeasurements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Min = table.Column<float>(type: "real", nullable: true),
                    Value = table.Column<float>(type: "real", nullable: true),
                    Max = table.Column<float>(type: "real", nullable: true),
                    OK = table.Column<bool>(type: "bit", nullable: true),
                    NOK = table.Column<bool>(type: "bit", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    FitAndFunctionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FitAndFunctionMeasurements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FitAndFunctionMeasurements_FitAndFunctionProcessData_FitAndFunctionId",
                        column: x => x.FitAndFunctionId,
                        principalTable: "FitAndFunctionProcessData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AutoScrewingProcessData_PartId",
                table: "AutoScrewingProcessData",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_ConductivityProcessData_PartId",
                table: "ConductivityProcessData",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_FitAndFunctionMeasurements_FitAndFunctionId",
                table: "FitAndFunctionMeasurements",
                column: "FitAndFunctionId");

            migrationBuilder.CreateIndex(
                name: "IX_FitAndFunctionProcessData_PartId",
                table: "FitAndFunctionProcessData",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_ManualScrewingProcessData_PartId",
                table: "ManualScrewingProcessData",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_NgAutoScrewingProcessData_PartId",
                table: "NgAutoScrewingProcessData",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_PressingProcessData_PartId",
                table: "PressingProcessData",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_PressingReworkProcessData_PartId",
                table: "PressingReworkProcessData",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_ScanProcessData_PartId",
                table: "ScanProcessData",
                column: "PartId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutoScrewingProcessData");

            migrationBuilder.DropTable(
                name: "ConductivityProcessData");

            migrationBuilder.DropTable(
                name: "FitAndFunctionMeasurements");

            migrationBuilder.DropTable(
                name: "ManualScrewingProcessData");

            migrationBuilder.DropTable(
                name: "NgAutoScrewingProcessData");

            migrationBuilder.DropTable(
                name: "PressingProcessData");

            migrationBuilder.DropTable(
                name: "PressingReworkProcessData");

            migrationBuilder.DropTable(
                name: "ScanProcessData");

            migrationBuilder.DropTable(
                name: "FitAndFunctionProcessData");

            migrationBuilder.DropTable(
                name: "PartAllProcessData");
        }
    }
}
