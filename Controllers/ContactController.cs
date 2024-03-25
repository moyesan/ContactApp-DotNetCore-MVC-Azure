using contact_app_mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace contact_app_mvc.Controllers
{
    public class ContactController : Controller
    {
        private readonly IConfiguration _configuration;

        public ContactController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        //public string Index() 
        //{
        //    return "this is contact index";
        //}
       

        [HttpGet]
        public IEnumerable<Contact> Get()
        {
            var contacts = GetContacts();
            return contacts;
        }
        private IEnumerable<Contact> GetContacts()
        {
            var Contacts = new List<Contact>();

            var conn = _configuration["ContactDBConnectionString"];

            using (var connection = new SqlConnection(conn))
            {
                var sql = "SELECT * FROM tblContact";
                connection.Open();
                using SqlCommand command = new SqlCommand(sql, connection);
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var contact = new Contact()
                    {
                        ContactId = (int)reader["ContactId"],
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Email = reader["Email"].ToString(),
                        PhoneNumber = reader["PhoneNumber"].ToString(),
                    };
                    Contacts.Add(contact);
                }
            }
            return Contacts;
        }
    }
}
