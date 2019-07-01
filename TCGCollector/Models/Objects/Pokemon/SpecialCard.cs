using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TCGCollector.Models
{
    public class SpecialCard : Card
    {
        [StringLength(1024)]
        public string SpecialCardText;
    }
}
