using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagement.Migrations
{
    /// <inheritdoc />
    public partial class SeedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO public.roles(
                role_name, role_code,created_date, is_active, created_by)
                VALUES ('SuperAdmin', 'Z', NOW(), true, 1);");
            migrationBuilder.Sql(@"INSERT INTO public.roles(
                role_name, role_code,created_date, is_active, created_by)
                VALUES ('Admin', 'A', NOW(), true, 1);");
            migrationBuilder.Sql(@"INSERT INTO public.roles(
                role_name, role_code, created_date, is_active, created_by)
                VALUES ('Manager', 'M', NOW(), true, 1);");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DELETE FROM public.roles WHERE role_code = 'Z'");
            migrationBuilder.Sql(@"DELETE FROM public.roles WHERE role_code = 'A'");
            migrationBuilder.Sql(@"DELETE FROM public.roles WHERE role_code = 'M'");
        }
    }
}
