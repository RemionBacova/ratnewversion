using RatServer.Controllers.Client;
using RatServer.Interfaces;

namespace RatServer.Services
{
    public class FileService : IFileService
    {
        private File file;
        public FileService()
        {

        }
        public bool SetFile(File file)
        {
            this.file = file;
            return true;
        }
        public File GetFile()
        {
            return file;
        }
        public bool ClearFile()
        {
            file = null;
            return true;
        }

    }
}
