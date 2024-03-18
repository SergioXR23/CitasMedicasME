using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CitasMedicasME.Migrations
{
    /// <inheritdoc />
    public partial class updateDiagnostico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CitaId",
                table: "Diagnosticos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CitaId",
                table: "Diagnosticos");
        }
    }
}
