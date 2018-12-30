using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v2;
using Google.Apis.Drive.v2.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Library.File;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Library.Cloud
{
    class GoogleDrive : Drive
    {
        /*
         
            수정해야하는 사항 : 
            FoldList 에서 파일 업로드, 파일 삭제 했을때 Capacity 값 변경 요청해야함.
            -> 현재 Capcity, 파일, 폴더 변경이 일어날 경우 함수만 적어주면됨. 


            그리고 파일 업로드거나 파일을 삭제 하였으면 Global.File 에서도 값을 변경해주어야함.
            
        */

        #region Private
        #region Variable

        private DriveService Service = null;

        /// <summary>
        /// 폴더의 이름을 정의 합니다. : 암호화 된 폴더의 이름 <-> 실제의 이름
        /// </summary>
        private Hashtable Fold_List = new Hashtable();
        /// <summary>
        /// Rand_List, 랜덤된 파일 이름이 있습니다. ex) File_List[Path] = CloudDrive
        /// </summary>
        private Hashtable File_List = new Hashtable();

        /// <summary>
        /// 클라우드의 첫 부분의 폴더입니다. (ex. C:\ )
        /// </summary>
        private string RootID = null;

        #endregion
        #region Function
        /// <summary>
        /// 구글 드라이브를 할당받고 해당 드라이브의 접근권한을 얻습니다.
        /// </summary>
        /// <returns>프로그램이 잘 실행이 되었는지의 유무의 에러코드입니다.</returns>
        private Error DriveLoad()
        {

            // 구글 드라이브의 정보를 읽어 드리기 위해서 파일이름을 변경을합니다.
            

            const string DRIVE_API_NAME = "Google.Apis.Auth.OAuth2.Responses.TokenResponse-user";
            FileInfo fi = new FileInfo(Global.DriveAuth + DriveID);
            FileInfo del = new FileInfo(Global.DriveAuth + DRIVE_API_NAME);

            if (fi.Exists)
            {
                if (del.Exists) del.Delete();
                fi.MoveTo(Global.DriveAuth + DRIVE_API_NAME);
            }

            // 파일 이름이 변경된 후 구글드라이브의 접근권한을 가져옵니다.
            try
            {
                string[] Scopes = { DriveService.Scope.Drive };

                var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                       new ClientSecrets { ClientSecret = "lnpQNjBoJUTUm9iWt5EjT6oL", ClientId = "1096367866633-m0pur24et1j3e39vnmii2i8bs7o8vic6.apps.googleusercontent.com" },
                       Scopes,
                       "user",
                        CancellationToken.None,
                       new FileDataStore(Global.DriveAuth, true)).Result;

                Service = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = Global.ApplicationName,
                });
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            FileInfo fb = new FileInfo(Global.DriveAuth + DRIVE_API_NAME);
            // 파일을 다 사용한뒤 파일 이름을 다시 복구시킵니다.
            if (fb.Exists)
            {
                fb.MoveTo(Global.DriveAuth + DriveID);
            }
#if DEBUG
            Log.FileWrite("GoogleDrive : GoogleLoad : OK", Error.Success);
#endif
            return Error.Success;
        }

        /// <summary>
        /// 드라이브의 접근권한을 얻은 뒤, 해당 드라이브의 모든 파일정보를 가져옵니다.
        /// </summary>
        /// <returns>프로그램이 잘 실행이 되었는지의 유무의 에러코드입니다.</returns>
        private Error DriveFileLoad()
        {

            if (new FileInfo(Global.DriveAccount + DriveID).Exists && new FileInfo(Global.DriveFile + DriveID).Exists)
            {
                Fold_List = new DriveReader(Global.DriveAccount).Read(DriveID);
                File_List = new DriveReader(Global.DriveFile).Read(DriveID);
                Capacity = long.Parse(Fold_List[Global.Total].ToString());
                CapacityUse = long.Parse(Fold_List[Global.Use].ToString());
#if DEBUG
                Log.FileWrite("GoogleDrive : DriveFileLoad : 이미저장된거 불러오기", Error.Success);
#endif
                return Error.Success;
            }
            var info = Service.About.Get().Execute();

            Fold_List[Global.Total] = Capacity = info.QuotaBytesTotal;
            Fold_List[Global.Use] = CapacityUse = info.QuotaBytesUsed;
            Fold_List[Global.Trash] = CapacityTrash = info.QuotaBytesUsedInTrash;


            RootID = info.RootFolderId;
            GetFFList();
            FolderUpdate();
#if DEBUG
            Log.FileWrite("GoogleDrive : DriveFileLoad : 새롭게 불러오기", Error.Success);
#endif
            return Error.Success;
        }

        /// <summary>
        /// Get File, Folder List ( 모든 파일, 폴더 리스트를 읽습니다. (웹에서 모든 정보를 읽으므로 느립니다.)
        /// </summary>
        /// <param name="path">개발자가 만든 루트 폴더 입니다.</param>
        /// <param name="ID">구글드라이브에 내부적으로 처리될 ID입니다.</param>
        private void GetFFList(string path = "Root", string ID = "Root")
        {
            // DriveFile의 폴더를 체크합니다.
            DirectoryInfo di = new DirectoryInfo(Global.DriveFile);
            if (di.Exists == false)
            {
                di.Create();
            }

                di = new DirectoryInfo(Global.DriveFile + DriveID + @"^List\");
            if (di.Exists == false)
            {
                di.Create();
            }
            // Path가 Root인 경우 기초적인 데이터를 다운로드 합니다.
            string FolderID = ID;
            if (path == "Root")
            {
                Fold_List[path] = RootID;
                FolderID = RootID;
                String k = Path.GetRandomFileName();
                File_List[path] = k;
                StreamWriter sw = new StreamWriter(Global.DriveFile + @"\" + DriveID
                        , true, System.Text.Encoding.Default);
                sw.WriteLine(path + "=" + k);
                sw.Close();
            }
            
            // List를 받을 준비를 합니다. (단. 최대 읽는 파일수는 1000개 입니다.)
            FilesResource.ListRequest list = Service.Files.List();
            list.Q = "'" + FolderID + "' in parents";
            list.MaxResults = 1000;
            
            // 웹에서 다운로드를 합니다.
            var Files = new List<Google.Apis.Drive.v2.Data.File>(list.Execute().Items);

            // 재귀함수를 재생시킵니다.
            for (int i = 0; i < Files.Count; i++)
            {
                var FileName = Path.GetRandomFileName();
                CloudFile a = new CloudFile(Files[i], DriveID);
                StreamWriter sw;
                if (a.MimeType == Global.GoogleMimeTypeFolder)
                {
                    // Root\AA=Aikwe.Aiqp 가 저장되는곳.
                    sw = new StreamWriter(Global.DriveFile + @"\" + DriveID
                        , true);
                    sw.WriteLine(path + @"\" + a.Title + "=" + FileName);

                    sw.Close();
                    File_List[path + @"\" + a.Title] = FileName;
                    Fold_List[path + @"\" + a.Title] = a.Id;
                    GetFFList(path + @"\" + a.Title, a.Id);
                }
                // 파일명이 Aikwe.Aiqp, 파일 내용 안에 드라이브 파일 정보가 저장됨.
                sw = new StreamWriter(Global.DriveFile + @"\" + DriveID + @"^List\" +
                    File_List[path], true);
                sw.WriteLine(a.Title + "=" + a.ToString());
                sw.Close();
            }
#if DEBUG
            Log.FileWrite("GoogleDrive : GetFFList : OK", Error.Success);
#endif
            return;
        }

        /// <summary>
        /// 폴더의 값이 변하였을 때 폴더 업데이트 함수를 사용합니다.
        /// </summary>
        private void FolderUpdate()
        {
            // Account에 폴더 목록을 갱신합니다.
            new DriveReader(Global.DriveAccount).Write(Fold_List, DriveID);
            // File에 암호화된 폴더목록을 갱신합니다.
            new DriveReader(Global.DriveFile).Write(File_List, DriveID);
#if DEBUG
            Log.FileWrite("GoogleDrive : FolderUpdate : OK", Error.Success);
#endif
        }

        /// <summary>
        /// 폴더의 값이 변하였을 때 폴더 업데이트 함수를 사용합니다.
        /// </summary>
        /// <param name="files">이때 파일은 전체의 파일을 받아야합니다. 그 외에 변화량만 적을경우에는 그 변화량만 기입됩니다.</param>
        /// <param name="path">작성할 주소를 적어야합니다.</param>
        /// <param name="chk"> YES : 변화량 , NO : 전부다 입력</param>
        private void FileUpdate(List<CloudFile> files, string path, bool chk = true)
        {
            StreamWriter sw = new StreamWriter(Global.DriveFile + @"\" + DriveID + @"^List\" +
                    File_List[path], chk);
            foreach (var file in files)
            {
                sw.WriteLine(file.Title + "=" + file.ToString());
            }
            sw.Close();
#if DEBUG
            Log.FileWrite("GoogleDrive : FileUpdate : OK", Error.Success);
#endif
        }


        /// <summary>
        /// 폴더의 값이 변하였을 때 폴더 업데이트 함수를 사용합니다.
        /// </summary>
        /// <param name="files">이때 파일은 전체의 파일을 받아야합니다. 그 외에 변화량만 적을경우에는 그 변화량만 기입됩니다.</param>
        /// <param name="path">작성할 주소를 적어야합니다.</param>
        private void FileUpdate(CloudFile file, string path)
        {
            StreamWriter sw = new StreamWriter(Global.DriveFile + @"\" + DriveID + @"^List\" +
                    File_List[path], true);
            sw.WriteLine(file.Title + "=" + file.ToString());
            sw.Close();
#if DEBUG
            Log.FileWrite("GoogleDrive : FileUpdate : OK", Error.Success);
#endif
        }
        /// <summary>
        /// 클라우드의 용량을 체크하고, 파일에 작성을합니다.
        /// </summary>
        private void CapacityUpdate()
        {
            var info = Service.About.Get().Execute();
            Fold_List[Global.Use] = CapacityUse = info.QuotaBytesUsed;
            Fold_List[Global.Use] = CapacityUse = info.QuotaBytesUsed;
            Fold_List[Global.Use] = CapacityUse = info.QuotaBytesUsed;

            new DriveReader(Global.DriveAccount).Write(Fold_List, DriveID);
#if DEBUG
            Log.FileWrite("GoogleDrive : CapacityUpdate : OK", Error.Success);
#endif
        }

        private static string GetMimeType(string fileName)
        {
            string mimeType = "application/unknown";
            string ext = System.IO.Path.GetExtension(fileName).ToLower();
            Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
            if (regKey != null && regKey.GetValue("Content Type") != null)
                mimeType = regKey.GetValue("Content Type").ToString();
#if DEBUG
            Log.FileWrite("GoogleDrive : GetMimeType : OK", Error.Success);
#endif
            return mimeType;
        }


        #endregion

        #endregion

        #region Public
        #region Varience
        override public string DriveID { get; protected set;  }
        override public string DriveName { get; protected set; }
        override public long? Capacity { get; protected set; }
        override public long? CapacityUse { get; protected set; }
        override public long? CapacityTrash { get; protected set; }
        #endregion

        #region Function
        /// <summary>
        /// 프로그램 처음 실행 하였을 때 초기화 합니다. 초기화란 해당 클라우드의 정보를 모두 가져오는것입니다.
        /// </summary>
        /// <param name="DriveID">드라이브를 인식할 고유 이름을 받습니다.</param>
        public GoogleDrive(string DriveID)
        {
            this.DriveID = DriveID;
            this.DriveName = Global.Cloud.GoogleDrive;
            DriveLoad();
            DriveFileLoad();
#if DEBUG
            Log.FileWrite("GoogleDrive : GoogleDrive : OK", Error.Success);
#endif
        }

        public override Error IsFile(string path, string name)
        {
            
            return Error.Success;
        }
        public override Error IsFolder(string path)
        {

            return Error.Success;
        }

       
        public override Error Upload(string uploadFile, string path)
        {
            if (System.IO.File.Exists(uploadFile))
            {
                FolderCreate(path);
                string parent = Fold_List[path].ToString();
                Google.Apis.Drive.v2.Data.File body = new Google.Apis.Drive.v2.Data.File();
                body.Title = System.IO.Path.GetFileName(uploadFile);
                body.Description = "File uploaded by Exten Drive";
                body.MimeType = GetMimeType(uploadFile);
                body.Parents = new List<ParentReference>() { new ParentReference() { Id = parent } };

                // File's content.
                byte[] byteArray = System.IO.File.ReadAllBytes(uploadFile);
                System.IO.MemoryStream stream = new System.IO.MemoryStream(byteArray);
                try
                {
                    FilesResource.InsertMediaUpload request = Service.Files.Insert(body, stream, GetMimeType(uploadFile));
                    request.Upload();
                    CloudFile cf = new CloudFile(request.ResponseBody, DriveID);
                    
                    FileUpdate(cf, path);
                    CapacityUpdate();
#if DEBUG
                    Log.FileWrite("GoogleDrive : Upload : OK", Error.Success);
#endif
                    return Error.Success;
                }
                catch (Exception e)
                {
#if DEBUG
                    Log.FileWrite("GoogleDrive : Upload : " + e.ToString(), Error.Success);
#endif
                    return Error.Error;
                }
            }
            else
            {
#if DEBUG
                Log.FileWrite("GoogleDrive : Upload : IOEXCEPTION", Error.Success);
#endif
                return Error.IOException;
            }
        }
        
        /// <summary>
        /// 파일을 다운로드하는 시스템입니다.
        /// </summary>
        /// <param name="resource">파일을 읽거나, 정보, 해당 파일의 모든정보를 담는 변수입니다.</param>
        /// <param name="DownloadPath">다운로드할 하드 경로를 작성을 합니다. 안 할경우에는 프로그램의 실행경로의 \Download\ 에 저장됩니다.</param>
        /// <returns>프로그램이 잘 실행이 되었는지의 유무의 에러코드입니다.</returns>
        public override Error Download(CloudFile resource, string DownloadPath = null)
        {
            // 전달 받은 resource가 빈 경우에는 다운로드를 하지 않습니다.
            if (!string.IsNullOrEmpty(resource.DownloadUrl))
            {
                try
                {   
                    if (DownloadPath == null)
                    {
                        DownloadPath = Directory.GetCurrentDirectory() + "\\Download\\" + resource.Title;
                    }
                    DownloadPath += @"\" + resource.Title;

                    var x = Service.HttpClient.GetByteArrayAsync(resource.DownloadUrl);
                    byte[] arrBytes = x.Result;

                    System.IO.File.WriteAllBytes(DownloadPath, arrBytes);
                }
                catch (Exception e)
                {
#if DEBUG
                    Log.FileWrite("GoogleDrive : Download : " + e.Message, Error.IOException);
#endif
                    return Error.IOException;
                }
            }else
            {
#if DEBUG
                Log.FileWrite("GoogleDrive : Download : resource가 비어져 있습니다.", Error.IOException);
#endif
                return Error.Error;
            }
#if DEBUG
            Log.FileWrite("GoogleDrive : Download : OK", Error.Success);
#endif
            return Error.Success;
        }

        /// <summary>
        /// RaidHard에서 쓰이는 파일목록을 읽을때 쓰입니다.
        /// </summary>
        /// <param name="Path">Root\~\로 시작하는 폴더 목록입니다.</param>
        /// <returns>파일정보를 넘겨줍니다.</returns>
        public override List<CloudFile> GetFile(string Path)
        {
            if (!Fold_List.ContainsKey(Path)) return null;
            List<CloudFile> listG = new List<CloudFile>();
            Hashtable h = new Hashtable();
            h = new Library.File.DriveReader(Global.DriveFile).Read(DriveID + @"^List\" + File_List[Path]);
            if (h == null)
            {
#if DEBUG
                Log.FileWrite("GoogleDrive : GetFile : h == null", Error.None);
#endif
                return null;
            }
            foreach (var k in h.Values)
            {
                var g = new CloudFile(k.ToString());
                listG.Add(g);
            }
#if DEBUG
            Log.FileWrite("GoogleDrive : GetFile : h != null", Error.None);
#endif
            return listG;
        }


        /// <summary>
        /// 폴더를 새롭게 만듭니다.
        /// </summary>
        /// <param name="Path">Root\~\Name 폴더를 생성할 주소입니다.</param>
        /// <returns>프로그램이 잘 실행이 되었는지의 유무의 에러코드입니다.</returns>
        public override Error FolderCreate(string m_Path)
        {
            // m_Path의 값을 \로 전부다 분할한뒤 루프를 돌려 파일이 존재하지않으면 생성합니다.
            string[] parent = m_Path.Split('\\');

            // 프로그램은 Root라는 개발자의 임의 메인 폴더입니다.
            string p = @"Root";

            try
            {
                // \가 분할 된 만큼의 루프를 진행합니다.
                for (int i = 0; i < parent.Length - 1; i++)
                {
                    // 해당 파일이 존재 유무를 체크합니다.
                    bool Exsis = false;

                    // 폴더의 모든 파일을 읽고, 루프를 돌려 그 중에서 원하는 값이 있는지를 체크합니다
                    // 나름 속도면이나 확장성이 넓어지면 문제점이 발생할것이라 생각이 듭니다.
                    var file = GetFile(p);

                    if (file != null)
                    {
                        foreach (var a in file)
                        {
                            if (a.MimeType == Global.GoogleMimeTypeFolder)
                            {
                                if (a.Title == parent[i + 1])
                                {
                                    Exsis = true;
                                }
                            }
                        }
                    }

                    // 위의 루프를 돌려 파일에 없다면은 폴더를 생성합니다.
                    if (Exsis == false)
                    {
                        var fileMetadata = new Google.Apis.Drive.v2.Data.File();
                        fileMetadata.Title = parent[i + 1];
                        fileMetadata.MimeType = Global.GoogleMimeTypeFolder;
                        fileMetadata.Parents = new List<ParentReference>() { new ParentReference() { Id = Fold_List[p].ToString() } };
                        var request = Service.Files.Insert(fileMetadata);
                        var a = request.Execute();

                        // 폴더 리스트를 갱신을 하고, 폴더를 업데이트를 합니다.
                        Fold_List[(p + @"\" + parent[i + 1])] = a.Id;
                        File_List[(p + @"\" + parent[i + 1])] = Path.GetRandomFileName();

                        StreamWriter sw = new StreamWriter(Global.DriveFile + @"\" + DriveID + @"^List\" +
                            File_List[p], true);
                        sw.WriteLine(a.Title + "=" + new CloudFile(a, DriveID).ToString());
                        sw.Close();

                        FolderUpdate();
#if DEBUG
                        Log.FileWrite("GoogleDrive : FolderCreate : " + (p + @"\" + parent[i + 1]), Error.Success);
#endif
                    }
                    // 폴더를 생성을 하고 다음으로 진행합니다.
                    p += @"\" + parent[i + 1];
                }
            }
            // 만약에 업로드 실패나 또는, 파일에 접근할 권한이 없을 경우에는 에러를 받고, 로그를 작성을 합니다.
            catch (Exception e) {
#if DEBUG
                Log.FileWrite("GoogleDrive : FolderCreate : " + e.Message, Error.Error);
#endif
                return Error.Error;
            }
#if DEBUG
            Log.FileWrite("GoogleDrive : FolderCreate : OK", Error.Success);
#endif
            return Error.Success;
        }


        /// <summary>
        /// 공유할 파일의 주소를 공유합니다.
        /// </summary>
        /// <param name="resource">파일정보를 넘깁니다.</param>
        /// <returns>파일정보에서 파일공유주소를 리턴합니다., 클립보드에 복사됩니다.</returns>
        public override string ShareFile(CloudFile resource)
        {
            /* 못하겠음.
            var v = Service.Files.Get(resource.Id).Execute();
            Permission p = new Permission();
            p.Role = "reader";
            p.Type = "anyone";
           
            p.WithLink = true;
            v.Shared = true;
            v.Capabilities.CanShare = true;
            v.Shareable = true;
            v.Permissions = new List<Permission>() { p };
            Service.Files.Patch(v, v.Id);
            v = Service.Files.Get(resource.Id).Execute();
            // 클립보드에 복사를 하고 값을 리턴을 합니다.
            Clipboard.SetText(v.WebViewLink); */
            return null;
           
        }


        /// <summary>
        /// 폴더나 파일의 이름을 변경합니다. 동시에 여러개도 되며, 이름순은 파일의 갯수가 2개일경우 01 02 , 3개 001 순입니다.
        /// </summary>
        /// <param name="prevName">이전의 사용되던 파일의 목록입니다.</param>
        /// <param name="nextName">새롭게 바뀔 파일들의 이름 목록입니다.</param>
        /// <returns>프로그램이 잘 실행이 되었는지의 유무의 에러코드입니다.</returns>
        public override Error ReName(CloudFile prevName, string nextName, string Path)
        {
            Path = Path.TrimEnd('\\');

            try
            {
                if (prevName.MimeType == Global.GoogleMimeTypeFolder  && GetFile(Path + "\\" + nextName) == null )
                {
                    if (Fold_List.ContainsKey(Path + "\\" + nextName) == true)
                    {
                        string str = System.IO.Path.GetRandomFileName();
                        FileInfo fi = new FileInfo(Global.DriveFile + DriveID + @"^List\" + str);
                        Fold_List[Path + "\\" + nextName] = prevName.Id;
                        File_List[Path + "\\" + nextName] = str;
                        fi.Create();
                       
                    }
                    else
                    {
                        Console.WriteLine("ReName : 이미 해당 폴더가 있음 무시함.");
                        return Error.Error;
                    }

                    Fold_List[Path + "\\" + nextName] = prevName.Id;
                    Fold_List.Remove(Path + "\\" + prevName.Title);
                }
                else
                {
                    Console.WriteLine("ReName : 폴더 안에 자료가 들어가있음.");
                    return Error.Bug;
                }

                // 루프를 돌려서 모든 파일의 이름을 변경을 합니다.

                Google.Apis.Drive.v2.Data.File file = new Google.Apis.Drive.v2.Data.File();

                file.Title = nextName;
                var q = Service.Files.Patch(file, prevName.Id).ExecuteAsync();

                var list = GetFile(Path);

                if (list == null)
                {
                    list = new List<CloudFile>();
                }

                foreach (var v in list)
                {
                    if (prevName.Id == v.Id)
                    {
                        list.Remove(v);
                        break;
                    }
                }
                
                prevName.Title = nextName;
                prevName.FileName = nextName;

                list.Add(prevName);
                FolderUpdate();
                FileUpdate(list, Path.TrimEnd('\\'), false);
#if DEBUG
                Log.FileWrite("GoogleDrive : Move : OK", Error.Success);
#endif

            }
            catch (Exception)
            {
                return Error.Error;
            }
            return Error.Success;
        }


        /// <summary>
        /// 폴더나 파일을 단체로 옮길때 사용됩니다.
        /// </summary>
        /// <param name="prevFile">이전의 파일값입니다.</param>
        /// <param name="Path">단체로 어디로 이동할 경로의 값입니다.</param>
        /// <returns>프로그램이 잘 실행이 되었는지의 유무의 에러코드입니다.</returns>
        public override Error Move(CloudFile prevFile, string Path, string prevPath)
        {
            FolderCreate(Path);
            if (prevFile.MimeType == Global.GoogleMimeTypeFolder)
            {
                MessageBox.Show("폴더는 이동이 불가능합니다.");
                return Error.Error;
                /*
                string tmp = Path + '\\' + prevFile.Title;
                if (GetFile(prevPath + "\\" + prevFile.Title) == null)
                {
                    if (Fold_List.ContainsKey(tmp) == false)
                    {
                        string str = System.IO.Path.GetRandomFileName();
                        FileInfo fi = new FileInfo(Global.DriveFile + DriveID + @"^List\" + str);
                        Fold_List[tmp] = prevFile.Id;
                        File_List[tmp] = str;
                        fi.Create();
                    }
                    else
                    {
                        MessageBox.Show("Move : 이미 해당 폴더가 있음.");
                        Console.WriteLine("Move : 이미 해당 폴더가 있음 무시함.");
                        return Error.Error;
                    }
                }
                else
                {

                    MessageBox.Show("Move : 안에 자료가 비어있지 않음.");
                    Console.WriteLine("Move : 안에 자료가 비어 있지않음");
                    return Error.Bug;
                }

                Fold_List[tmp] = prevFile.Id;
                Fold_List.Remove(prevPath + '\\' + prevFile.Title);
                */
            }
            

            Google.Apis.Drive.v2.Data.File file = new Google.Apis.Drive.v2.Data.File();

            List<ParentReference> lpr = new List<ParentReference>();
            ParentReference pr = new ParentReference();
            pr.Id = Fold_List[Path].ToString();

            lpr.Add(pr);

            file.Parents = lpr;

            Service.Files.Copy(file, prevFile.Id).Execute();
            Service.Files.Delete(prevFile.Id).ExecuteAsync();

            var list = GetFile(Path);
            var nlist = GetFile(prevPath);

            if (list == null)
            {
                list = new List<CloudFile>();
            }

            if (nlist == null)
            {
                nlist = new List<CloudFile>();
            }

            list.Add(prevFile);
            foreach (var n in nlist)
            {
                if (n.Id == prevFile.Id)
                {
                    nlist.Remove(n);
                    break;
                }
            }

            FileUpdate(list, Path, false);
            FileUpdate(nlist, prevPath, false);

            FolderUpdate();
#if DEBUG
            Log.FileWrite("GoogleDrive : Move : OK", Error.Success);
#endif
            return Error.Success;
        }

        /// <summary>
        /// 파일이나 폴더를 삭제를 합니다.
        /// </summary>
        /// <param name="prevFile">파일의 목록을 받습니다.</param>
        /// <returns>프로그램이 잘 실행이 되었는지의 유무의 에러코드입니다.</returns>
        public override Error Delete(CloudFile prevFile, string Path)
        {
            var list = GetFile(Path);

            foreach (var n in list)
            {
                if (n.Id == prevFile.Id)
                {
                    list.Remove(n);
                    break;
                }
            }
            Service.Files.Delete(prevFile.Id).ExecuteAsync();
            CapacityUpdate();
            FileUpdate(list, Path, false);
            return Error.Success;
        }


        /// <summary>
        /// 파일이나 폴더를 복사를 합니다.
        /// </summary>
        /// <param name="prevFile">복사할 파일의 원본을 받습니다.</param>
        /// <param name="CopyName">복사할 파일의 이름을 받고, 이름을 지정하지 않으면은 이전이름으로 됩니다.</param>
        /// <returns>프로그램이 잘 실행이 되었는지의 유무의 에러코드입니다.</returns>
        public override Error Copy(CloudFile prevFile, string path, string CopyName = null)
        {
            if (prevFile.MimeType == Global.GoogleMimeTypeFolder /* && GetFile(Path + "\\" + nextName) == null */)
            {
                MessageBox.Show("폴더는 복사가 불가능합니다.");
                return Error.Error;
                /*
                if (Fold_List.ContainsKey(Path + "\\" + nextName) == true)
                {
                    string str = System.IO.Path.GetRandomFileName();
                    FileInfo fi = new FileInfo(Global.DriveFile + DriveID + @"^List\" + str);
                    Fold_List[Path + "\\" + nextName] = prevName.Id;
                    File_List[Path + "\\" + nextName] = str;
                    fi.Create();

                }
                else
                {
                    Console.WriteLine("ReName : 이미 해당 폴더가 있음 무시함.");
                    return Error.Error;
                }

                Fold_List[Path + "\\" + nextName] = prevName.Id;
                Fold_List.Remove(Path + "\\" + prevName.Title);
            }
            else
            {
                Console.WriteLine("ReName : 폴더 안에 자료가 들어가있음.");
                return Error.Bug;
                */
            }

            Google.Apis.Drive.v2.Data.File copiedFile = new Google.Apis.Drive.v2.Data.File();

            List<ParentReference> lpr = new List<ParentReference>();
            ParentReference pr = new ParentReference();
            pr.Id = Fold_List[path].ToString();

            lpr.Add(pr);

            copiedFile.Parents = lpr;
            
            copiedFile.Title = CopyName == null ? prevFile.Title : CopyName;
            
            try
            {

                Service.Files.Copy(copiedFile, prevFile.Id).ExecuteAsync();
                var list = GetFile(path);

                if (list == null)
                {
                    list = new List<CloudFile>();
                }

                list.Add(prevFile);

                FileUpdate(list, path, false);

                FolderUpdate();
                CapacityUpdate();
            }
            catch (Exception e)
            {
#if DEBUG
                Log.FileWrite("GoogleDrive : Copy : " + e.ToString(), Error.Error);
#endif
                return Error.Error;
            }

#if DEBUG
            Log.FileWrite("GoogleDrive : Copy : OK", Error.Error);
#endif
            return Error.Success;
        }
        #endregion

        #endregion
    }
}
