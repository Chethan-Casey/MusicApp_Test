using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MusicApp.Controllers
{
    public class Music
    {

        public string id { get; set; }
        public string SongName { get; set; }
        public bool isDefault { get; set; }

        /// <summary>
        /// Function to retrieve songs from db
        /// </summary>
        public static DataTable GetAll()
        {
            // Select * from songs;
            return sql.GetDataTable("select * from songs");
        }

        /// <summary>
        /// Function to delete song from db
        /// </summary>
        /// <param name="id"></param>
        public static void DeleteById(string id)
        {
            // delete from songs where id = 'id';
            sql.Execute(string.Format("delete from songs where id = '{0}'", id));
        }


        /// <summary>
        /// Adds songs to db
        /// </summary>
        /// <param name="id"></param>
        public static void AddBySongName(string name)
        {
            // insert into songs ( name, isDefault ) values ( name , 0 )
            sql.Execute(string.Format("insert into songs ( SongName, isDefault ) values ( '{0}' , 0 )", name));
        }
    }
}