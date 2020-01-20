using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnionArchitecture.Application.Interface;
using OnionArchitecture.Application.ViewModel;
using OnionArchitecture.Domain.Entities;

namespace OnionArchitecture.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerAppService _customerAppService;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerAppService customerAppService, IMapper mapper)
        {
            _customerAppService = customerAppService;
            _mapper = mapper;
        }

        // GET: Customer
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerVM>>(_customerAppService.GetAll()));
        }

        // GET: Customer/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = _customerAppService.GetById(id.Value);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,CreateDate,isActive")] CustomerVM customer)
        {
            if (ModelState.IsValid)
            {
                customer.Id = Guid.NewGuid();
                var newCustomer = _mapper.Map<CustomerVM, Customer>(customer);
                _customerAppService.Add(newCustomer);

                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customer/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = _customerAppService.GetById(id.Value);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Email,CreateDate,isActive")] CustomerVM customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var updateCustomer = _mapper.Map<CustomerVM, Customer>(customer);
                    _customerAppService.Update(updateCustomer);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customer/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = _customerAppService.GetById(id.Value);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var customer = _customerAppService.GetById(id);

            _customerAppService.Delete(customer);
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(Guid id)
        {
            return _customerAppService.GetById(id) != null;
        }
    }
}
