using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai1_C_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }
        static void Menu()
        {
            List<Bike> lst = new List<Bike>() 
            {
                new Bike(1,"xe dap 1","vn"),
                new Bike(2,"xe dap 2","tau`"),
                new Bike(3,"xe dap 3","trung quoc"),
                new Bike(4,"xe dap 4","dong lao`"),
                new Bike(5,"xe dap 5","dai loan"),
                new Bike(6,"xe dap 6","vn"),
                new Bike(7,"xe dap 7","tau`"),
            };
            string path = @"D:\FPT\Factory\ProgressTests\Bai1_C#2\Bai1_C#2\BikeFile.txt";
            SERVICE sv = new SERVICE();
            int chon;
            do
            {
                Console.WriteLine("_________MENU_________");
                Console.WriteLine("1. Nhập");
                Console.WriteLine("2. Xuất");
                Console.WriteLine("3. Ghi file");
                Console.WriteLine("4. Đọc file");
                Console.WriteLine("5. Xoa theo ID");
                Console.WriteLine("0. Thoat");
                Console.WriteLine("Moi chon chuong trinh");
                chon = Convert.ToInt32(Console.ReadLine());
                switch (chon)
                {
                    case 1: sv.Nhap(lst);
                        break;
                    case 2: sv.Xuat(lst);
                        break;
                    case 3: File.WriteAllText(path, ""); 
                        sv.GhiFile(path, lst);
                        break;
                    case 4: List<Bike> bikes = sv.DocFile(path);
                        foreach (var item in bikes)
                        {
                            item.InThongTin();
                        }
                        break;
                    case 5: sv.XoaBike(lst);
                        break;
                    case 0:
                        Console.WriteLine("Nhan phim bat ky de thoat");
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            } while (chon!=0);
        }
    }
}
