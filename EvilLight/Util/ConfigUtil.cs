using EvilLight.Model.Domain;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvilLight.Util
{
    public class ConfigUtil
    {

        public SQLiteConnection conn = DbUtil.GetConnection();
        public ConfigUtil()
        {
            if (!DbUtil.TableExist("ConfigUtil"))
            {
                conn.CreateTable<UserConfig>();
            }
            var table = conn.Table<UserConfig>();
            var config = table.SingleOrDefault();
            if (config == null)
            {
                conn.Insert(new UserConfig
                {
                    LastUpdateTime = new DateTime(2016, 1, 1),
                    UserCityId = (conn.Table<City>().Where(c => c.CityName == "北京")).First().CityId
                });
            }
        }

        public UserConfig Get()
        {
            var table = conn.Table<UserConfig>();
            return table.SingleOrDefault();
        }

        public void Update(UserConfig userConfig)
        {
            var table = conn.Table<UserConfig>();
            userConfig.Id = 1;
            conn.Update(userConfig);
        }
    }
}
