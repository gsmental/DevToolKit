using System;
using System.Collections.Generic;
using System.IO;
//using System.Json;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


    public class MyHttp
    {
        //string Url = MyHttp.FetchSingleAPIData<string>(string.Format("http://m.ptuexam.com/api/PtuExamApp/ExtraPDF/?PDFLink={0}&RollNo={1}", PDFLink, RollNo));
        //var abc =MyHttp.FetchSingleAPIData<List<TabulationModel>>(string.Format("http://appapi.ptudocs.com/api/Tabulation/GetTabulationByRollNo/?Rollno={0}", RollNo));

        //public static async Task<T> FetchSingleAPIDataAsync<T>(string url)
        //{
        //    HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
        //    request.ContentType = "application/json";
        //    request.Method = "GET";

        //    using (WebResponse response = await request.GetResponseAsync())
        //    {
        //        using (Stream stream = response.GetResponseStream())
        //        {
        //            JsonValue jsonDoc = await Task.Run(() => JsonObject.Load(stream));
        //            return JsonConvert.DeserializeObject<T>(jsonDoc.ToString());
        //        }
        //    }
        //}


        public static T FetchSingleAPIData<T>(string url, bool isAuthorization = true)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
            request.ContentType = "application/json";
            request.Method = "GET";

            if (isAuthorization)
            {
                request.PreAuthenticate = true;
                request.Headers.Add("Authorization", "bearer " + DocsSFCApiTokens.SFCAdminToken);
            }


            using (WebResponse response = request.GetResponse())
            {
                //using (Stream stream = response.GetResponseStream())
                //{
                //    JsonValue jsonDoc = JsonObject.Load(stream);
                //    return JsonConvert.DeserializeObject<T>(jsonDoc.ToString());
                //}

                string jsonDoc = "";
                using (Stream outputStream = response.GetResponseStream())
                {
                    using (StreamReader streamReader = new StreamReader(outputStream, System.Text.Encoding.ASCII))
                    {
                        jsonDoc = streamReader.ReadToEnd();
                        return JsonConvert.DeserializeObject<T>(jsonDoc.ToString());
                    }
                }

            }
        }



        public static T PostAPIData<T>(string url, string postData, bool isAuthorization)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
            request.ContentType = "application/x-www-form-urlencoded";
            request.Method = "POST";
            // request.Timeout = 1000000;

            if (isAuthorization)
            {
                request.PreAuthenticate = true;
                request.Headers.Add("Authorization", "bearer " + DocsSFCApiTokens.SFCAdminToken);
            }


            byte[] postArray = Encoding.ASCII.GetBytes(postData);
            request.ContentLength = postArray.Length;
            using (var stream = request.GetRequestStream())
            {
                stream.Write(postArray, 0, postArray.Length);
            }

            using (WebResponse response = request.GetResponse())
            {
                //using (Stream stream = response.GetResponseStream())
                //{
                //    JsonValue jsonDoc = JsonObject.Load(stream);
                //    return JsonConvert.DeserializeObject<T>(jsonDoc.ToString());
                //}

                string jsonDoc = "";
                using (Stream outputStream = response.GetResponseStream())
                {
                    using (StreamReader streamReader = new StreamReader(outputStream, System.Text.Encoding.ASCII))
                    {
                        jsonDoc = streamReader.ReadToEnd();
                        return JsonConvert.DeserializeObject<T>(jsonDoc.ToString());
                    }
                }
            }
        }
    }
