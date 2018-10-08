public static void sendPushWithFcm()
{   
    string apiKey = "AIza...";
    string deviceId = "edJtMU...";
    
    try
    { 
        string j1 = "{\"to\": \"" + deviceId + "\", \"notification\": {\"title\": \"GCM Push\",\"body\": \"send gcm 1\", \"sound\": \"default\"} }";
        string j2 = "{\"registration_ids\":[\"" + deviceId + "\"],\"data\":{\"ProductID\":0,\"Title\":\"GCM Push\",\"Body\":\"send gcm 2\"}}";
        string j3 = "{ \"to\" : \"" + deviceId + "\", \"notification\" : {\"body\" : \"send gcm 3\", \"title\" : \"GCM Push\", \"sound\": \"default\" }, \"data\" : { \"name\" : \"recep\" } }";
  
        using (var httpClient = new HttpClient())
        {
            httpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("GCM-PushClient", "1.0.0"));
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "key=" + apiKey);

            var postContent = new StringContent(j1, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("https://android.googleapis.com/gcm/send", postContent);
            if (!response.IsSuccessStatusCode)
            {
            }
        } 				
    }
    catch (Exception ex)
    {
    } 
}
 
