﻿using Enversoft.DAL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enversoft.BusinessLogic
{
    public class DomainInjection
    {
        public static void InjectBusinessLogic(IServiceCollection Services)
        {
            Services.AddTransient<IUnitOfWork, UnitOfWork>();

            #region Repository
            Services.AddScoped<IStockItemRepository, StockItemRepository>();
            Services.AddScoped<ISupplierLocationRepository, SupplierLocationRepository>();
            Services.AddScoped<IWarehouseRepository,WarehouseRepository>();
            Services.AddScoped<ISupplierRepository, SupplierRepository>();
            Services.AddScoped<ILogisticsRepository, LogisticsRepository>();

            Services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            Services.AddScoped<IItemRepository, ItemRepository>();
            Services.AddScoped<IOrderRepository, OrderRepository>();
            Services.AddScoped<ICustomerRepository, CustomerRepository>();
            Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            #endregion Repository

            #region Business Logic
            Services.AddScoped<IAuthorizationLogic, AuthorizationLogic>();
            Services.AddScoped<IEmployeeLogic, EmployeeLogic>();
            Services.AddScoped<ICustomerLogic, CustomerLogic>();
            Services.AddScoped<IItemLogic, ItemLogic>();
            Services.AddScoped<IOrderLogic, OrderLogic>();
            Services.AddScoped<ISupplierLogic, SupplierLogic>();
            Services.AddScoped<IOrderItemLogic, OrderItemLogic>();
            #endregion Business Logic
            
        }

        public static void InjectCors(IServiceCollection Services)
        {
            Services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder => builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader());
            });
        }

        public static void InjectJwtTokens(IServiceCollection Services, string ValidAudience, string ValidIssuer, string Secret)
        {
            Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = ValidAudience,
                    ValidIssuer = ValidIssuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Secret))
                };
            });
        }

        //public static void InjectJsonOptions(IServiceCollection Services)
        //{
        //    Services.AddControllers(options =>
        //    {
        //        options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
        //    }).AddJsonOptions(options =>
        //    {
        //        options.JsonSerializerOptions.PropertyNamingPolicy = null;
        //        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        //    });
        //}
    }
}
