using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM2_1651_NguyenDinhTam_GCD210186
{
    internal class AirlineStaff : Person
    {
        private int staffId;  // Trường riêng tư để lưu trữ ID của nhân viên.

        // Constructor mặc định cho lớp "AirlineStaff".
        public AirlineStaff() { }

        // Constructor với tham số cho lớp "AirlineStaff".
        // Nó khởi tạo tên, số điện thoại, quốc gia, hộ chiếu và ID của nhân viên.
        public AirlineStaff(string name, int phone, string country, string passport, int staffId) : base(name, phone, country, passport)
        {
            StaffID = staffId;
        }

        // Thuộc tính để lấy và đặt ID của nhân viên.
        public int StaffID
        {
            get { return staffId; }
            set { staffId = value; }
        }

        // Ghi đè phương thức "PrintInfo" của lớp cơ sở để bao gồm thông tin nhân viên.
        public override void PrintInformation()
        {
            Console.WriteLine("Staff information:");
            Console.WriteLine("ID: " + StaffID);  // In ra ID của nhân viên.
            base.PrintInformation();  // Gọi phương thức PrintInfo của lớp cơ sở để in tên, số điện thoại,...
        }
    }
}
