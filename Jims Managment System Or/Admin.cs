using System.Security.Cryptography;

namespace Jims_Managment_System_Or
{
    [PrimaryKey(nameof(AdminId))]
    public class Admin
    {
        public int AdminId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;  
        public string Email { get; set; } = string.Empty;
    }
}
