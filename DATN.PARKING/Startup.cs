using Autofac;
using Castle.DynamicProxy;
using Eport_OrderIntfGateway;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.ServiceModel;
using TCIS.TTOS.Common.DynnamicLog.AutoWriteLog;
using TCIS.TTOS.Common.DynnamicLog.Extensions;
using TCIS.TTOS.Commons;
using TCIS.TTOS.Commons.Configurations;
using TCIS.TTOS.EDI.DAL;

namespace TCIS.TTOS.EDI.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCustomValidationRequest();
            services.AddEntityFrameworkOracle();
            services.AddControllers();
            services.AddHttpContextAccessor();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TCIS.TTOS.EDI.API", Version = "v1" });
            });
            services.AddSingleton(new ProxyGenerator());
            services.AddScoped<IInterceptor, DynamicProxyLog>();
            services.AddMediatR(AppDomain.CurrentDomain.Load("TCIS.TTOS.EDI.Service"));
            GlobalSettings.SiteId = Configuration.GetEx("SiteId");
            var sqlConnString = Configuration.GetEx("ConnectionStrings:TTOSConnectionString");
            services.AddDbContext<TtosEDIContext>(opt => opt.UseOracle(sqlConnString, options => options.UseOracleSQLCompatibility("11")));

            services.AddScoped(provider =>
            {
                var binding = new BasicHttpBinding();
                var endpoint = new EndpointAddress("http://localhost:54000/OrderIntfGateway.svc?wsdl");
                return new OrderIntfGatewayClient(binding, endpoint);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.AddJWTMiddleware();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TCIS.TTOS.EDI.API v1"));
            app.UseRouting();
            app.UseStaticFiles();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {

            builder.AddDynamicLog(Configuration);
            builder.RegisterModule(new AutofacModule());
        }
    }
}
