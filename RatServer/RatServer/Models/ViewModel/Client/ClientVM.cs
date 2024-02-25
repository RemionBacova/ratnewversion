using MongoDB.Bson.Serialization.Attributes;

namespace RatServer.Models.ViewModel.Client
{
    public class ClientVM
    {

        public string clientId { get; set; }


        public bool ifConnected { get; set; }


        public bool ifRegistered { get; set; }


        public bool ifUpdate { get; set; }


        public bool IfInstalledAplicationDump { get; set; }

        public bool ifKeyLogDump { get; set; }


        public bool ifScreenShare { get; set; }


        public bool ifCMDRun { get; set; }
    }
}
