using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

namespace Jims_Managment_System_Or
{
    [PrimaryKey(nameof(Sid))]
    public class Students
    {
        public int Sid { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        [ForeignKey("Cid")]
        public int Cid { get; set; }
        public virtual Course? Course { get; set; }
        public int Attendance { get; set; }
        public decimal totalpercentage { get; set; }

    }
}
