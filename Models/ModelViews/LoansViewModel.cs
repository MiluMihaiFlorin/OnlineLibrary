using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineLibrary.Areas.Identity.Data;
using OnlineLibrary.Models.DBEntities;
using System.Collections;

namespace OnlineLibrary.Models.ModelViews
{
    public class LoansViewModel
    {
        public Guid LoanId { get; set; }

        public DateTime LoanDate { get; set; }

        public DateTime ReturnDate { get; set; }

        public IEnumerable<SelectListItem> Books { get; set; }

        public IEnumerable<Guid> SelectedBooks { get; set; }

        public IEnumerable<SelectListItem> Users { get; set; }

        public IEnumerable<string> SelectedUsers { get; set; }

    }
}
