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
            let! bodyStream = req.Content.ReadAsStreamAsync() |> Async.AwaitTask
            let response = new HttpResponseMessage(HttpStatusCode.OK)

            response.Content <- new StreamContent(bodyStream)
            response.Content.Headers.ContentType <- req.Content.Headers.ContentType

            return response
          } |> Async.StartAsTask
