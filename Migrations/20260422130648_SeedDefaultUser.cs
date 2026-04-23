using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagement.Migrations
{
    /// <inheritdoc />
    public partial class SeedDefaultUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO public.users(first_name, last_name, email, address, state, city, password, phone_number,
                                role_id, salt,  created_date, is_active, created_by)
                                VALUES ('Veera', 'Gangulakurthi', 'vgangulakurthi@quiktrak.com', '', 'Telangana', 'Hyderabad','lYd4sG4HVrWUWnp4/kAwxLZ25ofCR6G78WX7H+Z8OZs=', '', 1, kq8CeCQoIPnL2gUOZIpO1g==, NOW(), true, 1);");

        }
        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DELETE FROM public.users
	            WHERE email = 'vgangulakurthi@quiktrak.com';");

        }
    }
}
