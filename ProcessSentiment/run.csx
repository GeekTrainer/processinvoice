using System.Net;

public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
{
    // The sentiment category defaults to 'GREEN'. 
    string category = "GREEN";

    // Get the sentiment score from the request body.
    double score = await req.Content.ReadAsAsync<double>();
    log.Info(string.Format("The sentiment score received is '{0}'.",
                score.ToString()));

    // Set the category based on the sentiment score.
    if (score < .3)
    {
        category = "RED";
    }
    else if (score < .6)
    {
        category = "YELLOW";
    }
    return req.CreateResponse(HttpStatusCode.OK, category);
}