using IOT.Core.IRepository.Login;
using IOT.Core.Repository.Login;
using IOT.Core.IRepository.Activity;
using IOT.Core.IRepository.GroupBooking;
using IOT.Core.IRepository.Agent;
using IOT.Core.IRepository.Colonel;
using IOT.Core.IRepository.Colonel.Brokerage;
using IOT.Core.IRepository.Colonel.ColonelGrade;
using IOT.Core.IRepository.Colonel.ColonelManagement;
using IOT.Core.IRepository.Colonel.GroupPurchase;
using IOT.Core.IRepository.Colonel.Path;
using IOT.Core.IRepository.Com_Comment;
using IOT.Core.IRepository.CommissionRecord;
using IOT.Core.IRepository.CommodityRepository;
using IOT.Core.IRepository.CommType;
using IOT.Core.IRepository.Delivery;
using IOT.Core.IRepository.Live;
using IOT.Core.IRepository.OutLibrary;
using IOT.Core.IRepository.PayStore;
using IOT.Core.IRepository.PutLibrary;
using IOT.Core.IRepository.OrderInfo;
using IOT.Core.IRepository.RoleManage;
using IOT.Core.IRepository.Roles;
using IOT.Core.IRepository.SeckillCom;
using IOT.Core.IRepository.Sett;
using IOT.Core.IRepository.Specification;
using IOT.Core.IRepository.Store;
using IOT.Core.IRepository.Store_Configuration;
using IOT.Core.IRepository.SVIP;
using IOT.Core.IRepository.Users;
using IOT.Core.IRepository.Warehouse;
using IOT.Core.IRepository.Withdrawal;
using IOT.Core.Repository.Activity;
using IOT.Core.Repository.GroupBooking;
using IOT.Core.Repository.Agent;
using IOT.Core.Repository.Colonel;
using IOT.Core.Repository.Colonel.Brokerage;
using IOT.Core.Repository.Colonel.ColonelGrade;
using IOT.Core.Repository.Colonel.ColonelManagement;
using IOT.Core.Repository.Colonel.GroupPurchase;
using IOT.Core.Repository.Colonel.Path;
using IOT.Core.Repository.Com_Comment;
using IOT.Core.Repository.CommissionRecord;
using IOT.Core.Repository.OrderInfo;
using IOT.Core.Repository.RoleManage;
using IOT.Core.Repository.Roles;
using IOT.Core.Repository.SeckillCom;
using IOT.Core.Repository.Sett;
using IOT.Core.Repository.Specification;
using IOT.Core.Repository.Store;
using IOT.Core.Repository.Store_Configuration;
using IOT.Core.Repository.SVIP;
using IOT.Core.Repository.Users;
using IOT.Core.Repository.Warehouse;
using IOT.Core.Repository.Withdrawal;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using IOT.Core.Repository.Commodity;
using IOT.Core.Repository.CommType;
using IOT.Core.Repository.Delivery;
using IOT.Core.Repository.OutLibrary;
using IOT.Core.Repository.PayStore;
using IOT.Core.Repository.PutLibrary;
using IOT.Core.IRepository.Bargain;
using IOT.Core.Repository.Bargain;
using IOT.Core.Repository.Live;
using IOT.Core.IRepository.MiniProgram;
using IOT.Core.Repository.MiniProgram;
using IOT.Core.IRepository.NowRep;
using IOT.Core.Model;
using IOT.Core.Repository.NowRep;
using IOT.Core.IRepository.CheckRep;
using IOT.Core.Repository.CheckRep;
using IOT.Core.IRepository.OrderInfos;
using IOT.Core.Repository.OrderInfos;

namespace IOT.Core.Api
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "IOT.Core.Api", Version = "v1" });
            });

            //--------------------------------------------------------------------------------------
            //ljh
            services.AddSingleton<IColonelRepository, ColonelRepository>();
            services.AddSingleton<IColonelManagementRepository, ColonelManagementRepository>();
            services.AddSingleton<IColonelGradeRepository, ColonelGradeRepository>();
            services.AddSingleton<IGroupPurchaseRepository, GroupPurchaseRepository>();
            services.AddSingleton<IPathRepository, PathRepository>();
            services.AddSingleton<IBrokerageRepository, BrokerageRepository>();
            services.AddSingleton<IOrderInfoRepository, OrderInfoRepository>();
            services.AddSingleton<IOrderInfosRepository, OrderInfosRepository>();
            services.AddSingleton<IOrderCommentRepository, OrderCommentRepository>();
            services.AddSingleton<IOrderDelivery, OrderDelivery>();
            services.AddSingleton<IMiniProgramRepository, MiniProgramRepository>();

            

            services.AddSingleton<IOrderDelivery, OrderDelivery>();            
            //--------------------------------------------------------------------------------------

            //--------------------------------------------------------------------------------------
            //zxl
            services.AddSingleton<IAgentRepository, AgentRepository>();
            services.AddSingleton<ICommissionRecordRepository, CommissionRecordRepository>();
            services.AddSingleton<IRoleManageRepository, RoleManageRepository>();
            services.AddSingleton<ISettRepository, SettRepository>();
            services.AddSingleton<ISVIPRepository, SVIPRepository>();
            services.AddSingleton<IUsersRepository, UsersRepository>();
            services.AddSingleton<IRolesRepository, RolesRepository>();
            services.AddSingleton<ILoginRepository, LoginRepository>();
            //--------------------------------------------------------------------------------------

            //--------------------------------------------------------------------------------------
            //dyt
            services.AddScoped<IActivityRepository, ActivityRepository>();
            services.AddScoped<ISeckillComRepository, SeckillComRepository>();
            services.AddScoped<IBargainRepository, BargainRepository>();
            services.AddScoped<ILiveRepository, LiveRepository>();
            services.AddScoped<IGroupBookingRepository, GroupBookingRepository>();
            //--------------------------------------------------------------------------------------

            //wpc-----------------------------------------
            services.AddScoped<ICommodityRepository, CommodityRepository>();
            services.AddScoped<ICommTypeRepository, CommTypeRepository>();
            services.AddScoped<ISpecificationRepository, SpecificationRepository>();
            services.AddSingleton<ICom_CommentRepository, Com_CommentRepository>();
            //--------------------------------------------

            //zx-------------------------------------------------------------------------------------
            services.AddSingleton<IDeliveryRepository, DeliveryRepository>();
            services.AddSingleton<IOutLibraryRepository, OutLibraryRepository>();
            services.AddSingleton<IPayStoreRepository, PayStoreRepository>();
            services.AddSingleton<IPutLibraryRepository, PutLibraryRepository>();
            services.AddSingleton<IStoreRepository, StoreRepository>();
            services.AddSingleton<IStore_ConfigurationRepository, Store_ConfigurationRepository>();
            services.AddSingleton<IWarehouseRepository, WarehouseRepository>();
            services.AddSingleton<IWithdrawalRepository, WithdrawalRepository>();
            services.AddSingleton<INowRepRepository, NowRepRepository>();
            services.AddSingleton<ICheckRepRepository, CheckRepRepository>();

            //zx-------------------------------------------------------------------------------------

            services.AddCors(options => 
            options.AddPolicy("cors",
            p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "IOT.Core.Api v1"));
            }
            app.UseCors("cors");
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
