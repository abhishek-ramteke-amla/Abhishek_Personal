using CustomerCRUD.Models;
using CustomerCRUD.Repository;

using Microsoft.AspNetCore.Mvc;

namespace CustomerCRUD.Controllers
{
    public class CustomerController : Controller
    {
        private IRepository _customerRespository;
        private List<CustomerModel>_customerList;

        public CustomerController(IRepository customerRespository)
        {
            _customerRespository = customerRespository;
            _customerList = new List<CustomerModel>();
        }

        public IActionResult Index()
        {
            var customerList = _customerRespository.ListCustomer();
            return View(customerList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CustomerModel customer)
        {
          if(customer == null)
          {
                return View("Error");
          }
            if (ModelState.IsValid)
            {
                _customerRespository.CreateCustomer(customer);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var customerDetail = _customerRespository.ListCustomer().FirstOrDefault(x => x.Id == Id);
            return View(customerDetail);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteResult(int Id)
        {
            _customerRespository.DeleteCustomer(Id);
            return RedirectToAction("Index");

        }


        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var customer = _customerRespository.ListCustomer().FirstOrDefault(x => x.Id == Id);
            
            return View(customer);
        }

        [HttpPost, ActionName("Edit")]
        public IActionResult UpdateCustomer(CustomerModel customerModel)
        {
            _customerRespository.UpdateCustomer(customerModel);
            return RedirectToAction("Index");
        }
    }
}
