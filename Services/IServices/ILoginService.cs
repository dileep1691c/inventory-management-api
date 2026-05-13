using InventoryManagement.ModelDTO;

namespace InventoryManagement.Services.IServices
{
    public interface ILoginService
    {
        Task<AuthResponse> LoginUser(LoginRequest loginRequest);

        Task UpdatePassword(string password);

        Task ForgetPassword(string password);
    }
}
