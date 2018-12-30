using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library;
using System.IO.MemoryMappedFiles;
using Exten_Drive.Properties;
using System.Windows.Forms;
using Library.File;
using System.Reflection;
using System.Diagnostics;

namespace Exten_Drive
{

    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
#if DEBUG
            Log.FileWrite("Program : Main : 프로그램이 실행이됨.", Error.Run);
#endif
            try
            {
                //메모리맵 파일이 있다 치고, 오픈 시도
                using (MemoryMappedFile mmf = MemoryMappedFile.OpenExisting(Resources.Auth))
                {
                    //여기에 Win32 API 등을 잘 이용하여 실행되고 있는 프로세스를 맨 앞으로 가져오면 됩니다
#if DEBUG
                    Log.FileWrite("Program : Main : 중복 실행이됨", Error.Over);
#endif
                    MessageBox.Show("이미 실행중 입니다.");
                    return;
                }
            }
            catch (System.IO.FileNotFoundException)
            {
                //FileNotFoundException 예외가 발생하면, 메모리맵 파일이 없는 것이므로, 계속 진행
            }

            //메모리맵 파일을 생성하고, 내 윈폼 실행
            using (MemoryMappedFile mmf = MemoryMappedFile.CreateOrOpen(Resources.Auth, 1))
            {
                // Library.Web.WebServer w = new Library.Web.WebServer();
                // w.CheckVersion();

                //실행
#if DEBUG
                Log.FileWrite("Program : Main : 정상 실행이 시작됨", Error.Run);
#endif
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
        }
    }
}
