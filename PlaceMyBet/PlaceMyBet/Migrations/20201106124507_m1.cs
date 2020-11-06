using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PlaceMyBet.Migrations
{
    public partial class m1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    EventoID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Equipo_Local = table.Column<string>(nullable: true),
                    Equipo_Visitante = table.Column<string>(nullable: true),
                    Fecha = table.Column<string>(nullable: true),
                    Goles = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.EventoID);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Email = table.Column<string>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    Edad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "Mercados",
                columns: table => new
                {
                    MercadoID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OverUnder = table.Column<double>(nullable: false),
                    CuotaOver = table.Column<double>(nullable: false),
                    CuotaUnder = table.Column<double>(nullable: false),
                    DineroOver = table.Column<double>(nullable: false),
                    DineroUnder = table.Column<double>(nullable: false),
                    EventoID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mercados", x => x.MercadoID);
                    table.ForeignKey(
                        name: "FK_Mercados_Eventos_EventoID",
                        column: x => x.EventoID,
                        principalTable: "Eventos",
                        principalColumn: "EventoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cuentas",
                columns: table => new
                {
                    CuentaID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre_Banco = table.Column<string>(nullable: true),
                    Tarjeta_Credito = table.Column<int>(nullable: false),
                    Saldo_Actual = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuentas", x => x.CuentaID);
                    table.ForeignKey(
                        name: "FK_Cuentas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Apuestas",
                columns: table => new
                {
                    ApuestaID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DineroApostado = table.Column<double>(nullable: false),
                    TipoApuesta = table.Column<string>(nullable: true),
                    Cuota = table.Column<double>(nullable: false),
                    Fecha = table.Column<string>(nullable: true),
                    MercadoID = table.Column<int>(nullable: false),
                    UsuarioEmail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apuestas", x => x.ApuestaID);
                    table.ForeignKey(
                        name: "FK_Apuestas_Mercados_MercadoID",
                        column: x => x.MercadoID,
                        principalTable: "Mercados",
                        principalColumn: "MercadoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Apuestas_Usuarios_UsuarioEmail",
                        column: x => x.UsuarioEmail,
                        principalTable: "Usuarios",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Eventos",
                columns: new[] { "EventoID", "Equipo_Local", "Equipo_Visitante", "Fecha", "Goles" },
                values: new object[] { 1, "Valencia", "Espanyol", "2020-09-16", 0 });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Email", "Apellido", "Edad", "Nombre" },
                values: new object[] { "tumismo@yomismo.cat", "mismo", 19, "Tumismo'" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Email", "Apellido", "Edad", "Nombre" },
                values: new object[] { "yomismomismo@yomismo.cat", "Mismo", 21, "Yomismo" });

            migrationBuilder.InsertData(
                table: "Cuentas",
                columns: new[] { "CuentaID", "Nombre_Banco", "Saldo_Actual", "Tarjeta_Credito", "UsuarioId" },
                values: new object[] { 4, "Bankmismo", 200, 452147943, "yomismomismo@yomismo.cat" });

            migrationBuilder.InsertData(
                table: "Mercados",
                columns: new[] { "MercadoID", "CuotaOver", "CuotaUnder", "DineroOver", "DineroUnder", "EventoID", "OverUnder" },
                values: new object[,]
                {
                    { 1, 1.74, 2.0899999999999999, 240.0, 200.0, 1, 1.5 },
                    { 2, 1.8999999999999999, 1.8999999999999999, 210.0, 100.0, 1, 2.5 },
                    { 3, 2.8500000000000001, 1.4299999999999999, 50.0, 100.0, 1, 3.5 }
                });

            migrationBuilder.InsertData(
                table: "Apuestas",
                columns: new[] { "ApuestaID", "Cuota", "DineroApostado", "Fecha", "MercadoID", "TipoApuesta", "UsuarioEmail" },
                values: new object[] { 1, 1.8999999999999999, 10.0, "2020-11-04 11:37:06", 1, "Over", "yomismomismo@yomismo.cat" });

            migrationBuilder.InsertData(
                table: "Apuestas",
                columns: new[] { "ApuestaID", "Cuota", "DineroApostado", "Fecha", "MercadoID", "TipoApuesta", "UsuarioEmail" },
                values: new object[] { 5, 1.78, 10.0, "2020-11-04 11:38:12", 1, "Over", "tumismo@yomismo.cat" });

            migrationBuilder.InsertData(
                table: "Apuestas",
                columns: new[] { "ApuestaID", "Cuota", "DineroApostado", "Fecha", "MercadoID", "TipoApuesta", "UsuarioEmail" },
                values: new object[] { 6, 1.8999999999999999, 10.0, "2020-11-04 12:10:35", 2, "Over", "tumismo@yomismo.cat" });

            migrationBuilder.CreateIndex(
                name: "IX_Apuestas_MercadoID",
                table: "Apuestas",
                column: "MercadoID");

            migrationBuilder.CreateIndex(
                name: "IX_Apuestas_UsuarioEmail",
                table: "Apuestas",
                column: "UsuarioEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Cuentas_UsuarioId",
                table: "Cuentas",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mercados_EventoID",
                table: "Mercados",
                column: "EventoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apuestas");

            migrationBuilder.DropTable(
                name: "Cuentas");

            migrationBuilder.DropTable(
                name: "Mercados");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Eventos");
        }
    }
}
