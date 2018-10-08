public static void sendPushWithFcm()
{
	// https://firebase.google.com/docs/cloud-messaging/http-server-ref    
    string apiKey = "AIza...";
    string deviceId = "edJtMU...";
    
    try
    {
        var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://fcm.googleapis.com/fcm/send");
        httpWebRequest.ContentType = "application/json";
        httpWebRequest.Headers.Add("Authorization:key=" + apiKey);
        httpWebRequest.Method = "POST";

        string j1 = "{\"to\": \"" + deviceId + "\", \"notification\": {\"title\": \"FCM Push\",\"body\": \"send fcm 1\", \"sound\": \"default\"} }";
        string j2 = "{\"registration_ids\":[\"" + deviceId + "\"],\"data\":{\"ProductID\":0,\"Title\":\"FCM Push\",\"Body\":\"send fcm 2\"}}";
        string j3 = "{ \"to\" : \"" + deviceId + "\", \"notification\" : {\"body\" : \"send fcm 3\", \"title\" : \"FCM Push\", \"sound\": \"default\" }, \"data\" : { \"name\" : \"recep\" } }";

        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
        {
            streamWriter.Write(j1);
            streamWriter.Flush();
        }

        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        if (httpResponse.StatusCode == HttpStatusCode.OK)
        {
            string result = string.Empty;
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }

            FCMPushResponse fcmResponse = null;
            if (!string.IsNullOrEmpty(result))
            {
                fcmResponse = JsonConvert.DeserializeObject<FCMPushResponse>(result);
            }
        }
        else
        {
        }				
	}
    catch (Exception ex)
    {
    } 
}

public class FCMPushResponse
{
    public string multicast_id { get; set; }
    public int success { get; set; }
    public int failure { get; set; }
    public int canonical_ids { get; set; }
    public List<Result> results { get; set; }
}

public class Result
{
    public string message_id { get; set; }
    public string registration_id { get; set; }
    public string error { get; set; }
}
