using EvilLight.Model.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using SQLite.Net;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Platform.WinRT;

namespace EvilLight.Util
{
    public class DbUtil
    {
        private static string DbFileName = "info.db";
        private static string path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, DbFileName);
        public static SQLiteConnection conn = GetConnection();
        const string deleteTable = "drop table City;";

        public static SQLiteConnection GetConnection()
        {
            if (conn == null)
            {
                conn = new SQLiteConnection(new SQLitePlatformWinRT(), path);
            }
            return conn;
        }

        public static async void Init()
        {
            ConfigUtil cu = new ConfigUtil();
            var item = cu.Get();
            var obj = DateTime.Now - item.LastUpdateTime;
            if ((!TableExist("City")) || obj > new TimeSpan(7, 0, 0, 0, 0))
            {
                var ci = await CityUtil.GetCityLocal();
                WriteCityInfo(ci);
            }
        }

        public void test()
        {

        }

        public static bool WriteCityInfo(CityInfo ci)
        {
            if (TableExist("City"))
            {
                SQLiteCommand cmd = conn.CreateCommand(deleteTable);
                cmd.ExecuteNonQuery();
            }
            conn.CreateTable<City>();
            conn.InsertAll(ci.city_info);
            return true;
        }

        public int GetCitiesCount()
        {
            return conn.Table<City>().Count();
        }

        public static bool TableExist(string tableName)
        {
            SQLiteCommand cmd = conn.CreateCommand(@"SELECT COUNT(*) FROM sqlite_master where type='table' and name=?", new object[] { tableName });
            return cmd.ExecuteScalar<int>() == 1;
        }


    }
}
