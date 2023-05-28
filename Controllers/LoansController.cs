using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineLibrary.Areas.Identity.Data;
using OnlineLibrary.Data;
using OnlineLibrary.Models.DBEntities;
using OnlineLibrary.Models.ModelViews;
using OnlineLibrary.Services;
using OnlineLibrary.Services.Interfaces;

namespace OnlineLibrary.Controllers
{
    public class LoansController : Controller
    {
        private readonly OnlineLibraryContext _context;
        private ILoanService _loanService;
        private IBookService _bookService;
        private IUserService _userService;
        private UserManager<OnlineLibraryUser> _userManeger;

        public LoansController(OnlineLibraryContext context, ILoanService loanService, IBookService bookService, UserManager<OnlineLibraryUser> userManager, IUserService userService)
        {
            _context = context;
            _loanService = loanService;
            _bookService = bookService;
            _userManeger = userManager;
            _userService = userService;
        }

        // GET: Loans
        public async Task<IActionResult> Index(string searchString = "", int pg = 1, int pageSize = 5)
        {
            var user = _userManeger.GetUserAsync(User).Result;
            var data = _loanService.GetAllLoans(user);
            if (!String.IsNullOrEmpty(searchString))
            {
                data = _loanService.GetBySearchCondition(searchString);
            }            
            var pager = new Models.DBEntities.Pager(data.Count, pg, pageSize);

            this.ViewBag.Pager = pager;

            data = data.Skip((pg - 1) * pageSize).Take(pageSize).ToList();

            //if (!String.IsNullOrEmpty(searchString))
            //{
            //    data = _loanService.GetBySearchCondition(searchString);
            //}

            return _loanService.GetAllLoans(user) != null ?
                          View(data) :
                          Problem("Entity set 'OnlineLibraryContext.Loans'  is null.");
        }


        // GET: Loans/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Loans == null)
            {
                return NotFound();
            }

            var loan = await _context.Loans
                .FirstOrDefaultAsync(m => m.LoanId == id);
            if (loan == null)
            {
                return NotFound();
            }

            return View(loan);
        }


        // GET: Loans/Create
        public async Task<ActionResult> Create()
        {
            List<SelectListItem> usersSelectListItems = new List<SelectListItem>();
            foreach (OnlineLibraryUser user in _userManeger.Users.ToList())
            {
                Task<bool> role = _userManeger.IsInRoleAsync(user, "Admin");
                if (await role){
                    continue;
                }
                SelectListItem selectList = new SelectListItem()
                {
                    Text = user.FirstName + " " + user.LastName,   
                    Value = user.Id,
                    Selected = false
                };
                usersSelectListItems.Add(selectList);
            }
            List<SelectListItem> booksSelectListItems = new List<SelectListItem>();
            foreach (Book book in _bookService.GetAll())
            {
                SelectListItem selectList = new SelectListItem()
                {
                    Text = book.Title,
                    Value = book.BookId.ToString(),
                    Selected = false
                };
                booksSelectListItems.Add(selectList);
            }            
            LoansViewModel viewModel = new LoansViewModel()
            {
                Users = usersSelectListItems,
                Books = booksSelectListItems,                
            };

            return View(viewModel);
        }

        // POST: Loans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save( LoansViewModel loanViewModel)
        {
                await _loanService.AddNewLoan(new Loan {
                      LoanDate = loanViewModel.LoanDate
                    , ReturnDate = loanViewModel.ReturnDate
                    , Books = new List<Book>()
                    , Users = new List<OnlineLibraryUser>() 
                }
                , (List<string>)loanViewModel.SelectedUsers
                , (List<Guid>)loanViewModel.SelectedBooks);
                return RedirectToAction(nameof(Index));
            
        }

        // GET: Loans/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Loans == null)
            {
                return NotFound();
            }

            var loan = await _context.Loans.FindAsync(id);
            if (loan == null)
            {
                return NotFound();
            }
            return View(loan);
        }

        // POST: Loans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("LoanId,LoanDate,ReturnDate")] Loan loan)
        {
            if (id != loan.LoanId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoanExists(loan.LoanId))
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
            return View(loan);
        }

        // GET: Loans/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Loans == null)
            {
                return NotFound();
            }

            var loan = await _context.Loans
                .FirstOrDefaultAsync(m => m.LoanId == id);
            if (loan == null)
            {
                return NotFound();
            }

            return View(loan);
        }

        // POST: Loans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Loans == null)
            {
                return Problem("Entity set 'OnlineLibraryContext.Loans'  is null.");
            }
            var loan = await _context.Loans.FindAsync(id);
            if (loan != null)
            {
                _context.Loans.Remove(loan);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoanExists(Guid id)
        {
          return (_context.Loans?.Any(e => e.LoanId == id)).GetValueOrDefault();
        }
    }
}
