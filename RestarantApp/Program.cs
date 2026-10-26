using System;
using System.Collections.Generic;

namespace RestarantApp
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
                Console.WriteLine($"💾 [Commit] บันทึกข้อมูลร้าน '{Name}' (ID: {RestaurantId}) เข้าสู่ระบบแล้ว");
            }
        }

        public void DisplaySummary()
        {
            Console.WriteLine($"รหัส: {RestaurantId} | ชื่อ: {Name} | ประเภท: {RestaurantType} | คะแนน: {Rating:F1}★");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // อัปเดต: เพิ่มข้อมูลร้านอาหารอีสานที่ 4 และ 5 เข้าไปใน List
            List<Restaurant> restaurantList = new List<Restaurant>()
            {
                new Restaurant("R001", "ตำแซ่บระเบิดเมือง", "อาหารอีสาน", 4.9),
                new Restaurant("R002", "ลาบก้อยร้อยเอ็ด", "อาหารอีสาน", 4.7),
                new Restaurant("R003", "ไก่ย่างนิตยา", "อาหารอีสาน", 4.5),
                new Restaurant("R004", "ส้มตำปูปลาร้าเจ้ไก่", "อาหารอีสาน", 4.8), // เพิ่มร้านที่ 4
                new Restaurant("R005", "แซ่บวันรัชดา", "อาหารอีสาน", 4.6)     // เพิ่มร้านที่ 5
            };

            Console.WriteLine("==================================================");
            Console.WriteLine("               รายชื่อร้านอาหารทั้งหมด             ");
            Console.WriteLine("==================================================");
            foreach (var shop in restaurantList)
            {
                shop.DisplaySummary();
            }
            Console.WriteLine("==================================================\n");

            Console.WriteLine("--- เริ่มต้นการ Commit ข้อมูล ---");
            foreach (var shop in restaurantList)
            {
                shop.Commit();
            }
            Console.WriteLine("---------------------------------\n");

            Console.ReadKey();
        }
    }
}

