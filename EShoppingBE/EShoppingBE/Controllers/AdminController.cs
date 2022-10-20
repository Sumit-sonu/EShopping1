using EShoppingBE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace EShoppingBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public AdminController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("addUpdateProduct")]

        public Response addUpdateProduct(Products prodcuts)
        {
            DAL dal  = new DAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("EProdCS").ToString());
            Response response = dal.addUpdateProduct(prodcuts, connection);
            return response;
        }
        [HttpGet]
        [Route("userList")]

        public Response userList()
        {
            DAL dal = new DAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("EProdCS").ToString());
            Response response = dal.userList(connection);
            return response;
        }
    }
}
