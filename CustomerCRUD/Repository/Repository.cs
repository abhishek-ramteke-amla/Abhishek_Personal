using CustomerCRUD.Data;
using CustomerCRUD.Models;

using System.Linq;

namespace CustomerCRUD.Repository
{
    public class Repository : IRepository
    {
        private readonly CustomerContext _context;

        private List<CustomerModel> customerList;
        public Repository(CustomerContext context)
        {
            _context = context;
            customerList = new List<CustomerModel>();
        }

        public void CreateCustomer(CustomerModel customer)
        {
            var customerTable = new CustomerTable()
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Address = customer.Address,
            };

            _context.Add(customerTable);
            Save();
        }

        public CustomerModel CustomerDetails(int customerId)
        {
            var customerDetails = _context.CustomerTables.FirstOrDefault(c => c.Id == customerId);
            if(customerDetails != null)
            {
                return new CustomerModel(){
                    FirstName = customerDetails.FirstName,
                    LastName=customerDetails.LastName,
                    Address=customerDetails.Address
                };
            }
            return new CustomerModel();
        }

        public void DeleteCustomer(int customerId)
        {
            var customer = _context.CustomerTables.FirstOrDefault(x => x.Id == customerId);
            _context.CustomerTables.Remove(customer);
            Save();
        }

        public List<CustomerModel> ListCustomer()
        {
            var dbCustomerList = _context.CustomerTables.ToList();

            foreach(var dbCustomer in dbCustomerList)
            {
                customerList.Add(new CustomerModel
                {
                    Id = dbCustomer.Id,
                    FirstName = dbCustomer.FirstName,
                    LastName = dbCustomer.LastName,
                    Address = dbCustomer.Address
                });
                
            }
            return customerList;

        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateCustomer(CustomerModel customer)
        {
            var customerDetail = _context.CustomerTables.FirstOrDefault(x => x.Id == customer.Id);
            customerDetail.FirstName = customer.FirstName;
            customerDetail.LastName = customer.LastName;
            customer.Address = customer.Address;

            _context.CustomerTables.Update(customerDetail);
            Save();
        }
    }
}
