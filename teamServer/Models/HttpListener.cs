namespace teamServer.Models
{
    public class HttpListener : Listener
    {
        public override string Name { get; }
        public int BindPort { get;}

        private CancellationTokenSource _tokenCancel;

        //taking the required inputs(name and port)
        public HttpListener(String name, int bindPort)
        {
            Name = name;
            BindPort = bindPort;
        }

        public override async Task start()
        {
            //use of asp.net core to provide http functionalitites
            //https://dotnettutorials.net/lesson/adding-web-host-builder/
            var hostBuilder = new HostBuilder()
                .ConfigureWebHostDefaults(host =>
                {
                    host.UseUrls("https://0.0.0.0:{BindPort}"); //specify the url web host will listen on. this host will listen on all interfaces but on specific bindport
                    host.Configure(ConfigureApp);
                    host.ConfigureServices(ConfigureServices);
                    //https://www.geeksforgeeks.org/explain-configureservices-and-configure-method-in-asp-net/
                });

            

            _tokenCancel = new CancellationTokenSource();
            var host = hostBuilder.Build();
            host.RunAsync(_tokenCancel.Token);
        }

        private void ConfigureServices(IServiceCollection service)
        {
            service.AddControllers();
        }

        private void ConfigureApp(IApplicationBuilder app)
        {
            //https://www.youtube.com/watch?v=MDrYbLx1NLI
            app.UseRouting();
            app.UseEndpoints(endpoint =>
            {
                endpoint.MapControllerRoute("/", "/", new
                {
                    controller = "HttpListener", action = "HandleRequest"
                });
            });
        }

        public override void stop()
        {
            _tokenCancel.Cancel();
        }
    }
}
