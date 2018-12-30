using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.File
{
    /// <summary>
    /// 드라이브와 관련된 정보들, 파일목록, 계정목록, 하드목록 등 읽는 시스템입니다.
    /// </summary>
    class DriveReader
    {
        private string Path = string.Empty;

        /// <summary>
        /// DriveReader에 필요한 정보를 전해 받습니다. 그 외엔 데이터를 받을만한 함수나 인수는 없습니다.
        /// </summary>
        /// <param name="Path">읽을 파일의 폴더 주소를 전달 받습니다.</param>
        public DriveReader(String Path)
        {
            DirectoryInfo di = new DirectoryInfo(Path);
            if (!di.Exists)
            {
                di.Create();
            }
            this.Path = Path;
#if DEBUG
            Log.FileWrite("DriveReader : DriveReader : OK", Error.Success);
#endif
        }

        /// <summary>
        /// aaa=bbb 로 되어있는 모든파일을 읽을수가 있습니다. Ex) Hash[aaa] = bbb; 로 저장됩니다.
        /// </summary>
        /// <param name="ID">Path + ID가 됩니다. Drive</param>
        /// <returns>HashTable[Data] = FileName</returns>
        public Hashtable Read(String ID)
        {
            StreamReader SR;
            if (!(new FileInfo(Path + ID).Exists))
            {
                return null;
            }
            SR = new StreamReader(Path + ID);

            Hashtable List = new Hashtable();
            while (!SR.EndOfStream)
            {
                string[] Tmp = SR.ReadLine().Split('=');
                for (int i = 2; i < Tmp.Length; i++)
                {
                    Tmp[1] += Tmp[i];
                }
                List[Tmp[0]] = Tmp[1];
            }
            SR.Close();
#if DEBUG
            Log.FileWrite("DriveReader : Read : OK", Error.Success);
#endif
            return List;
        }

        /// <summary>
        ///     
        /// </summary>
        /// <param name="List"></param>
        /// <param name="ID"></param>
        public void AccountWrite(Hashtable List, String ID)
        {
            FileInfo fi = new FileInfo(Path + ID);
            if (fi.Exists)
            {
                fi.Delete();
            }
            StreamWriter SW = new StreamWriter(Path + ID);
            ICollection Collect = List.Keys;
            foreach (object obj in Collect)
            {
                if (((Cloud.Drive)List[obj]).DriveName == Global.Cloud.GoogleDrive)
                    SW.WriteLine(obj.ToString() + "=" + Global.Cloud.GoogleDrive);
                else SW.WriteLine(obj.ToString() + "=" + Global.Cloud.DropBox);
            }
            SW.Close();
#if DEBUG
            Log.FileWrite("DriveReader : AccountWrite : OK", Error.Success);
#endif
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="List"></param>
        /// <param name="ID"></param>
        public void Write(Hashtable List, String ID)
        {
            FileInfo fi = new FileInfo(Path + ID);
            if (fi.Exists)
            {
                fi.Delete();
            }
            StreamWriter SW = new StreamWriter(Path + ID);
            foreach (String obj in List.Keys)
            {
                SW.WriteLine(obj + "=" + List[obj]);
            }
            SW.Close();
#if DEBUG
            Log.FileWrite("DriveReader : Write : OK", Error.Success);
#endif
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="List"></param>
        /// <param name="ID"></param>
        /// <param name="Cloud"></param>
        public void Write(List<String> List, String ID, List<String> Cloud = null)
        {
            FileInfo fi = new FileInfo(Path + ID);
            if (fi.Exists)
            {
                fi.Delete();
            }
            StreamWriter SW = new StreamWriter(Path + ID);
            if (List != null)
            {
                for (int i = 0; i < List.Count; i++)
                {
                    SW.WriteLine(List[i] + "=" + (Cloud == null ? Global.Cloud.GoogleDrive : Cloud[i]));
                }
            }
            SW.Close();
#if DEBUG
            Log.FileWrite("DriveReader : Write : OK", Error.Success);
#endif
        }
    }
}
