using MarketApplication.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketApplication.Entities.Categories
{
    public class Note : Auditable
    {
        [MaxLength(50)]
        public string Title { get; set; } = string.Empty;

        public string Notee { get; set; } = string.Empty;

        public long UserId { get; set; }
    }
}
