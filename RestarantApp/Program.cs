using System;
using System.Collections.Generic;
using System.Linq; // เพิ่มเพื่อใช้คำสั่ง .Average() ในการหาค่าเฉลี่ย

namespace RestaurantApp
{
    public class Restaurant
    {
        public string RestaurantId { get; set; }
        public string Name { get; set; }
        public string RestaurantType { get; set; }
        public double Rating { get; set; }

        private bool _isCommitted = false;

        public Restaurant(string id, string name, string type, double rating)
        {
            RestaurantId = id;
            Name = name;
            RestaurantType = type;
            Rating = rating;
        }

        public void Commit()
        {
            if (!_isCommitted)
            {
                _isCommitted = true;
                Console.WriteLine($"[Commit] บันทึกข้อมูลร้าน '{Name}' (ID: {RestaurantId}) เข้าสู่ระบบแล้ว;");
            }
        }

        public void DisplaySummary()
        {
            Console.WriteLine($"รหัส: {RestaurantId} | ชื่อ: {Name} | ประเภท: {RestaurantType} | คะแนน: {Rating:F1} ★");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            List<Restaurant> restaurantList = new List<Restaurant>()
            {
                new Restaurant("R0001", "ตำแซ่บเวอร์", "อาหารอีสาน", 4.9),
                new Restaurant("R0002", "ชานมไข่มุก", "เครื่องดื่ม", 4.7),
                new Restaurant("R0003", "ชาบูอินดี้", "ชาบู", 4.5),
                new Restaurant("R0004", "เบอร์เกอร์ฟาสต์", "อาหารฟาสต์", 4.8),
                new Restaurant("R0005", "เบเกอรี่เฮ้าส์", "เบเกอรี่", 4.6)
                new Restaurant("R0006", "ครัวคุณต้อย", "อาหารตามสั่ง", 4.7)
                new Restaurant("R0007", "จระเข้หานใหญ่", "อาหารป่า", 4.8)


            };

            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("               รายชื่อร้านอาหารทั้งหมด        ");
            Console.WriteLine("---------------------------------------------");
            foreach (var shop in restaurantList)
            {
                shop.DisplaySummary();
            }
            Console.WriteLine("---------------------------------------------");

            // --- ส่วนที่เพิ่มเข้ามาเพื่อคำนวณและแสดงผลรวม/ค่าเฉลี่ย ---
            int totalRestaurants = restaurantList.Count;
            double averageRating = restaurantList.Average(r => r.Rating);

            Console.WriteLine($"จำนวนร้านทั้งหมด: {totalRestaurants} ร้าน");
            Console.WriteLine($"คะแนนเฉลี่ยของทุกร้าน: {averageRating:F2} ดาว");
            Console.WriteLine("---------------------------------------------\n");

            // --- ส่วนการ Commit ข้อมูล ---
            Console.WriteLine("---------- เริ่มทำการ Commit ข้อมูล ----------");
            foreach (var shop in restaurantList)
            {
                shop.Commit();
            }
            Console.WriteLine("---------------------------------------------\n");

            Console.ReadKey();
        }
    }
}

