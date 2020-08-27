using Application.AmountModifications.Commands;
using Application.AmountModifications.Queries;
using Application.Base;
using Application.TransactionCategories;
using Application.Transactions.Commands;
using Application.Transactions.Queries;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

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
            services.AddTransient<IAmountModificationUowCommand, AmountModificationUowCommand>();
            services.AddTransient<ITransactionCategoryUowQuery, TransactionCategoryUowQuery>();

         
            return services;
        }
    }
}
