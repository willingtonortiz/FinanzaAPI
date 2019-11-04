using System.ComponentModel.DataAnnotations;
using FinanzasBE.DTOs;

namespace FinanzasBE.Entities
{
    public class User
    {
        [Key] public int UserId { get; set; }

        [DataType(DataType.Text)] public string Username { get; set; }

        [DataType(DataType.Password)] public string Password { get; set; }

        [DataType(DataType.Text)] public string Role { get; set; }

        public Pyme Pyme { get; set; }


        public User()
        {
        }


        public override string ToString()
        {
            return $"User {{ UserId: {UserId}, Username: {Username}, Password: {Password}, Role: {Role} }}";
        }
    }
}