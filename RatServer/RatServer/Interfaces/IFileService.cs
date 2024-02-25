

using RatServer.Controllers.Client;

namespace RatServer.Interfaces
{
    public interface IFileService
    {
        public bool SetFile(File file);

        public File GetFile();

        public bool ClearFile();
       
    }
}
