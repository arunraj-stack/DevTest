using DeveloperTest.Models;
using System.Threading.Tasks;

namespace DeveloperTest.Business.Interfaces
{
    public interface ICustomerService
    {
        CustomerModel[] GetCustomers();

        CustomerModel GetCustomer(int customerId);

        Task<CustomerModel> CreateCustomer(BaseCustomerModel model);
    }
}
