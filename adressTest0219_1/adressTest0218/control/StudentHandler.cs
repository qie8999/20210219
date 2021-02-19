using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adressTest0218.control
{
    class StudentHandler
    {

        const int MENU_ADD = 1;
        const int MENU_VIEW = 2;
        const int MENU_RANDOM_ADD = 3;
        const int MENU_DEL = 4;
        const int MENU_RENAME = 5;
        const int MENU_EXIT = 6;
        const int MENU_CLEAN = 7;
        static List<Student> addrList = new List<Student>();
        static Random r = new Random();



        public StudentHandler()
        {
            while (true)
            {
                switch (getMenu())
                {
                    case MENU_ADD:
                        addItem();
                        break;
                    case MENU_VIEW:
                        viewItem();
                        break;
                    case MENU_RANDOM_ADD:
                        randItem();
                        break;
                    case MENU_DEL:
                        delItem();
                        break;
                    case MENU_RENAME:
                        reName();
                        break;

                    case MENU_EXIT:
                        Console.WriteLine("프로그램 종료");
                        Environment.Exit(0);
                        break;

                    case MENU_CLEAN:
                        cleanItem();
                        break;
                }
            }
        }

        public static int getMenu()
        {
            Console.WriteLine("----------------------");
            Console.WriteLine("1.주소록 정보 추가");
            Console.WriteLine("2.주소록 정보 보기");
            Console.WriteLine("3.랜덤 정보 추가");
            Console.WriteLine("4.주소록 삭제");
            Console.WriteLine("5.주소록 수정");
            Console.WriteLine("6.종료");
            Console.WriteLine("7.주소록 전체 삭제");
            Console.WriteLine("----------------------");
            Console.Write("메뉴 선택 : ");

            int menu = Convert.ToInt32(Console.ReadLine());
            return menu;
        }

        public static void addItem()
        {
            Console.WriteLine("---------------");
            Console.WriteLine("주소록 정보 입력");
            Console.WriteLine("---------------");
            Console.WriteLine("ID: ");
            string id = Console.ReadLine();
            Console.Write("이름: ");
            string name = Console.ReadLine();
            Console.Write("전화: ");
            string tel = Console.ReadLine();
            Console.Write("주소: ");
            string address = Console.ReadLine();
            Console.Write("이메일: ");
            string email = Console.ReadLine();

            /* Student st = new Student(name, tel, address, email);
             return st;*/
            addrList.Add(new Student(id, name, tel, address, email));
        }

        public static void viewItem()
        {
            if (addrList.Count > 0)
            {
                for (int i = 0; i < addrList.Count; i++)
                {

                    Console.WriteLine("번호: " + (i + 1));
                    Console.WriteLine("ID : " + addrList[i].Id);
                    Console.WriteLine("이름 : " + addrList[i].Name);
                    Console.WriteLine("전화 : " + addrList[i].Tel);
                    Console.WriteLine("주소 : " + addrList[i].Adress);
                    Console.WriteLine("이메일 : " + addrList[i].Email);
                    Console.WriteLine("---------------------------");
                }
            }
            else
            {
                Console.WriteLine("데이터가 없습니다.");
            }
        }

        public static void randItem()
        {
            //Random rand = new Random();


            string[] name = { "홍길동", "박길동", "이길동", "최길동", "김길동" };
            string[] tel = { "010-1234-5678", "010-0000-5678", "010-1000-5678", "010-1234-5000", "010-1200-5008" };
            string[] address = { "대구시 동구 신암4동", "서울시 동구", "서울시 서구", "서울시 강남", "서울시 강북" };
            string[] email = { "a@naver.com", "b@naver.com", "c@naver.com", "d@naver.com", "e@naver.com" };




            for (int i = 0; i < 10; i++)
            {
                addrList.Add(new Student(getID(), name[r.Next(5)], tel[r.Next(5)], address[r.Next(5)], email[r.Next(5)]));
                //Thread.Sleep(30);
            }


        }

        public static void delItem()
        {
            Console.Write("삭제할 ID : ");
            string id = Console.ReadLine();
            Console.WriteLine("--------------");

            for (int i = 0; i < addrList.Count; i++)
            {

                if (addrList[i].Id.Equals(id))
                {
                    addrList.RemoveAt(i--);

                }
            }


        }

        public static void cleanItem()
        {
            addrList.Clear();
            Console.WriteLine("주소록 전체 삭제 완료");
        }

        static string getID()
        {

            string rdata = "abcdefghijklmnopqrstuvwxyz0123456789" +
                "ABCDEFGHIJKLMNOPQRSTUVWXYZ" + "~!@#$%^&*?";
            StringBuilder rs = new StringBuilder();

            for (int i = 0; i < 10; i++)
            {
                rs.Append(rdata[(int)(r.NextDouble() * rdata.Length)]);
            }
            return rs.ToString();
        }
        public void reName()
        {
            Console.Write("수정할 항목 :");
            int num = Convert.ToInt32(Console.ReadLine());
            if (num == 1)
            {
                Console.WriteLine("-----------------");
                Console.Write("수정할 이름 :");
                string name = Console.ReadLine();
                Console.Write("변경할 이름 :");
                string reName = Console.ReadLine();
                Console.WriteLine("-----------------");
                for (int i = 0; i < addrList.Count; i++)
                {
                    if (addrList[i].Name.Equals(name))
                    {
                        addrList[i].Name = reName;
                       /* addrList[i].Name.Replace(addrList[i].Name, reName);*/
                    }
                }
            }
            else if (num == 2)
            {
                Console.WriteLine("-----------------");
                Console.Write("수정할 전화 :");
                string tel = Console.ReadLine();
                Console.Write("변경할 전화 :");
                string reTel = Console.ReadLine();
                Console.WriteLine("-----------------");
                for (int i = 0; i < addrList.Count; i++)
                {
                    if (addrList[i].Tel.Equals(tel))
                    {
                        addrList[i].Tel = reTel;
                        /* addrList[i].Name.Replace(addrList[i].Name, reName);*/
                    }
                }
            }
            else if (num == 3)
            {
                Console.WriteLine("-----------------");
                Console.Write("수정할 주소 :");
                string address = Console.ReadLine();
                Console.Write("변경할 주소 :");
                string reAddress = Console.ReadLine();
                Console.WriteLine("-----------------");
                for (int i = 0; i < addrList.Count; i++)
                {
                    if (addrList[i].Adress.Equals(address))
                    {
                        addrList[i].Adress = reAddress;
                        /* addrList[i].Name.Replace(addrList[i].Name, reName);*/
                    }
                }
            }
            else if (num == 4)
            {
                Console.WriteLine("-----------------");
                Console.Write("수정할 이메일 :");
                string email = Console.ReadLine();
                Console.Write("변경할 이메일 :");
                string reEmail = Console.ReadLine();
                Console.WriteLine("-----------------");
                for (int i = 0; i < addrList.Count; i++)
                {
                    if (addrList[i].Email.Equals(email))
                    {
                        addrList[i].Email = reEmail;
                        /* addrList[i].Name.Replace(addrList[i].Name, reName);*/
                    }
                }
            }
        }
    }
}
