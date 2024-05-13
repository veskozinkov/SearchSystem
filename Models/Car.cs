using SearchSystem.Others.Attributes;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SearchSystem.Models
{
    internal class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("ID")]
        [Filterable(false)]
        public int Id { get; set; }

        [DisplayName("Brand")]
        [Filterable(true)]
        public CarBrand Brand { get; set; }

        [DisplayName("Price")]
        [Filterable(true)]
        public int Price { get; set; }

        [DisplayName("Fuel")]
        [Filterable(true)]
        public CarFuel Fuel { get; set; }

        [DisplayName("Transmission")]
        [Filterable(true)]
        public CarTransmission Transmission { get; set; }

        [DisplayName("First registration")]
        [Filterable(true)]
        public DateTime FirstRegistration { get; set; }

        [DisplayName("Power")]
        [Filterable(true)]
        public int Power { get; set; }

        [DisplayName("Mileage (km)")]
        [Filterable(true)]
        public int Mileage { get; set; }

        [DisplayName("Color")]
        [Filterable(true)]
        public CarColor Color { get; set; }

        [DisplayName("Doors")]
        [Filterable(true)]
        public CarDoors Doors { get; set; }

        [DisplayName("Cabriolet")]
        [Filterable(true)]
        public bool Cabriolet { get; set; }

        [DisplayName("European emission standard")]
        [Filterable(true)]
        public CarEuropeanEmissionStandard EuropeanEmissionStandard { get; set; }

        [DisplayName("City")]
        [Filterable(true)]
        public CarCity City { get; set; }
    }
}
