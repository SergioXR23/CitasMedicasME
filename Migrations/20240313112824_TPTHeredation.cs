using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CitasMedicasME.Migrations
{
    public partial class TPTHeredation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Si la tabla 'Pacientes' ya existe, se elimina
            migrationBuilder.DropTable(
                name: "Paciente");

            // Luego, recreamos la tabla 'Pacientes' que hereda de 'Usuarios'
            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false), // Usamos el mismo Id del usuario como PK y FK
                    NSS = table.Column<string>(maxLength: 20, nullable: false),
                    NumTarjeta = table.Column<string>(maxLength: 20, nullable: false),
                    Telefono = table.Column<string>(maxLength: 15, nullable: false),
                    Direccion = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    // Establecemos la clave primaria
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                    // Establecemos la relación de herencia con la tabla 'Usuarios'
                    table.ForeignKey(
                        name: "FK_Pacientes_Usuario_Id",
                        column: x => x.Id,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Para revertir la migración, primero eliminamos la tabla 'Pacientes'
            migrationBuilder.DropTable(
                name: "Paciente");

            // Si es necesario, aquí recrearías la tabla 'Paciente' original
            // con su estructura y datos iniciales, si tenías una definición previa.
        }
    }
}
