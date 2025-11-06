using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeauProject.Restaurant.Domain.Models.Accounts
{
    public class AccountGroupTranslation
    {
        public int Id { get; set; }
        public int AccountGroupId { get; set; }
        public string Language { get; set; } = "fa"; // مثال: fa یا en
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public AccountGroup AccountGroup { get; set; } = null!;
    }
}
