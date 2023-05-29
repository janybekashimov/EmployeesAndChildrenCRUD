using Application.Mediatr.Child.Commands;
using Application.Mediatr.Child.Queries;
using Application.Mediatr.EmployeeDropDown.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var employeeList = _mediator.Send(new GetEmployeeDropDownQuery()).Result;
            ViewData["EmployeeList"] = employeeList.Select(e => new SelectListItem
            {
                Text = e.Name,
                Value = e.Id.ToString()
            });
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
            var employeeList = _mediator.Send(new GetEmployeeDropDownQuery()).Result;
            ViewData["EmployeeList"] = employeeList.Select(e => new SelectListItem
            {
                Text = e.Name,
                Value = e.Id.ToString()
            });
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var children = await _mediator.Send(new GetChildrenByIdQuery() { Id = id});
            var employeeList = await _mediator.Send(new GetEmployeeDropDownQuery());

            ViewData["EmployeeList"] = employeeList.Select(e => new SelectListItem
            {
                Text = e.Name,
                Value = e.Id.ToString()
            });

            var command = new UpdateChildrenCommand
            {
                Id = children.Id,
                LastName = children.LastName,
                Name = children.Name,
                MiddleName = children.MiddleName,
                BirthDate = children.BirthDate,
                EmployeeId = children.EmployeeId,
                Employee = children.Employee
            };
            return View(command);
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

            var employeeList = await _mediator.Send(new GetEmployeeDropDownQuery());
            ViewData["EmployeeList"] = employeeList.Select(e => new SelectListItem
            {
                Text = e.Name,
                Value = e.Id.ToString()
            });
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