using MarketApplication.Helpers;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketApplication.Entities
{
    public abstract class Auditable : BaseEntity
    {
        public DateTime CreateAt { get; set; } = TimeHelper.GetCurrentTime();

        public DateTime UpdateAt { get; set; } = TimeHelper.GetCurrentTime();
    }
}
