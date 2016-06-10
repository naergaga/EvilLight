using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvilLight.Model.Domain
{
    public class UserConfig
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string UserCityId { get; set; }

        public DateTime LastUpdateTime { get; set; }
    }
}
