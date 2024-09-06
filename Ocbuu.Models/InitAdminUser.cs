using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ocbuu.Models
{
    public class InitAdminUser
    {
        public string? AdminEmail { get; set; }
        public string? AdminPassword { get; set; }
        public string? AdminRole { get; set; }
    }
}