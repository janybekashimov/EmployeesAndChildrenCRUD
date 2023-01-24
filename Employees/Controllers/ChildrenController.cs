using Employees.Features.Child.Commands;
using Employees.Features.Child.Queries;
using Employees.Features.EmployeeDropDown.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Employees.Controllers
{
    public class ChildrenController : Controller
    {
        private readonly IMediator _mediator;

        public ChildrenController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _mediator.Send(new GetAllChildrenQuery()));
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await _mediator.Send(new GetChildrenByIdQuery() { Id = id }));
        }

        public IActionResult Create()
        {
            ViewData["EmployeeList"] = _mediator.Send(new GetEmployeeDropDownQuery()).Result;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateChildrenCommand command)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _mediator.Send(command);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Unable to save changes.");
            }
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View(await _mediator.Send(new GetChildrenByIdQuery() { Id = id }));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateChildrenCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            try
            {
                if (ModelState.IsValid)
                {
                    await _mediator.Send(command);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Unable to save changes.");
            }
            return View(command);
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _mediator.Send(new DeleteChildrenCommand() { Id = id });
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Unable to delete. ");
            }
            return RedirectToAction(nameof(Index));
        }
    }
}