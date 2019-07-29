using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCBookAssignment.Models
{
    public class Book
    {
        
        public int Id { get; set; }

        
        public string BookName { get; set; }
    }
}