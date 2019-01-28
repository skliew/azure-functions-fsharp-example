namespace MyFunctions

open Microsoft.Azure.WebJobs
open Microsoft.Azure.WebJobs.Extensions.Http
open Microsoft.Extensions.Logging
open System.Net
open System.Net.Http

module Delay =
    [<FunctionName("delay")>]
    let run
        ([<HttpTrigger(AuthorizationLevel.Anonymous, Route="delay/{milliseconds}")>]
        req: HttpRequestMessage,
        milliseconds: int, log: ILogger) =
          async {
            log.LogInformation("Delay for {milliseconds} milliseconds", milliseconds)
            do! Async.Sleep(milliseconds)
            return req.CreateResponse(HttpStatusCode.OK)
          } |> Async.StartAsTask
