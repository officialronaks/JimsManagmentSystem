using System.ComponentModel.DataAnnotations.Schema;

namespace Jims_Managment_System_Or
{
    [PrimaryKey(nameof(Fid))]
    public class Faculty
    {
        public int Fid { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        [ForeignKey("Cid")]
        public int Cid { get; set; }
        public virtual Course? Course { get; set; }
    }
}
