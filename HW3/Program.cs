using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw3
{
    internal class Program
    {
        public class NhanVien
        {
            public string Ten { get; set; }

            public NhanVien(string ten)
            {
                Ten = ten;
            }
        }

        public class MatHang
        {
            public double Gia { get; set; }
            public double GiamGia { get; set; }

            public MatHang(double gia, double giamGia)
            {
                Gia = gia;
                GiamGia = giamGia;
            }
        }

        public class HoaDonMuaSam
        {
            private NhanVien nhanVien;
            private List<MatHang> danhSachMatHang;

            public HoaDonMuaSam(NhanVien nhanVien)
            {
                this.nhanVien = nhanVien;
                danhSachMatHang = new List<MatHang>();
            }

            public void ThemMatHang(MatHang matHang)
            {
                danhSachMatHang.Add(matHang);
            }

            public double TinhTongTien()
            {
                double tongTien = 0.0;
                foreach (MatHang matHang in danhSachMatHang)
                {
                    tongTien += matHang.Gia;
                }
                return tongTien;
            }

            public void InHoaDon()
            {
                Console.WriteLine("Hoa Don cho Nhan Vien: " + nhanVien.Ten);
                foreach (MatHang matHang in danhSachMatHang)
                {
                    Console.WriteLine("Mat Hang: $" + matHang.Gia);
                }
                Console.WriteLine("Tong: $" + TinhTongTien());
            }
        }

        public class HoaDonGiamGia : HoaDonMuaSam
        {
            private bool khachHangUaThich;
            private int soMatHangDuocGiamGia;
            private double tongGiamGia;

            public HoaDonGiamGia(NhanVien nhanVien, bool khachHangUaThich) : base(nhanVien)
            {
                this.khachHangUaThich = khachHangUaThich;
                soMatHangDuocGiamGia = 0;
                tongGiamGia = 0.0;
            }

            public new void ThemMatHang(MatHang matHang)
            {
                base.ThemMatHang(matHang);
                if (khachHangUaThich && matHang.GiamGia > 0)
                {
                    soMatHangDuocGiamGia++;
                    tongGiamGia += matHang.GiamGia;
                }
            }

            public int LaySoMatHangDuocGiamGia()
            {
                return soMatHangDuocGiamGia;
            }

            public double LayTongGiamGia()
            {
                return tongGiamGia;
            }

            public double LayTyLeGiamGia()
            {
                if (khachHangUaThich && TinhTongTien() > 0)
                {
                    return (tongGiamGia / TinhTongTien()) * 100.0;
                }
                else
                {
                    return 0.0;
                }
            }
        }

        public class ChucNangChinh
        {
            public static void Main(string[] args)
            {
                NhanVien nhanVien = new NhanVien("John");
                MatHang matHang1 = new MatHang(1.35, 0.25);
                MatHang matHang2 = new MatHang(2.0, 0.0);

                // Kiểm tra HoaDonMuaSam
                HoaDonMuaSam hoaDonMuaSam = new HoaDonMuaSam(nhanVien);
                hoaDonMuaSam.ThemMatHang(matHang1);
                hoaDonMuaSam.ThemMatHang(matHang2);
                hoaDonMuaSam.InHoaDon();

                // Kiểm tra HoaDonGiamGia
                HoaDonGiamGia hoaDonGiamGia = new HoaDonGiamGia(nhanVien, true);
                hoaDonGiamGia.ThemMatHang(matHang1);
                hoaDonGiamGia.ThemMatHang(matHang2);
                Console.WriteLine("So Mat Hang Duoc Giam Gia: " + hoaDonGiamGia.LaySoMatHangDuocGiamGia());
                Console.WriteLine("Tong Giam Gia: $" + hoaDonGiamGia.LayTongGiamGia());
                Console.WriteLine("Ty Le Giam Gia: " + hoaDonGiamGia.LayTyLeGiamGia() + "%");
            }
        }
    }
}
