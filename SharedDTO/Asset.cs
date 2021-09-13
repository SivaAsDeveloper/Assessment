using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDTO
{
    public class Asset

    {
        public Guid AssetId { get; set; }

        public string FileName { get; set; }

        public string MIMEType { get; set; }

        public string CreatedBy { get; set; }

        public string Email { get; set; }

        public string Country { get; set; }

        public string Description { get; set; }

    }
}
