using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IdentityService.Domain.Models;
using System.Data;
using System.Data.SqlClient;

namespace IdentityService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Users2Controller : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public Users2Controller(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select * from dbo.User_Details";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("AM");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                { 
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpGet("{AplId}")]
        public  JsonResult Get(String AplId)
        {
            string query = @"select * from dbo.User_Details where AplId=@AplId";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("AM");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@AplId",AplId);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpPost]
        public JsonResult Post(UserDetails Id)
        {
            string query = @"
                    insert into dbo.User_Details values 
                    (
                    '" + Id.UserName + @"',
                    '" + Id.UserGuid + @"',
                    '" + Id.RoleName + @"',
                    '" + Id.RoleId + @"',
                    '" + Id.AplId + @"',
                    '" + Id.HasActiveRole + @"'
                    )
                    ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("AM");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }


        [HttpPut]
        public JsonResult Put(UserDetails Id)
        {
            string query = @"
                    update dbo.User_Details set 
                    UserName = '" + Id.UserName + @"',
                    UserGuid = '" + Id.UserGuid + @"',
                    RoleName = '" + Id.RoleName + @"',
                    RoleId = '" + Id.RoleId + @"',
                    AplId = '" + Id.AplId + @"',
                    HasActiveRole = '" + Id.HasActiveRole + @"'
                    where AplId=@AplId 
                    ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("AM");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@AplId", Id.AplId);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Updated Successfully");
        }


        [HttpDelete("{AplId}")]
        public JsonResult Delete(String AplId)
        {
            string query = @"
                    delete from dbo.User_Details
                    where AplId=@AplId 
                    ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("AM");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@AplId", AplId);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Deleted Successfully");
        }
    }
}
