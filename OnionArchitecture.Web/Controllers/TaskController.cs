using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Model = OnionArchitecture.Domain.Entities;
using OnionArchitecture.Application.Interface;
using AutoMapper;
using OnionArchitecture.Application.ViewModel;
using OnionArchitecture.Domain.Entities;

namespace OnionArchitecture.Web.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskAppService _taskAppService;
        private readonly IMapper _mapper;

        public TaskController(ITaskAppService taskAppService, IMapper mapper)
        {
            _taskAppService = taskAppService;
            _mapper = mapper;
        }

        // GET: Task
        public async Task<IActionResult> Index()
        {
            //TODO: refactor methods to async all way down
            var taskVM = _mapper.Map<IEnumerable<Model.Task>, IEnumerable<TaskVM>>(_taskAppService.GetAll());
            return View(taskVM);
        }

        // GET: Task/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = _taskAppService.GetById(id.Value);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        // GET: Task/Create
        public IActionResult Create()
        {
            var customers = _mapper.Map<IEnumerable<Model.Task>, IEnumerable<TaskVM>>(_taskAppService.GetAll());
            ViewData["CustomerId"] = new SelectList(customers, "Id", "Name");
            return View();
        }

        // POST: Task/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,CreateDate,UpdateDate,DeletedDate,isActive,CustomerId")] TaskVM task)
        {
            if (ModelState.IsValid)
            {
                task.Id = Guid.NewGuid();
                var newTask = _mapper.Map<TaskVM, Model.Task>(task);
                _taskAppService.Add(newTask);

                return RedirectToAction(nameof(Index));
            }
            //ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Name", task.CustomerId);
            return View(task);
        }

        // GET: Task/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = _mapper.Map<Model.Task, TaskVM>(_taskAppService.GetById(id.Value));

            if (task == null)
            {
                return NotFound();
            }

            var customers = _mapper.Map<IEnumerable<Model.Task>, IEnumerable<TaskVM>>(_taskAppService.GetAll());
            ViewData["CustomerId"] = new SelectList(customers, "Id", "Name", task.CustomerId);
            return View(task);
        }

        // POST: Task/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Title,Description,CreateDate,UpdateDate,DeletedDate,isActive,CustomerId")] TaskVM task)
        {
            if (id != task.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var _task = _mapper.Map<TaskVM, Model.Task>(task);
                    _taskAppService.Update(_task);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskExists(task.Id))
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
            var customers = _mapper.Map<IEnumerable<Model.Task>, IEnumerable<TaskVM>>(_taskAppService.GetAll());
            ViewData["CustomerId"] = new SelectList(customers, "Id", "Name", task.CustomerId);
            return View(task);
        }

        // GET: Task/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = _mapper.Map<Model.Task, TaskVM>(_taskAppService.GetById(id.Value));
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        // POST: Task/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var task = _taskAppService.GetById(id);
            _taskAppService.Delete(task);

            return RedirectToAction(nameof(Index));
        }

        private bool TaskExists(Guid id)
        {
            return _taskAppService.GetById(id) != null;
        }
    }
}
