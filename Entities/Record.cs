using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FinanzasBE.DTOs;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FinanzasBE.Entities
{
    public class Record
    {
        // Attribute properties
        [Key] public int RecordId { get; set; }
        [ForeignKey("User")] public int UserId { get; set; }

        [DataType(DataType.Text)] public string Message { get; set; }

        [DataType(DataType.Date)] public DateTime Date { get; set; }

        // Navigation properties
        public User User { get; set; }

        public Record()
        {
        }


        public override string ToString()
        {
            return $"Pyme {{ RecordId: {RecordId}, Message: {Message}, DateTime: {Date}, UserId: {UserId} }}";
        }
    }
}