using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bài_tập_về_nhà
{
    internal class Program
    {
        class nghia
        {
            private string name;
            private int id;
            private string lop;
            private string github;
            private string email;
            public nghia()
            {
                this.name = "";
                this.id = 0;
                this.lop = "";
                this.github = "";
                this.email = "";
            }
            public nghia(string name,int id,string lop,string github,string email)
            {
                this.name = name;
                this.id = id;
                this.lop = lop;
                this.github = github;
                this.email = email;
            }
            public void nhap()
            {
                Console.Write("Nhập tên sinh viên của bạn : ");
                this.name=Console.ReadLine();
                do
                {
                    if (this.name == "")
                    {
                        Console.WriteLine("Tên không được rỗng !");
                        Console.Write("Nhập lại tên : ");
                        this.name = Console.ReadLine();
                    }
                } while (this.name == "");
                Console.Write("Nhập mã sinh viên của bạn : ");
                this.id=int.Parse(Console.ReadLine());
                do
                {
                    if (this.id <= 0)
                    {
                        Console.WriteLine("ID không hợp lệ ! ");
                        Console.Write("Nhập lại ID của bạn : ");
                        this.id=int.Parse(Console.ReadLine());
                    }
                }while(this.id == 0);
                Console.Write("Nhập tên lớp của bạn : ");
                this.lop=Console.ReadLine();
                do
                {
                    if (this.lop == "")
                    {
                        Console.WriteLine("Tên lớp không được rỗng !");
                        Console.Write("Nhập lại lớp : ");
                        this.lop = Console.ReadLine();
                    }
                } while (this.lop == "");
                Console.Write("Nhập tên tài khoản Github của bạn : ");
                this.github=Console.ReadLine();
                do
                {
                    if (this.github == "")
                    {
                        Console.WriteLine("Tên tài khoản không được rỗng !");
                        Console.Write("Nhập lại tên tài khoản : ");
                        this.github = Console.ReadLine();
                    }
                } while (this.github == "");
                Console.Write("Nhập email của bạn : ");
                this.email=Console.ReadLine();
                while (true)
                {
                    if (this.email == "")
                    {
                        Console.WriteLine("Email không được rỗng ! ");
                        Console.Write("Nhập lại email : ");
                        this.email = Console.ReadLine();
                    }
                    else if (!this.email.Contains("@"))
                    {
                        Console.WriteLine("Email không hợp lệ !");
                        Console.Write("Nhập lại email : ");
                        this.email = Console.ReadLine();

                    }
                    else
                    {
                        this.email = email;
                        break;

                    }

                }
            }
            public void hienthi()
            {
                Console.WriteLine($"{this.name}\t{this.id}\t{this.lop}\t{this.github}\t{this.email}");
            }

        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            nghia nghiahy=new nghia();
            nghiahy.nhap();
            nghiahy.hienthi();
            Console.ReadKey();
        }
    }
}
