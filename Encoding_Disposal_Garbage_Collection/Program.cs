using System;
using System.Text;
using System.IO;
using System.Globalization;

namespace Encoding_Disposal_Garbage_Collection
{
    class Program
    {
        static void Main(string[] args)
        {
            // Encoding
            string str1 = "SĂLUT";
            Encoding ascii_1 = Encoding.ASCII;
            Encoding ascii_2 = Encoding.GetEncoding("ascii");

            Encoding utf_8_1 = Encoding.UTF8;
            Encoding utf_8_2 = Encoding.GetEncoding("UTF-8");

            Encoding utf_16_1 = Encoding.Unicode;
            Encoding utf_16_2 = Encoding.GetEncoding("UTF-16");

            byte[] str1_b = ascii_1.GetBytes(str1);
            byte[] str2_b = ascii_2.GetBytes(str1);

            foreach(var b in str1_b)
                Console.WriteLine(b);
            Console.WriteLine("=====================================");
            foreach(var b in str2_b)
                Console.WriteLine(b);
            Console.WriteLine("=====================================");
            byte[] str3_b = utf_8_1.GetBytes(str1);
            byte[] str4_b = utf_8_2.GetBytes(str1);

            foreach (var b in str3_b)
                Console.WriteLine(b);
            Console.WriteLine("=====================================");
            foreach (var b in str4_b)
                Console.WriteLine(b);
            Console.WriteLine("=====================================");

            byte[] str5_b = utf_16_1.GetBytes(str1);
            byte[] str6_b = utf_16_2.GetBytes(str1);
            byte[] str7_b = Encoding.Unicode.GetBytes(str1);

            foreach (var b in str5_b)
                Console.WriteLine(b);
            Console.WriteLine("=====================================");
            foreach (var b in str6_b)
                Console.WriteLine(b);
            Console.WriteLine("=====================================");
            foreach (var b in str7_b)
                Console.WriteLine(b);
            Console.WriteLine("=====================================");

            string s1 = utf_16_1.GetString(str7_b);
            Console.WriteLine(s1);
            Console.WriteLine("=====================================");
            string s2 = ascii_1.GetString(str7_b);
            Console.WriteLine(s2);
            Console.WriteLine("=====================================");
            string s3 = utf_8_1.GetString(str7_b);
            Console.WriteLine(s3);
            Console.WriteLine("=====================================");

            byte[] str8_b = Encoding.Convert(Encoding.Unicode, Encoding.UTF8, str7_b);
            string s4 = Encoding.UTF8.GetString(str8_b);
            Console.WriteLine(s4);
            Console.WriteLine("=====================================");

            byte[] str9_b = Encoding.Convert(Encoding.Unicode, Encoding.ASCII, str7_b);
            string s5 = Encoding.ASCII.GetString(str9_b);
            Console.WriteLine(s5);
            Console.WriteLine("=====================================");
            // Writing and Reading filestream
            using (FileStream file = new FileStream(@"D:\Amdaris\Text.txt", FileMode.OpenOrCreate))
            {
                string s = new string("Noroc!");
                byte[] b = Encoding.Default.GetBytes(s);
                file.Write(b);
            }
            using (FileStream file = new FileStream(@"D:\Amdaris\Text.txt", FileMode.Append))
            {
                string s = new string("Succes!");
                byte[] b = Encoding.Default.GetBytes(s);
                file.Write(b);
            }
            using (FileStream file = new FileStream(@"D:\Amdaris\Text.txt", FileMode.Open))
            {
                byte[] b = new byte[file.Length];
                file.Read(b, 0, (int)file.Length);
                string s = Encoding.Default.GetString(b);
                Console.WriteLine(s);               
            }
            // Formating, searcing and comparing string
            string str_f1 = $"Noroc, {str1}";
            Console.WriteLine(str_f1);

            string str_f2 = string.Format("Noroc, {0, 20}, 1 MDL = {1, -20:C}, VAT is {2, -10:P}.", str1, 17, 0.2);
            Console.WriteLine(str_f2);

            string str_f3 = "";
            if (str_f2.Contains("17"))
            {
                str_f3 = string.Copy(str_f2);
                Console.WriteLine(str_f2);
                Console.WriteLine(str_f3);
                if (str_f3.CompareTo(str_f2) == 0)
                    Console.WriteLine("Yes");
                if(str_f3.Equals(str_f2))
                    Console.WriteLine("Very Yes");
            }
            str_f3 = str_f3.Replace("17", "18");
            Console.WriteLine(str_f3);
            if(str_f3.StartsWith("N"))
                Console.WriteLine("Super");
            if(str_f3.EndsWith("."))
                Console.WriteLine("Very Super");

            Console.WriteLine(str_f3[0]);

            //DateTime, TimeSpan, DateTimeOffSet, TimeZone
            DateTime dateTime = new DateTime(2008, 03, 01);
            Console.WriteLine(dateTime);            

            DateTime dateTime_hours = new DateTime(2008, 03, 12, 13, 36, 59, DateTimeKind.Utc);
            Console.WriteLine(dateTime_hours);            

            DateTime dateTime_now = DateTime.Now;
            Console.WriteLine(dateTime_now);

            DateTime dateTime_today = DateTime.Today;
            Console.WriteLine(dateTime_today);

            DateTime dateTime_UTCnow = DateTime.UtcNow;
            Console.WriteLine(dateTime_UTCnow);

            string str_t1 = "08/03/2021";
            DateTime parseTime1 = DateTime.Parse(str_t1);
            Console.WriteLine(parseTime1);

            string str_t2 = "08.03.2021";
            DateTime parseTime2 = DateTime.Parse(str_t2);
            Console.WriteLine(parseTime2);

            TimeSpan timeSpan = new TimeSpan(3, 3, 3, 3);
            Console.WriteLine(dateTime_now - timeSpan);

            TimeSpan timeSpan_days = TimeSpan.FromDays(6);
            Console.WriteLine(dateTime_now - timeSpan_days);

            TimeSpan timeSpan_hours = TimeSpan.FromHours(6);
            Console.WriteLine(dateTime_now - timeSpan_hours);

            TimeSpan timeSpan_Sum1 = timeSpan_days + timeSpan_hours;
            Console.WriteLine(timeSpan_Sum1);

            TimeSpan timeSpan_Sum2 = timeSpan_days.Add(timeSpan_hours);
            Console.WriteLine(timeSpan_Sum2);

            if (timeSpan_days > timeSpan_hours)
                Console.WriteLine(timeSpan_days - timeSpan_hours);

            TimeSpan timeSpan_Sum3 = timeSpan_days.Subtract(timeSpan_hours);
            Console.WriteLine(timeSpan_Sum3);

            DateTime begin = dateTime_now.Subtract(timeSpan_days);
            Console.WriteLine(begin);
            
            DateTimeOffset date_of1 = new DateTimeOffset(2021, 03, 08, 10, 30, 30, TimeSpan.FromHours(4));
            Console.WriteLine(date_of1);

            DateTimeOffset date_of2 = DateTimeOffset.Now;
            Console.WriteLine(date_of2);

            DateTimeOffset date_of3 = DateTimeOffset.UtcNow;
            Console.WriteLine(date_of3);
            
            if(date_of3.Equals(date_of2))
                Console.WriteLine("It is UNREALLLLLL");

            TimeZoneInfo t_zone1 = TimeZoneInfo.Local;
            Console.WriteLine(t_zone1);

            Console.WriteLine(t_zone1.DaylightName);
            Console.WriteLine(t_zone1.BaseUtcOffset);
            Console.WriteLine(t_zone1.DisplayName);

            //CultureInfo

            CultureInfo cult1 = CultureInfo.GetCultureInfo("ro-MD");
            Console.WriteLine(100.ToString("C", cult1));

            CultureInfo cult2 = CultureInfo.GetCultureInfo("en-RO");
            Console.WriteLine(100.ToString("C", cult2));

            CultureInfo cult3 = CultureInfo.GetCultureInfo("en-CH");
            Console.WriteLine(100.ToString("C", cult3));

            CultureInfo cult4 = CultureInfo.CurrentCulture;
            Console.WriteLine(100.ToString("C", cult4));

            CultureInfo cult5 = CultureInfo.InvariantCulture;
            Console.WriteLine(DateTime.Now.ToString(cult5));

            CultureInfo cult6 = CultureInfo.GetCultureInfo("ru-RU");
            Console.WriteLine(DateTime.Now.ToString(cult6));

            //NumberFormatInfo

            NumberFormatInfo numb = new NumberFormatInfo();
            numb.NumberGroupSeparator = " ";
            numb.NumberDecimalSeparator = ",";
            numb.PercentSymbol = "%";
            Console.WriteLine(9.ToString("P3", numb));
            
            //Dispose
            Car car = new Car { Name = "Audi", MaxSpeed = 250 };
            car.TimeToTravell(new Rout { city_A = "Chisinau", city_B = "Balti", distance = 150 });
            car.Dispose();
        }        
    }
}
