using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureFunctionChartCalc.Models
{
    public class Rating
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public double RatingOutOfTen { get; set; }
    }
}
