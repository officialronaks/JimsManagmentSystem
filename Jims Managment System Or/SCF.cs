using System.ComponentModel.DataAnnotations.Schema;

namespace Jims_Managment_System_Or
{
    public class SCF
    {
        public int Sid { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string CName { get; set; } = string.Empty;
        public string FName { get; set; } = string.Empty;
        public int Attendance { get; set; }
        public decimal totalpercentage { get; set; }

    }
}
