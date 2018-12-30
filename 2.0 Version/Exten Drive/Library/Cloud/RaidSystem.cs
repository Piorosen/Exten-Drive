using Library.File;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Library.Cloud
{
    class RaidSystem
    {
        #region Private
        #region Variable
        /// <summary>
        /// List[DriveID] = Drive; 와 같이 되어있습니다.
        /// </summary>
        private Hashtable List = new Hashtable();



        #endregion
        #region Fucntion

        /// <summary>
        /// GetAccountList 에서 계정정보들을 다시 다 읽을때 발생합니다.
        /// </summary>
        private void Clear()
        {
            List.Clear();
            Capacity = null;
            CapacityUse = null;
        }

        #endregion
        #endregion


        #region Public
        #region Variable
        /// <summary>
        /// DriveID와 같은 HardID입니다.
        /// </summary>
        public string HardID { get; private set; }

        /// <summary>
        /// 해당 하드의 전체 용량을 나타냅니다.
        /// </summary>
        public BigInteger? Capacity = 0;
        /// <summary>
        /// 해당 하드의 사용한 용량을 나타냅니다.
        /// </summary>
        public BigInteger? CapacityUse = 0;
        /// <summary>
        /// 해당 하드의 쓰레기통에 있는 용량을 나타냅니다.
        /// </summary>
        public BigInteger? CapacityTrash = 0;

        #endregion

        #region Fucntion

        public Hashtable GetAccount() 
        {
            return List;
        }

        public void CreateHard(String ID, List<String> HID)
        {
            new DriveReader(Global.DriveHard).Write(HID, ID);
#if DEBUG
            Log.FileWrite("RaidSystem : CreateHard : OK", Error.Success);
#endif
        }

        public void RemoveHard()
        {
            new FileInfo(Global.DriveHard + HardID).Delete();
#if DEBUG
            Log.FileWrite("RaidSystem : RemoveHard : OK", Error.Success);
#endif
        }

        public void RenameHard(string ID)
        {
            new FileInfo(Global.DriveHard + HardID).MoveTo(Global.DriveHard + ID);
            HardID = ID;
#if DEBUG
            Log.FileWrite("RaidSystem : RenameHard : OK", Error.Success);
#endif
        }

        /// <summary>
        /// RaidSystem을 초기화 하고, HardID를 설정합니다.
        /// </summary>
        /// <param name="HardID">DriveID와 같은 고유의 이름을 설정합니다. (외부에 보여집니다.)</param>
        public RaidSystem(string HardID)
        {
            this.HardID = HardID;
            GetAccountList();
#if DEBUG
            Log.FileWrite("RaidSystem : RaidSystem : OK", Error.Success);
#endif
        }

        /// <summary>
        /// 모든 드라이브 정보를 가져옵니다.
        /// </summary>
        /// <returns>프로그램이 잘작동되었나의 에러코드를 반환합니다</returns>
        public Error GetAccountList()
        {
            Clear();

            Hashtable list = new File.DriveReader(Global.DriveHard).Read(HardID);
            if (list != null)
            {
                foreach (object obj in list.Keys)
                {
                    if (list[obj].ToString() == Global.Cloud.GoogleDrive)
                    {
                        GoogleDrive Gd = new GoogleDrive(obj.ToString());
                        List[obj] = Gd;
                    }
                    /*
                    else if (list[obj].ToString() == Global.NaverCloud)
                    {
                        NaverCloud Nc = new NaverCloud(obj.ToString());
                        List[obj] = Nc;
                    }
                    */
                }
            }
            CapacityUpdate();
#if DEBUG
            Log.FileWrite("RaidSystem : GetAccount : OK", Error.Success);
#endif
            return Error.Success;
        }

        /// <summary>
        /// 원하는 계정을 언로드 합니다.
        /// </summary>
        /// <param name="ID">DriveID를 전달받습니다.</param>
        public void DelAccount(String ID)
        {
            List.Remove(ID);
            new File.DriveReader(Global.DriveHard).AccountWrite(List, HardID);
#if DEBUG
            Log.FileWrite("RaidSystem : DelAccount : OK", Error.Success);
#endif
        }

        /// <summary>
        /// 원하는 계정을 추가, 로드를 합니다.
        /// </summary>
        /// <param name="ID">DriveID를 전달받습니다.</param>
        /// <param name="Cloud">어떤 클라우드 인지 전달을 받습니다. Global.Cloud</param>
        /// <param name="AccoID">나중에 필요할 계정의 아이디와 비밀번호입니다.</param>
        /// <param name="AccoPW">나중에 필요할 계정의 아이디와 비밀번호입니다.</param>
        public void AddAccount(String ID, string Cloud, String AccoID = "", String AccoPW = "")
        {
            if (Cloud == Global.Cloud.GoogleDrive)
            {
                this.List[ID] = new GoogleDrive(ID);
            }
            else
            {
            //   this.List[ID] = new NaverCloud(ID, AccoID, AccoPW);
            }
            CapacityUpdate();
            new File.DriveReader(Global.DriveHard).AccountWrite(List, HardID);
#if DEBUG
            Log.FileWrite("RaidSystem : AddAccount : OK", Error.Success);
#endif
        }

        /// <summary>
        /// 파일을 업로드를 하거나 파일이 변경점이 생겼을때 용량을 체크합니다.
        /// </summary>
        private void CapacityUpdate()
        {
            Capacity = 0;
            CapacityUse = 0;
            CapacityTrash = 0;
            foreach (Drive d in List.Values)
            {
                Capacity += d.Capacity;
                CapacityUse += d.CapacityUse;
                CapacityTrash += d.CapacityTrash;
            }
#if DEBUG
            Log.FileWrite("RaidSystem : CapacityUpdate : OK", Error.Success);
#endif
        }

        /// <summary>
        /// 특정 클라우드의 파일목록만을 읽어 옵니다.
        /// </summary>
        /// <param name="Path">어떤 경로를 읽을 것인지 정보를 전달합니다.</param>
        /// <param name="DriveID">어떤 클라우드를 읽읅것인지 정보를 전달합니다.</param>
        /// <returns>읽어들인 파일 목록을 반환합니다.</returns>
        public List<CloudFile> GetFile(string Path, string DriveID)
        {
            foreach (Drive d in List.Values)
            {
                if (d.DriveID == DriveID)
                {
                    return d.GetFile(Path);
                }
            }
#if DEBUG
            Log.FileWrite("RaidSystem : GetFile : 특정 클라우드 파일목록만 읽음", Error.Success);
#endif
            return null;
        }

        /// <summary>
        /// 모든 클라우드의 파일목록을 읽어 옵니다.
        /// </summary>
        /// <param name="Path">어떤 경로를 읽을 것인지 정보를 전달합니다.</param>
        /// <returns>읽어들인 파일 목록을 반환합니다.</returns>
        public List<CloudFile> GetFiles(string Path)
        {
            List<CloudFile> lists = new List<CloudFile>();
            foreach (Drive d in List.Values)
            {
                var list = d.GetFile(Path);
                if (list != null)
                {
                    lists.AddRange(list);
                }
            }
#if DEBUG
            Log.FileWrite("RaidSystem : GetFiles : 모든 클라우드 파일목록만 읽음", Error.Success);
#endif
            return lists;
        }

        /// <summary>
        /// 해당 파일 정보를 전달받고 다운로드를 실행합니다.
        /// </summary>
        /// <param name="File">다운로드할 파일입니다.</param>
        /// <returns></returns>
        public Error Download(CloudFile File, string DownloadPath)
        {
            (List[File.DriveID] as Drive).Download(File, DownloadPath);
#if DEBUG
            Log.FileWrite("RaidSystem : Download : OK", Error.Success);
#endif
            return Error.Success;
        }
        
        /// <summary>
        /// 파일을 업로드 합니다.
        /// </summary>
        /// <param name="path">실제 하드에 있는 파일의 경로입니다.</param>
        /// <param name="upload">업로드할 클라우드의 경로입니다.</param>
        /// <returns></returns>
        public Error Upload(string path, string upload)
        {
            try
            {
                FileInfo fi = new FileInfo(path);
                foreach (Drive drive in List.Values)
                {
                    if (drive.Capacity - drive.CapacityUse > fi.Length)
                    {
                        Console.WriteLine("업로드하는중!");
                        drive.Upload(fi.FullName, upload);
                        break;
                    }
                }
#if DEBUG
                Log.FileWrite("RaidSystem : Upload : OK", Error.Success);
#endif
                CapacityUpdate();
                return Error.Success;
            }
            catch (Exception e)
            {
#if DEBUG
                Log.FileWrite("RaidSystem : Download : " + e.ToString(), Error.Success);
#endif
                return Error.Success;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
        public Error FolderCreate(string Path)
        {
            foreach (Drive drive in List.Values)
            {
                drive.FolderCreate(Path.TrimEnd('\\'));
#if DEBUG
                Log.FileWrite("RaidSystem : FolderCreate : OK", Error.Success);
#endif
                break;
            }
            
            return Error.Success;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        public string ShareFile(CloudFile resource)
        {
            return (List[resource.DriveID] as Drive).ShareFile(resource); ;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="prevName"></param>
        /// <param name="nextName"></param>
        /// <returns></returns>
        public Error ReName(CloudFile prevName, string nextName, string Path)
        {
            (List[prevName.DriveID] as Drive).ReName(prevName, nextName, Path);
#if DEBUG
            Log.FileWrite("RaidSystem : ReName : OK", Error.Success);
#endif
            return Error.Success;
        }


        public Error Move(List<CloudFile> prevFile, string Path, string prevPath)
        {
            foreach (var v in prevFile)
            {
                (this.List[v.DriveID] as Drive).Move(v, Path.TrimEnd('\\'), prevPath.TrimEnd('\\'));
            }
#if DEBUG
            Log.FileWrite("RaidSystem : Move : OK", Error.Success);
#endif
            return Error.Success;
        }


        public Error Delete(List<CloudFile> prevFile, string Path)
        {
            foreach (var v in prevFile)
            {
                (this.List[v.DriveID] as Drive).Delete(v, Path.TrimEnd('\\'));
            }
#if DEBUG
            Log.FileWrite("RaidSystem : Delete : OK", Error.Success);
#endif
            CapacityUpdate();
            return Error.Success;
        }

        public Error Copy(List<CloudFile> prevFile, string path)
        {
            foreach (var v in prevFile)
            {
                (this.List[v.DriveID] as Drive).Copy(v, path);
            }
#if DEBUG
            Log.FileWrite("RaidSystem : Copy : OK", Error.Success);
#endif
            CapacityUpdate();
            return Error.Success;
        }


        #endregion
        #endregion

    }
}
