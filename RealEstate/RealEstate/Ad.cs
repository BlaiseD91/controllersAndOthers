using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Newtonsoft.Json;

namespace RealEstate
{
    public class Ad
    {
        public int Area { get; set; }
        public Category Category { get; set; }
        public DateTime CreateAt { get; set; }
        public string Description { get; set; }
        public int Floors { get; set; }
        public bool FreeOfCharge { get; set; }
        public int Id { get; set; }
        public string ImgUrl { get; set; }
        public string LatLong { get; set; }
        public int Rooms { get; set; }
        public Seller Seller { get; set; }

        public Ad() { }
        public Ad(string sor)
        {
            string[] adatok = sor.Split(";");
            this.Id = Convert.ToInt32(adatok[0]);
            this.Rooms = Convert.ToInt32(adatok[1]);
            this.LatLong = adatok[2];
            this.Floors = Convert.ToInt32(adatok[3]);
            this.Area = Convert.ToInt32(adatok[4]);
            this.Description = adatok[5];
            this.FreeOfCharge = adatok[6] == "1";
            this.ImgUrl = adatok[7];
            this.CreateAt = Convert.ToDateTime(adatok[8]);
            this.Seller = new Seller() { Id = Convert.ToInt32(adatok[9]), Name = adatok[10] , Phone = adatok[11] };
            this.Category = new Category() { Id = Convert.ToInt32(adatok[12]), Name = adatok[13] };

        }

        public static IEnumerable<Ad> LoadFromCsv(string filename)
        {
            foreach (string sor in File.ReadAllLines(filename).Skip(1))
            {
                yield return new Ad(sor);
            }
            
        
        }

        public static IEnumerable<Ad> LoadFromJson(string filename)
        {
            //Ehhez NuggetPkgManagerrel hozzáadjuk a Newtonsoft.Json függöséget
            return JsonConvert.DeserializeObject<Ad[]>(File.ReadAllText(filename));

        }

        public double DistanceTo(double x, double y)
        {
            double dx = Math.Abs(Convert.ToDouble(this.LatLong.Split(',')[0].Replace('.',',')) - x);
            double dy = Math.Abs(Convert.ToDouble(this.LatLong.Split(',')[1].Replace('.', ',')) - y);
            return Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2));
        }
    }
}
