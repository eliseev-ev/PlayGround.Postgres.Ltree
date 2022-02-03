using Microsoft.EntityFrameworkCore;
using NpgsqlTypes;
using System.ComponentModel.DataAnnotations;

namespace PlayGround.Core6_0.PostgreTree
{
    public class File
    {
        public LTree Path { get; set; }

        [Key]
        public Guid Guid { get; set; }

        public string Name { get; set; }
    }
}
