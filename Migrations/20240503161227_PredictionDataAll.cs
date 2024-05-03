using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PREDICTING_STOCK_MARKET_API.Migrations
{
    /// <inheritdoc />
    public partial class PredictionDataAll : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prediction6Month",
                columns: table => new
                {
                    StockId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StockName = table.Column<string>(type: "varchar(512)", nullable: false),
                    RF = table.Column<string>(type: "varchar(512)", nullable: false),
                    LSTM = table.Column<string>(type: "varchar(512)", nullable: false),
                    Prophet = table.Column<string>(type: "varchar(512)", nullable: false),
                    StockResultSentiment = table.Column<string>(type: "varchar(512)", nullable: false),
                    SelectPrice = table.Column<string>(type: "varchar(512)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Sentimen__2C83A9C26FF65555", x => x.StockId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prediction6Month");
        }
    }
}
