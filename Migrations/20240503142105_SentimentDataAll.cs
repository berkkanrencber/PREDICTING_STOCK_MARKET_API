using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PREDICTING_STOCK_MARKET_API.Migrations
{
    /// <inheritdoc />
    public partial class SentimentDataAll : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sentiment6Month",
                columns: table => new
                {
                    StockId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StockName = table.Column<string>(type: "varchar(512)", nullable: false),
                    StockGeneralSentiment = table.Column<string>(type: "varchar(512)", nullable: false),
                    StockRetweetSentiment = table.Column<string>(type: "varchar(512)", nullable: false),
                    StockReplySentiment = table.Column<string>(type: "varchar(512)", nullable: false),
                    StockLikeSentiment = table.Column<string>(type: "varchar(512)", nullable: false),
                    StockResultSentiment = table.Column<string>(type: "varchar(512)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Sentimen__2C83A9C26FF6E432", x => x.StockId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sentiment6Month");
        }
    }
}
