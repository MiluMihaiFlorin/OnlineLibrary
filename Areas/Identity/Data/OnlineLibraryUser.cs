using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Azure.Core;
using System.Xml.Linq;
using Microsoft.AspNetCore.Identity;
using OnlineLibrary.Models.DBEntities;

namespace OnlineLibrary.Areas.Identity.Data;

// Add profile data for application users by adding properties to the OnlineLibraryUser class
public class OnlineLibraryUser : IdentityUser
{

    public ICollection<Loan>? Loans { get; set; }

    public OnlineLibraryUser()
    {
        Loans = new List<Loan>();
    }

}

