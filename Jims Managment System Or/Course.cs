using System.Security.Cryptography;

namespace Jims_Managment_System_Or
{
    [PrimaryKey(nameof(Cid))]
    public class Course
    {
        public int Cid { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Cfees { get; set; }
        public int totalstudents { get; set; }
        public int duration { get; set; }
    }
}
