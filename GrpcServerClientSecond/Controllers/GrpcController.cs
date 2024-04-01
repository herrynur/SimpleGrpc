using GrpcServerClientFirst;
using GrpcServerClientSecond.Model;
using Microsoft.AspNetCore.Mvc;

namespace GrpcServerClientSecond.Controllers
{
    [ApiController]
    public class GrpcController : ControllerBase
    {
        private readonly ILogger<GrpcController> _logger;
        private readonly HelloRpc.HelloRpcClient _helloRpcClient;

        public GrpcController(
            ILogger<GrpcController> logger,
            HelloRpc.HelloRpcClient helloRpcClient)
        {
            _logger = logger;
            _helloRpcClient = helloRpcClient;
        }

        [HttpPost("SayHello")]
        public async Task<ActionResult<GrpcResponseModel>> SayHello([FromBody] GrpcMessage input, CancellationToken cancellationToken)
        {
            var sayHelloRequest = new HelloRequest()
            {
                Name = input.Name,
                Message = input.Message,
            };

            var sayHelloResult = await _helloRpcClient.SayHelloAsync(sayHelloRequest, cancellationToken: cancellationToken);

            return Ok(sayHelloResult);
        }
    }
}
