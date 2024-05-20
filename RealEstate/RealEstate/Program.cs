using RealEstate;

class Program
{
    static void Main(string[] args)
    {
        List<Ad> hirdetesek = Ad.LoadFromCsv("realestates.csv").ToList();

//      List<Ad> hirdetesek = Ad.LoadFromJson("realestates.json").ToList();
        

        Console.WriteLine("1. Földszintes ingatlanok átlagos alapterülete: {0:F2} m2",
            hirdetesek.Where(x=>x.Floors == 0).Average(x=>x.Area));

        
        var adat = hirdetesek.Where(x=> x.FreeOfCharge).OrderBy(x=> x.DistanceTo(47.4164220114023, 19.066342425796986)).First();
        Console.WriteLine("2. Mesevár óvodához légvonalban a legközelebbi tehermentes ingatlan adatai:");
        Console.WriteLine("\tEladó neve: {0}", adat.Seller.Name);
        Console.WriteLine("\tEladó telefonja: {0}", adat.Seller.Phone);
        Console.WriteLine("\tAlapterület: {0}", adat.Area);
        Console.WriteLine("\tSzobák száma: {0}", adat.Rooms);



        Console.ReadLine();
    }
}