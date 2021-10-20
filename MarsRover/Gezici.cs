using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public enum Yonler
    {
        N = 1, // Kuzey
        S = 2, // Güney
        E = 3, // Doğu
        W = 4  // Batı
    }
    // Hareket fonksiyonu
    public interface IGezici
    {
        /* 
         Alanı
         */
        void Hareket(List<int> Plato, string hareketler);
    }
    public class Gezici: IGezici
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Yonler Yon { get; set; }
        //Varsayılan başlangıç; sol altta ve kuzeye dönük 
        public Gezici()
        {
            X = Y = 0;
            Yon = Yonler.N;
        }
        // Sola dönüş fonksiyonu
        private void Left()
        {
            /* Şu an hangi yöne baktığımıza göre onun solundaki yöne bakacak şekilde ayarlıyor */
            switch (this.Yon)
            {
                case Yonler.N:
                    this.Yon = Yonler.W;
                    break;
                case Yonler.S:
                    this.Yon = Yonler.E;
                    break;
                case Yonler.E:
                    this.Yon = Yonler.N;
                    break;
                case Yonler.W:
                    this.Yon = Yonler.S;
                    break;
                default:
                    break;
            }
        }
        // Sağa dönüş fonksiyonu
        private void Right()
        {
            /* Şu an hangi yöne baktığımıza göre onun sağındaki yöne bakacak şekilde ayarlıyor */
            switch (this.Yon)
            {
                case Yonler.N:
                    this.Yon = Yonler.E;
                    break;
                case Yonler.S:
                    this.Yon = Yonler.W;
                    break;
                case Yonler.E:
                    this.Yon = Yonler.S;
                    break;
                case Yonler.W:
                    this.Yon = Yonler.N;
                    break;
                default:
                    break;
            }
        }
        // Baktığı yöne hareket fonksiyonu
        private void Move()
        {
            /* Şu an hangi yöne baktığımıza göre o yöne +1 ekliyor */
            switch (this.Yon)
            {
                case Yonler.N:
                    this.Y += 1;
                    break;
                case Yonler.S:
                    this.Y -= 1;
                    break;
                case Yonler.E:
                    this.X += 1;
                    break;
                case Yonler.W:
                    this.X -= 1;
                    break;
                default:
                    break;
            }
        }
        public void Hareket(List<int> Plato, string hareketler)
        {
            /* Girdiye göre hangi fonksiyonu kullanacağını ayarlıyor */
            foreach (var hareket in hareketler)
            {
                switch (hareket)
                {
                    case 'M':
                        this.Move();
                        break;
                    case 'L':
                        this.Left();
                        break;
                    case 'R':
                        this.Right();
                        break;
                    default:
                        Console.WriteLine($"Hatalı girdi: {hareketler}\nHareket için L, R veya M kullanınız.");
                        break;
                }

                if (this.X < 0 || this.X > Plato[0] || this.Y < 0 || this.Y > Plato[1])
                {
                    /* Alanın dışına yerleştirilirse veya hareket sonucu alan dışıan çıkarsa vereceği uyarı */
                    throw new Exception($"Alanın dışına yerleştirme yapıldı veya alanın dışına çıkıldı\nPlato: (0 , 0) ve ({Plato[0]} , {Plato[1]})");
                }
            }
        }
    }
}
