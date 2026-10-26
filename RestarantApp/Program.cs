using System;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantApp
{
    public class Restaurant
    {
        public string RestaurantId { get; set; }
        public string Name { get; set; }
        public string RestaurantType { get; set; }
        public double Rating { get; set; }
        public List<string> Menus { get; set; } // <-- เพิ่ม Property สำหรับเก็บรายการเมนู

        private bool _isCommitted = false;

        // ปรับปรุง Constructor ให้รับ List<string> ของเมนูเข้ามาด้วย
        public Restaurant(string id, string name, string type, double rating, List<string> menus)
        {
            RestaurantId = id;
            Name = name;
            RestaurantType = type;
            Rating = rating;
            Menus = menus;
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
            // แสดงเมนูแนะนำต่อท้ายรายชื่อร้าน
            Console.WriteLine($"   ↳ เมนูแนะนำ: {string.Join(", ", Menus)}");
        }
    }
    
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // เพิ่มรายการเมนูเข้าไปในแต่ละร้านค้าตอนประกาศ List
            List<Restaurant> restaurantList = new List<Restaurant>()
            {
                new Restaurant("R0001", "ตำแซ่บเวอร์", "อาหารอีสาน", 4.9, new List<string> { "ส้มตำปูปลาร้า", "ไก่ย่าง" }),
                new Restaurant("R0002", "ชานมไข่มุก", "เครื่องดื่ม", 4.7, new List<string> { "ชานมไต้หวันพ่นไฟ" }),
                new Restaurant("R0003", "ชาบูอินดี้", "ชาบู", 4.5, new List<string> { "เนื้อริบอายสไลด์", "น้ำซุปดำ" }),
                new Restaurant("R0004", "เบอร์เกอร์ฟาสต์", "อาหารฟาสต์", 4.8, new List<string> { "ดับเบิ้ลชีสเบอร์เกอร์" }),
                new Restaurant("R0005", "เบเกอรี่เฮ้าส์", "เบเกอรี่", 4.6, new List<string> { "ครัวซองต์เนยสด" }),
                new Restaurant("R0006", "ครัวคุณต้อย", "อาหารตามสั่ง", 4.7, new List<string> { "กะเพราเนื้อไข่ดาว" }), // <-- เพิ่มเมนูให้ครัวคุณต้อย
                new Restaurant("R0007", "จระเข้หานใหญ่", "อาหารป่า", 4.8, new List<string> { "ผัดเผ็ดหมูป่า", "ต้มยำไก่บ้าน" }) // <-- เพิ่มเมนูให้จระเข้หานใหญ่
                new Restaurant("R0009", "ร้าน1", "อาหารทั่วไป", 4.5, new List<string> { "ข้าวผัดไข่", "น้ำเปล่า" }) // <-- เพิ่มร้าน1 ตรงนี้ครับ
                new Restaurant("R0010", "Shop 2", "Street Food", 4.6, new List<string> { "Pad Thai", "Iced Tea" }) // <-- เพิ่ม Shop 2 ตรงนี้ครับ

            };
            // --- สลับมาจัดเรียงลำดับร้านค้าตามคะแนนรีวิวจากน้อยไปมาก ---
            restaurantList = restaurantList.OrderBy(r => r.Rating).ToList();

            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("         All Restaurants (Sorted Low to High) ");
            Console.WriteLine("---------------------------------------------");
            foreach (var shop in restaurantList)
            {
                shop.DisplaySummary();
            }



            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("               รายชื่อร้านอาหารทั้งหมด        ");
            Console.WriteLine("---------------------------------------------");
            foreach (var shop in restaurantList)
            {
                shop.DisplaySummary();
            }
            Console.WriteLine("---------------------------------------------");

            int totalRestaurants = restaurantList.Count;
            double averageRating = restaurantList.Average(r => r.Rating);

            Console.WriteLine($"จำนวนร้านทั้งหมด: {totalRestaurants} ร้าน");
            Console.WriteLine($"คะแนนเฉลี่ยของทุกร้าน: {averageRating:F2} ดาว");
            Console.WriteLine("---------------------------------------------\n");

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

