using Incedo_Octavius_Demo_2.Data;
using Incedo_Octavius_Demo_2.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;

namespace Incedo_Octavius_Demo_2.Controllers
{
    public class HematologyController : Controller
    {
        // GET: Oncology
        private Incedo_Octavius_Demo_2_kol_degree_map_table_Context db = new Incedo_Octavius_Demo_2_kol_degree_map_table_Context();
        // GET: KOL_Image
        public ActionResult Index(int? page, string option,string search)
        {
            List<KOL_Image> kolNameImageList = new List<KOL_Image>();
            string constr = ConfigurationManager.ConnectionStrings["Incedo_Octavius_Demo_2_kol_table_Context"].ConnectionString;
            // Stored Procedures
            using (MySqlConnection dbConnection = new MySqlConnection(constr))
            {
                try
                {
                    dbConnection.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = dbConnection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "TA_Image";
                    
                   
                    cmd.Parameters.AddWithValue("TA_ID", 2);

                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    DataSet dataSetObject = new DataSet();
                    dataAdapter.Fill(dataSetObject);

                    if (dataSetObject.Tables[0].Rows.Count > 0)
                    {
                        for (int iCout = 0; iCout < dataSetObject.Tables[0].Rows.Count; iCout++)
                        {
                            KOL_Image kolImage = new KOL_Image();
                            kolImage.kolID = Convert.ToInt32(dataSetObject.Tables[0].Rows[iCout]["kolID"]);
                            kolImage.First_Name = dataSetObject.Tables[0].Rows[iCout]["First_Name"].ToString();
                            kolImage.Last_Name = dataSetObject.Tables[0].Rows[iCout]["Last_Name"].ToString();
                            kolImage.Image_URL = dataSetObject.Tables[0].Rows[iCout]["Image_Link"].ToString();

                            kolNameImageList.Add(kolImage);
                        }
                    }
                    if (option == "FirstName")
                    {
                        return View(kolNameImageList.Where(s => s.First_Name.ToLower() == search || s.First_Name.ToUpper() == search || search == null).ToList().ToPagedList(page ?? 1, 8));
                    }
                    else
                    {
                        return View(kolNameImageList.Where(s => s.Last_Name.ToLower() == search || s.Last_Name.ToUpper() == search || search == null).ToList().ToPagedList(page ?? 1, 8));
                    }
                }
                catch (Exception Ex)
                {

                    Console.WriteLine("Error : " + Ex.Message);
                }

            }

            return View(kolNameImageList.ToList().ToPagedList(page ?? 1, 8));
        }
    }
}