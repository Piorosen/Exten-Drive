using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public enum TypeFile
    {
        Folder, UnknownFile, Drive
    }

    static class Global
    {
        

        public static class Cloud
        {
            public readonly static string GoogleDrive = "GoogleDrive";
            public readonly static string DropBox = "DropBox";
            public readonly static string OneDrive = "OneDrive";
        }
        public readonly static string LogName = DateTime.UtcNow.Ticks.ToString();
        /// <summary>
        /// 프로그램의 데이터 처리 장소 입니다.
        /// </summary>
        public readonly static String ProgramPath = Environment.GetFolderPath(
                Environment.SpecialFolder.Personal) + @"\Exten Drive\";

        /// <summary>
        /// 연결하는 클라우드의 폴더 목록이 저장되어 있습니다. (파일명은 DriveID입니다.)
        /// </summary>
        public readonly static String DriveAccount = ProgramPath + @"Drive\Account\";
        /// <summary>
        /// 서로 합쳐질 DriveID의 집합입니다. 그 외엔 없습니다.
        /// </summary>
        public readonly static String DriveHard = ProgramPath + @"Drive\Hard\";
        /// <summary>
        /// GoogleDrive나 OneDrive, DropBox와 같이 Authority 인증키들의 모임입니다.
        /// </summary>
        public readonly static String DriveAuth = ProgramPath + @"Drive\Auth\";
        /// <summary>
        /// 클라우드의 모든 폴더에 있는 파일 목록을 저장되어있습니다. 정확하겐 File\Account_Name\dnj32.wnq
        /// </summary>
        public readonly static string DriveFile = ProgramPath + @"Drive\File\";

        /// <summary>
        /// 프로그램의 전체적인 옵션을 담당합니다.
        /// </summary>
        public readonly static string DriveOption = ProgramPath + @"Drive\Option\";

        public readonly static string Total = "Total";
        public readonly static string Use = "Use";
        public readonly static string Trash = "Trash";


        public static readonly string GoogleMimeTypeFolder = "application/vnd.google-apps.folder";



        public readonly static string ApplicationName = "Exten Drive";


    }
}
