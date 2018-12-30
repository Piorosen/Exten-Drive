using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Cloud.DropBox
{
    class DropBoxDrive : Drive
    {
        public override long? Capacity { get; protected set; }

        public override Error IsFile(string path, string name)
        {
            throw new NotImplementedException();
        }

        public override Error IsFolder(string path)
        {
            throw new NotImplementedException();
        }

        public override long? CapacityTrash { get; protected set; }

        public override long? CapacityUse { get; protected set; }

        public override string DriveID { get; protected set; }

        public override string DriveName { get; protected set; }

        public override Error Copy(CloudFile prevFile, string Path, string CopyName = null)
        {
            throw new NotImplementedException();
        }

        public override Error Delete(CloudFile prevFile, string Path)
        {
            throw new NotImplementedException();
        }

        public override Error Download(CloudFile resource, string DownloadPath = null)
        {
            throw new NotImplementedException();
        }

        public override Error FolderCreate(string m_Path)
        {
            throw new NotImplementedException();
        }

        public override List<CloudFile> GetFile(string Path)
        {
            throw new NotImplementedException();
        }

        public override Error Move(CloudFile prevFile, string Path, string prevPath)
        {
            throw new NotImplementedException();
        }

        public override Error ReName(CloudFile prevName, string nextName, string Path)
        {
            throw new NotImplementedException();
        }

        public override string ShareFile(CloudFile resource)
        {
            throw new NotImplementedException();
        }

        public override Error Upload(string uploadFile, string parent)
        {
            throw new NotImplementedException();
        }
    }
}
