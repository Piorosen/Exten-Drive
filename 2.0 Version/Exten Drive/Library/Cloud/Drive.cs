using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Cloud;


namespace Library.Cloud
{
    abstract class Drive
    {
        
        
        #region Public_Varience
        abstract public string DriveID { get; protected set; }           // 사용자가 해당 드라이브를 구별하기 위한 아이디  *외부 처리적
        abstract public string DriveName { get; protected set; }       // 해당 드라이브의 종류 (GoogleDrive, DropBox 등등) *내부 처리적
        abstract public long? Capacity { get; protected set; }         // 전체적인 용량
        abstract public long? CapacityUse { get; protected set; }      // 해당 드라이브의 사용량
        abstract public long? CapacityTrash { get; protected set; }    // 해당 드라이브의 쓰레기통에 있는 사용량

        #endregion
        
        #region Public_Function
        /// <summary>
        /// 파일을 업로드하는 시스템입니다.
        /// </summary>
        /// <param name="uploadFile">업로드할 파일의 경로를 입력하는곳입니다.</param>
        /// <param name="parent">업로드할 클라우드의 경로를 입력하는곳입니다.</param>
        /// <returns>프로그램이 잘 실행이 되었는지의 유무의 에러코드입니다.</returns>
        abstract public Error Upload(string uploadFile, string parent);

        /// <summary>
        /// 파일을 다운로드하는 시스템입니다.
        /// </summary>
        /// <param name="resource">파일을 읽거나, 정보, 해당 파일의 모든정보를 담는 변수입니다.</param>
        /// <param name="DownloadPath">다운로드할 하드 경로를 작성을 합니다. 안 할경우에는 프로그램의 실행경로의 \Download\ 에 저장됩니다.</param>
        /// <returns>프로그램이 잘 실행이 되었는지의 유무의 에러코드입니다.</returns>
        abstract public Error Download(CloudFile resource, string DownloadPath = null);
        
        /// <summary>
        /// RaidHard에서 쓰이는 파일목록을 읽을때 쓰입니다.
        /// </summary>
        /// <param name="Path">Root\~\로 시작하는 폴더 목록입니다.</param>
        /// <returns>파일정보를 넘겨줍니다.</returns>
        abstract public List<CloudFile> GetFile(string Path);
        
        /// <summary>
        /// 폴더를 새롭게 만듭니다.
        /// </summary>
        /// <param name="Path">Root\~\Name 폴더를 생성할 주소입니다.</param>
        /// <returns>프로그램이 잘 실행이 되었는지의 유무의 에러코드입니다.</returns>
        abstract public Error FolderCreate(string m_Path);
        
        /// <summary>
        /// 공유할 파일의 주소를 공유합니다.
        /// </summary>
        /// <param name="resource">파일정보를 넘깁니다.</param>
        /// <returns>파일정보에서 파일공유주소를 리턴합니다., 클립보드에 복사됩니다.</returns>
        abstract public string ShareFile(CloudFile resource);
        
        /// <summary>
        /// 폴더나 파일의 이름을 변경합니다. 동시에 여러개도 되며, 이름순은 파일의 갯수가 2개일경우 01 02 , 3개 001 순입니다.
        /// </summary>
        /// <param name="prevName">이전의 사용되던 파일의 목록입니다.</param>
        /// <param name="nextName">새롭게 바뀔 파일들의 이름 목록입니다.</param>
        /// <returns>프로그램이 잘 실행이 되었는지의 유무의 에러코드입니다.</returns>
        abstract public Error ReName(CloudFile prevName, string nextName, string Path);
        
        /// <summary>
        /// 폴더나 파일을 단체로 옮길때 사용됩니다.
        /// </summary>
        /// <param name="prevFile">이전의 파일값입니다.</param>
        /// <param name="Path">단체로 어디로 이동할 경로의 값입니다.</param>
        /// <returns>프로그램이 잘 실행이 되었는지의 유무의 에러코드입니다.</returns>
        abstract public Error Move(CloudFile prevFile, string Path, string prevPath);
        
        /// <summary>
        /// 파일이나 폴더를 삭제를 합니다.
        /// </summary>
        /// <param name="prevFile">파일의 목록을 받습니다.</param>
        /// <returns>프로그램이 잘 실행이 되었는지의 유무의 에러코드입니다.</returns>
        abstract public Error Delete(CloudFile prevFile, string Path);

        /// <summary>
        /// 파일이나 폴더를 복사를 합니다.
        /// </summary>
        /// <param name="prevFile">복사할 파일의 원본을 받습니다.</param>
        /// <param name="CopyName">복사할 파일의 이름을 받고, 이름을 지정하지 않으면은 이전이름으로 됩니다.</param>
        /// <returns>프로그램이 잘 실행이 되었는지의 유무의 에러코드입니다.</returns>
        abstract public Error Copy(CloudFile prevFile, string path, string CopyName = null);

        abstract public Error IsFile(string path, string name);
        abstract public Error IsFolder(string path);

        #endregion
    }
}
