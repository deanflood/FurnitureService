using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace FurnitureService.Models
{
    public enum Type
    {
        BED,
        CHAIR,
        TABLE
    }

    [DataContract]
    public class Furniture
    {
        public static int CounterId { get; set; }

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Make { get; set; }
        [DataMember]
        public Type Type { get; set; }
        [DataMember]
        public double Price { get; set; }
        [DataMember]
        public bool IsAvailable { get; set; }

        public Furniture (string make, Type type, double price, bool isAvailable)
        {
            Id = CounterId;
            CounterId++;
            Make = make;
            Type = type;
            Price = price;
            IsAvailable = isAvailable;
        }

    }
}