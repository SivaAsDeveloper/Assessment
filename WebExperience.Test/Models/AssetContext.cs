using SharedDTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebExperience.Test.Models
{
    public class AssetContext : DbContext
    {
        public DbSet<Asset> Assets { get; set; }
    }

}