using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai1_C_2
{
    internal class SERVICE
    {
        public void Nhap(List<Bike> lst)
        {
            string tiepTuc;
            int id = 1;
            do
            {
                Bike bk = new Bike();
                //Console.WriteLine("Moi nhap id");
                foreach (var item in lst)
                {
                    if (item.Id == id)
                    {
                        id++;
                    }
                }
                bk.Id = id;
                Console.WriteLine("Moi nhap ten");
                bk.Ten = Console.ReadLine();
                Console.WriteLine("Moi nhap hang san xuat");
                bk.Hsx = Console.ReadLine();
                lst.Add(bk);
                Console.WriteLine("Ban co muon nhap tiep? (co/ko)");
                tiepTuc = Console.ReadLine();
            } while (tiepTuc.Equals("co"));
        }

        public void Xuat(List<Bike> lst)
        {
            if (lst.Count == 0)
            {
                Console.WriteLine("DS trong");
                return;
            }
            foreach (var item in lst)
            {
                item.InThongTin();
            }
        }
        public void GhiFile(string path, List<Bike> lst)
        {
            if (File.Exists(path))
            {
                foreach (var item in lst)
                {
                    string line = item.ObjToString();
                    File.AppendAllText(path, line);
                }
                Console.WriteLine("Ghi File thanh cong");
            }
            else
            {
                Console.WriteLine("File khong ton tai");
            }
        }

        public List<Bike> DocFile(string path)
        {
            List<Bike> lst = new List<Bike>();
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                if (line.Trim().Length == 0)
                {
                    continue;
                }
                else
                {
                    string[] attribute = line.Split('|');
                    Bike bk = new Bike();
                    bk.Id = Convert.ToInt32(attribute[0]);
                    bk.Ten = attribute[1];
                    bk.Hsx = attribute[2];
                    lst.Add(bk);
                }
            }
            return lst;
        }

        public void XoaBike(List<Bike> lst)
        {
            Console.WriteLine("Moi nhap id xe muon xoa");
            int id = Convert.ToInt32(Console.ReadLine());
            Bike obj = lst.FirstOrDefault(x=>x.Id == id);
            if (obj == null)
            {
                Console.WriteLine("Khong tim duoc xe nao");
            }
            else
            {
                foreach (var item in lst)
                {
                    if (item.Id == obj.Id)
                    {
                        lst.Remove(item);
                    }
                }
            }
        }
    }
}
