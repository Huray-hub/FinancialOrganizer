using Domain.Entities.Transaction;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence
{
    public class FODbContext : DbContext, IDbContext
    {
        public FODbContext(DbContextOptions<FODbContext> options) : base(options) { }
       
        public new DbSet<TEntity> Set<TEntity>() where TEntity : class => base.Set<TEntity>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(FODbContext).Assembly);

            base.OnModelCreating(builder);         
        }

        public int ExecuteStoredProcedure(string procedureName, params object[] parameters)
        {
            var commandText = procedureName;

            for (int i = 0; i < parameters.Length; i++)
            {
                if (i > 0)               
                    commandText += ", ";
                
                commandText += $" {{{i}}}";
            }

            return base.Database.ExecuteSqlRaw(commandText, parameters);
        }

        public IList<TEntity> ExecuteStoredProcedureList<TEntity>(string procedureName, params object[] parameters) where TEntity : class, new()
        {
            var commandText = procedureName;

            for (int i = 0; i < parameters.Length; i++)            
                commandText += $" {{{i}}},";
            
            if (commandText.EndsWith(","))           
                commandText = commandText.Remove(commandText.Length - 1);

            return Set<TEntity>()
                    .FromSqlRaw(commandText, parameters)
                    .ToList();                                  
        }

        public IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters) => 
            throw new System.NotImplementedException();

        public int ExecuteSqlCommand(string sql, bool doNotEnsureTransaction = false, int? timeout = null, params object[] parameters) =>
            base.Database.ExecuteSqlRaw(sql, parameters);

        public void Detach(object entity) => 
            throw new System.NotImplementedException();

        public void BulkSaveChanges<TEntity>(IList<TEntity> entities, string metaTimestampKey = null, List<string> propertiesToInclude = null) where TEntity : class
        {
            throw new System.NotImplementedException();
        }

        public bool ProxyCreationEnabled { get; set; }
        public bool AutoDetectChangesEnabled { get; set; }
    }
}
