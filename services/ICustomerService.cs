using afe_final_api.Data;

namespace afe_final_api.services;

public interface ICustomerService
{
    Task<List<Customer>> GetAllCustomers();
}