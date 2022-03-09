using Microsoft.EntityFrameworkCore.Migrations;

namespace GruppNrSexMail.Migrations
{
    public partial class tablesenmaillist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ToEmail",
                table: "SendMails",
                newName: "Recipients");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Recipients",
                table: "SendMails",
                newName: "ToEmail");
        }
    }
}
