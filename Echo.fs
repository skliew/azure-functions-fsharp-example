namespace MyFunctions

open Microsoft.Azure.WebJobs
open Microsoft.Azure.WebJobs.Extensions.Http
open Microsoft.Extensions.Logging
open System.Net
open System.Net.Http
open System.Net.Http.Headers

module Echo =
    [<FunctionName("echo")>]
    let run
        ([<HttpTrigger(AuthorizationLevel.Anonymous, "POST")>]
        req: HttpRequestMessage,
        log: ILogger) =
          async {
            let response = new HttpResponseMessage(HttpStatusCode.OK)

            response.Content <- req.Content

            return response
          } |> Async.StartAsTask
