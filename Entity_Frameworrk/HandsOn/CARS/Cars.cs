using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CARS
{
    public class Cars
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CarId { get; set; }
        public string Brand { get; set; }

        public string Model { get; set; }   

        public double price { get; set; }
    }
}
