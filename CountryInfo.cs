using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIClint
{
    internal class CountryInfo
    {
        public string officalName {  get; set; }
        public List<string> capital { get; set; }
        public double area { get; set; }

        //public CountryInfo(string officalName, string capital, double area) 
        //{
        //    this.officalName = officalName;
        //    this.capital = capital;
        //    this.area = area;
        //}
        public override string ToString()
        {
            return $"officalName: {officalName} capital: {capital} area: {area} ";
        }
    }
}
