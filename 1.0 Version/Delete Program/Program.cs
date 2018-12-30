using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace Delete_Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("훗 이 프로그램은 실행이 안됌 ㅇㅇ");
            try {
                string s = "";
                foreach (string a in args)
                {
                    s += " " + a;
                }
                s.Trim();
                Console.WriteLine(s);
                FileInfo c = new FileInfo(s);
                long i = c.Length;
                if (c.Exists)
                {
                    
                    for (int q = 0; q < 10; q++)
                    {
                        StreamWriter Sw = new StreamWriter(s);
                        int f = 0;
                        for (int k = 0; k < i; k++)
                        {
                            Sw.Write(f);
                        }
                        Sw.Close();
                    }
                    c.Delete();
                    Console.WriteLine("삭제완료!");
                }
            }catch (Exception)
            {
                for (;;) ;
            }
        }
    }
}
