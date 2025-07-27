using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mvc_Day__4.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DeptId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeptName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DeptId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DeptId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DeptId", "DeptName" },
                values: new object[,]
                {
                    { 1, "SD" },
                    { 2, "UI" },
                    { 3, "Mob" },
                    { 4, "Network" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "Age", "DepartmentId", "Email", "Name", "Password", "Salary" },
                values: new object[,]
                {
                    { 1, "Cairo", 25, 1, "ahmed.ali@example.com", "Ahmed Ali", "pass1234", 5000.00m },
                    { 2, "Giza", 30, 2, "mona.said@example.com", "Mona Said", "mona456", 7000.00m },
                    { 3, "Alexandria", 28, 3, "youssef.g@example.com", "Youssef Gamal", "you12345", 6200.00m },
                    { 4, "Mansoura", 22, 1, "sara.fathy@example.com", "Sara Fathy", "sara987", 4500.00m },
                    { 5, "Tanta", 35, 2, "khaled.n@example.com", "Khaled Nour", "khaledpw", 9500.00m },
                    { 6, "Zagazig", 27, 3, "nour.hassan@example.com", "Nour Hassan", "nourpass", 7100.00m },
                    { 7, "Ismailia", 29, 1, "omar.adel@example.com", "Omar Adel", "omar123", 8000.00m },
                    { 8, "Aswan", 32, 2, "laila.samir@example.com", "Laila Samir", "laila321", 8800.00m },
                    { 9, "Fayoum", 26, 3, "hassan.omar@example.com", "Hassan Omar", "hassanpw", 5700.00m },
                    { 10, "Luxor", 24, 4, "dina.nabil@example.com", "Dina Nabil", "dina444", 5200.00m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_DepartmentId",
                table: "Students",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
