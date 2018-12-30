using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v2;
using Google.Apis.Drive.v2.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Server
{
    public class SendData
    {
        public SendData(string ID, string Content)
        {
            this.ID = ID;
            this.Content = Content;
        }
        public string ID = null;
        public string Content = null;
    }

    public delegate void GetData(object sender, SendData data);
    class CloudTCPIP
    {
        public event GetData GetData;

        private void OnGetData(SendData data)
        {
            GetData?.Invoke(this, data);
        }

        DriveService Service = null;
        public string ID { set; get; }
        private string RootID = null;
        BackgroundWorker thread = new BackgroundWorker();

        public CloudTCPIP(string ID)
        {
            this.ID = ID;

            DriveLoad();

            var info = Service.About.Get().Execute();

            RootID = info.RootFolderId;
            thread.DoWork += Receive;
            thread.RunWorkerAsync();
        }

        private void Receive(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                var list = Service.Files.List();
                list.Q = "'" + RootID + "' in parents";
                list.MaxResults = 50;
                var File = list.Execute().Items;

                foreach (var fileName in File)
                {
                    if (fileName.Title.Split('|')[0] == ID)
                    {
                        SendData data = new SendData(fileName.Title.Split('|')[1], fileName.Title.Split('|')[2]);
                        Service.Files.Delete(fileName.Id).Execute();
                        OnGetData(data);
                    }
                }
            }
        }

        /// <summary>
        /// 구글 드라이브를 할당받고 해당 드라이브의 접근권한을 얻습니다.
        /// </summary>
        /// <returns>프로그램이 잘 실행이 되었는지의 유무의 에러코드입니다.</returns>
        private void DriveLoad()
        {
            string Global_DriveAuth = Application.StartupPath + "\\";
            
            // 구글 드라이브의 정보를 읽어 드리기 위해서 파일이름을 변경을합니다.

            const string DRIVE_API_NAME = "Google.Apis.Auth.OAuth2.Responses.TokenResponse-user";
            FileInfo fi = new FileInfo(Global_DriveAuth + ID);
            FileInfo del = new FileInfo(Global_DriveAuth + DRIVE_API_NAME);

            if (fi.Exists)
            {
                if (del.Exists) del.Delete();
                fi.MoveTo(Global_DriveAuth + DRIVE_API_NAME);
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
                       new FileDataStore(Global_DriveAuth, true)).Result;

                Service = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "Exten Drive"
                });
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            // 파일을 다 사용한뒤 파일 이름을 다시 복구시킵니다.
            if (fi.Exists)
            {
                fi.MoveTo(Global_DriveAuth + ID);
            }
            return;
        }
        
        public bool Send(SendData data)
        {
            
            Google.Apis.Drive.v2.Data.File body = new Google.Apis.Drive.v2.Data.File
            {
                Title = data.ID + "|" + ID + "|" + data.Content,
                Description = "TCP/IP Test",
                MimeType = "application/unknown",
                Parents = new List<ParentReference>() { new ParentReference() { Id = RootID } }
            };
            byte[] vs = Encoding.Default.GetBytes("");
            MemoryStream stream = new MemoryStream(vs);
            var list = Service.Files.Insert(body, stream, "application/unknown");
            list.UploadAsync();
            return true;
        }



    }
}
