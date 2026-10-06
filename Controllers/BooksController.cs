using Microsoft.AspNetCore.Mvc;
using BookManager.Models;
using BookManager.Repositories;

namespace BookManager.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly ILogger<BooksController> _logger;

        public BooksController(IBookRepository bookRepository, ILogger<BooksController> logger)
        {
            _bookRepository = bookRepository;
            _logger = logger;
        }

        // GET: Books
        public IActionResult Index()
        {
            try
            {
                var books = _bookRepository.GetAll();
                return View(books);
            }
            catch (Exception exception)
            {
                return HandleException(exception, nameof(Index));
            }
        }

        // GET: Books/Details/5
        public IActionResult Details(int id)
        {
            try
            {
                var book = _bookRepository.GetById(id);
                if (book == null)
                {
                    return NotFound();
                }
                return View(book);
            }
            catch (Exception exception)
            {
                return HandleException(exception, nameof(Details));
            }
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception exception)
            {
                return HandleException(exception, nameof(Create));
            }
        }

        // POST: Books/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book book)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _bookRepository.Add(book);
                    return RedirectToAction(nameof(Index));
                }
                return View(book);
            }
            catch (Exception exception)
            {
                return HandleException(exception, nameof(Create));
            }
        }

        // GET: Books/Edit/5
        public IActionResult Edit(int id)
        {
            try
            {
                var book = _bookRepository.GetById(id);
                if (book == null)
                {
                    return NotFound();
                }
                return View(book);
            }
            catch (Exception exception)
            {
                return HandleException(exception, nameof(Edit));
            }
        }

        // POST: Books/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Book book)
        {
            try
            {
                if (id != book.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    _bookRepository.Update(book);
                    return RedirectToAction(nameof(Index));
                }
                return View(book);
            }
            catch (Exception exception)
            {
                return HandleException(exception, nameof(Edit));
            }
        }

        // GET: Books/Delete/5
        public IActionResult Delete(int id)
        {
            try
            {
                var book = _bookRepository.GetById(id);
                if (book == null)
                {
                    return NotFound();
                }
                return View(book);
            }
            catch (Exception exception)
            {
                return HandleException(exception, nameof(Delete));
            }
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                _bookRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception exception)
            {
                return HandleException(exception, nameof(DeleteConfirmed));
            }
        }

        public IActionResult Search(string query)
        {
            try
            {
                var books = _bookRepository.Search(query);
                return View("Index", books);
            }
            catch (Exception exception)
            {
                return HandleException(exception, nameof(Search));
            }
        }

        private IActionResult HandleException(Exception exception, string actionName)
        {
            _logger.LogError(exception, "An error occurred while executing {ActionName}.", actionName);
            Response.StatusCode = StatusCodes.Status500InternalServerError;
            return View("Error");
        }
    }
}