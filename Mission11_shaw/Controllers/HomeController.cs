using Microsoft.AspNetCore.Mvc;
using Mission11_shaw.Models;
using Mission11_shaw.Models.ViewModels;
using System.Diagnostics;

namespace Mission11_shaw.Controllers
{
    public class HomeController : Controller
    {

        private IBookRepository _bookRepo;
        public HomeController(IBookRepository temp)
        {
            _bookRepo = temp;
        }

        public IActionResult Index(int pageNum)
        {
            int pageSize = 10;
            //making each page have 10 books/components

            var blah = new BooksListViewModel
            {
                Books = _bookRepo.Books
                .OrderBy(x => x.Title)
                .Skip(pageSize * (pageNum - 1))
                .Take(pageSize),

                PaginationInfo = new PaginationInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = pageSize,
                    TotalItems = _bookRepo.Books.Count()

                }
            };





            return View(blah);
        }

       
    }
}
