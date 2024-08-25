using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BookQuoteApiApp.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
