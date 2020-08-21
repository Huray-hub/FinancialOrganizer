using MediatR;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Application.Base;
using Domain.Entities;
using Application.Transactions.Queries;
using Application.Transactions.Commands;
using Application.AmountModifications.Queries;

namespace Application
{
    public static class ApplicationDI
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            services.AddScoped(typeof(IEntityUnitOfWorkQuery<>), typeof(BaseEntityUnitOfWorkQuery<>));
            services.AddScoped(typeof(IEntityUnitOfWorkCommand<>), typeof(BaseEntityUnitOfWorkCommand<>));
            services.AddScoped<IBaseEntity, BaseEntity>();

            services.AddTransient<ITransactionUnitOfWorkQuery, TransactionUnitOfWorkQuery>();
            services.AddTransient<ITransactionUnitOfWorkCommand, TransactionUnitOfWorkCommand>();
            services.AddTransient<IAmountModificationUowQuery, AmountModificationUowQuery>();

            return services;
        }
    }
}
