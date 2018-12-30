 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Cloud
{
    public class CloudFile
    {
        /// <summary>
        /// 폴더 인지, 파일인지 체크
        /// </summary>
        public string MimeType { get; protected set; }
        /// <summary>
        /// 해당 고유 어카운트의 이름
        /// </summary>
        public string DriveID { get; protected set; }
        /// <summary>
        /// 파일 이름
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 다운로드 경로, share 경로는 아님.
        /// </summary>
        public string DownloadUrl { get; protected set; }
        /// <summary>
        /// 썸네일의 주소 입니다.
        /// </summary>
        public string ThumbnailUrl { get; protected set; }
        /// <summary>
        /// 파일의 크기를 나타냅니다.
        /// </summary>
        public long? Size { get; protected set; }
        /// <summary>
        /// 파일의 인식하기 위한 고유 ID입니다.
        /// </summary>
        public string Id { get; protected set; }
        /// <summary>
        /// 파일이름과 똑같이 나오는데 모르겠음.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 파일 만들어진 날
        /// </summary>
        public string CreatedDate { get; protected set; }
        /// <summary>
        /// 파일이 수정된 날
        /// </summary>
        public string ModifiedDate { get; protected set; }
        /// <summary>
        /// 파일의 확장자
        /// </summary>
        public string FileType { get; protected set; }
        /// <summary>
        /// 쓰레기통에 들어간 파일인가?
        /// </summary>
        public bool IsTrashed { get; protected set; }

        /// <summary>
        /// 구글 드라이브에서 CloudFile화 하는 작업입니다.
        /// </summary>
        /// <param name="file">GoogleDrive에서 읽은 File의 정보를 넘깁니다.</param>
        /// <param name="DriveID">Drive의 이름을 넘깁니다.</param>
        public CloudFile(Google.Apis.Drive.v2.Data.File file, string DriveID)
        {
            this.DriveID = DriveID;
            Id = file.Id;
            FileName = file.OriginalFilename;
            Size = file.FileSize == null ? -1 : file.FileSize;
            Title = file.Title;
            CreatedDate = file.CreatedDate.ToString();
            ModifiedDate = file.ModifiedDate.ToString();
            DownloadUrl = file.DownloadUrl;
            ThumbnailUrl = file.ThumbnailLink;
            MimeType = file.MimeType;
            //     FileType = file.MimeType.Equals("application/vnd.google-apps.folder") ? "folder" : file.FileExtension ?? file.MimeType;
        }
        

        /// <summary>
        /// 텍스트에서 읽은 파일의 정보를 변수화합니다. 직렬화 된것을 풉니다.
        /// </summary>
        /// <param name="str">직렬화 된 데이터</param>
        public CloudFile(string str)
        {
            string[] s = str.Split('\\');

            DriveID = s[0];
            Id = s[1];
            FileName = s[2];
            Size = long.Parse(s[3]);
            Title = s[4];
            CreatedDate = s[5];
            ModifiedDate = s[6];
            DownloadUrl = s[7];
            ThumbnailUrl = s[8];
            MimeType = s[9];
        }

        /// <summary>
        /// 변수의 정보를 직렬화 합니다.
        /// </summary>
        /// <returns>직렬화된 정보를 리턴합니다.</returns>
        override
        public string ToString()
        {
            String Return = string.Empty;
            Return += DriveID;
            Return += @"\" + Id;
            Return += @"\" + FileName;
            Return += @"\" + Size.ToString();
            Return += @"\" + Title;
            Return += @"\" + CreatedDate;
            Return += @"\" + ModifiedDate;
            Return += @"\" + DownloadUrl;
            Return += @"\" + ThumbnailUrl;
            Return += @"\" + MimeType;
            return Return;
        }
    }
}
