using Grpc.Core;

namespace GrpcServerClientFirst.Grpc
{
    public class GrpcServices : HelloRpc.HelloRpcBase
    {
        private readonly ILogger<GrpcServices> _logger;

        public GrpcServices(ILogger<GrpcServices> logger)
        {
            _logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            Console.WriteLine("Sender : " + request.Name + " Message : " + request.Message);
            return Task.FromResult(new HelloReply()
            {
                Message = "Hello " + request.Name + ", Iam from Server "
            });
        }

    }
}
