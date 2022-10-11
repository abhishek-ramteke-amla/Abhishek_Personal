using CustomerCRUD.Models;

namespace CustomerCRUD.Repository
{
    public interface IRepository
    {
        public List<CustomerModel> ListCustomer();
        public void CreateCustomer(CustomerModel customer);
        public void UpdateCustomer(CustomerModel customer);
        public CustomerModel CustomerDetails(int customerId);
        public void DeleteCustomer(int customerId);
        public void Save();
    }
}
