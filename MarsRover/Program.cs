using System;
using System.Linq;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            // Konsoldan girdiler alındı
            var Plato = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToList();
            var Baslangic = Console.ReadLine().Trim().Split(' ');
            // Gezici oluşturuldu
            Gezici gezici = new Gezici();
            // Başlangıç için verilenler gezici içindeki ilgili özelliklere atandı
            if (Baslangic.Count() == 3)
            {
                gezici.X = Convert.ToInt32(Baslangic[0]);
                gezici.Y = Convert.ToInt32(Baslangic[1]);
                gezici.Yon = (Yonler)Enum.Parse(typeof(Yonler), Baslangic[2]);
            }
            // Hareketler okundu
            var hareketler = Console.ReadLine().ToUpper();
            // Oluşturulan alan içerisinde verilen komutlar uygulandı
            // Sonucunda araç hala alan içerisidneyse konumu ve yönü verilecek alan içerisinde değilse ayarlanan exception gösterilecek
            try
            {
                gezici.Hareket(Plato, hareketler);
                Console.WriteLine($"{gezici.X} {gezici.Y} {gezici.Yon}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine($"Son konum: {gezici.X} {gezici.Y} {gezici.Yon}");
            }
        }
    }
}
