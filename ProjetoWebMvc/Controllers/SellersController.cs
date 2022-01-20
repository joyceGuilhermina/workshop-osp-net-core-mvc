using Microsoft.AspNetCore.Mvc;
using ProjetoWebMvc.Models;
using ProjetoWebMvc.Models.ViewModels;
using ProjetoWebMvc.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoWebMvc.Services.Exceptions;
using ProjetoWebMvc.Models.viewModels;
using System.Diagnostics;

namespace ProjetoWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _SellerService;
        private readonly DepartmentService _departmentService;

        public SellersController(SellerService sellerService, DepartmentService departmentService)
        {
            _SellerService = sellerService;
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {
            var list = _SellerService.FindAll();

            return View(list);
        }

        public IActionResult Create()
        {
            var departments = _departmentService.FindAll();
            var viewModel = new SellerFormViewMode { Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            if(!ModelState.IsValid)
            {
                var departments = _departmentService.FindAll();
                var ViewModel = new SellerFormViewMode { Seller = seller, Departments = departments };
                return View(ViewModel);
            }
            _SellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "id not provided" });
            }

            var obj = _SellerService.FindById(id.Value);
            if(obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "id not found" });
            }

            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _SellerService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int ? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "id not provided" });
            }

            var obj = _SellerService.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "id not found" });
            }

            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "id not provided" });
            }

            var obj = _SellerService.FindById(id.Value);
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "id not found" });
            }

            List<Department> departments = _departmentService.FindAll();
            SellerFormViewMode viewMode = new SellerFormViewMode { Seller = obj, Departments = departments };
            return View(viewMode);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Seller seller)
        {
            if (!ModelState.IsValid)
            {
                var departments = _departmentService.FindAll();
                var ViewModel = new SellerFormViewMode { Seller = seller, Departments = departments };
                return View(ViewModel);
            }
            if (id != seller.id)
            {
                return RedirectToAction(nameof(Error), new { message = "id mismatch" });
            }
            try
            {
                _SellerService.Update(seller);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
           
        }

        public IActionResult Error(string message)
        {
            var ViewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(ViewModel);
        }
    }
}
