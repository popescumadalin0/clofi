using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class RefreshToken
    {
        public string Token { get; set; } = string.Empty;
        public DateTime CreateTime { get; set; } = DateTime.Now;
        public DateTime Expires { get; set; }
    }
}
