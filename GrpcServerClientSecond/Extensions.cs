using CobaGrpcNet.Settings;
using GrpcServerClientFirst;

namespace GrpcServerClientSecond
{
    public static class Extensions
    {
        public static IServiceCollection AddGrpcConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var grpcSetting = configuration.GetSection(nameof(GrpcSetting)).Get<GrpcSetting>();

            services.AddGrpc();
            services.AddGrpcClient<HelloRpc.HelloRpcClient>((s, options) =>
            {
                options.Address = new Uri(grpcSetting!.HelloGrpcHost!);
            });

            return services;
        }
    }
}
