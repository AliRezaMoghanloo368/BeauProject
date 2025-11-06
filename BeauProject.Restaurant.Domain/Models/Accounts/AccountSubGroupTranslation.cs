using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeauProject.Restaurant.Domain.Models.Accounts
{
    public class AccountSubGroupTranslation
    {
        public int Id { get; set; }
        public int AccountSubGroupId { get; set; }
        public string Language { get; set; } = "fa";
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public AccountSubGroup AccountSubGroup { get; set; } = null!;
    }
}
