using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Common;

namespace WebApplication3
{
    /*
     拦截器继承自 DbCommandInterceptor，这样就无需实现拦截器接口中的每种方法。
     侦听器同时实现同步和异步方法。 这可确保将相同的查询提示应用于同步和异步查询。
     侦听器实现 Executing 方法，这些方法由 EF Core 通过生成的 SQL（发送到数据库之前）进行调用。 将此方法与 Executed 方法进行比较，后者在已返回数据库调用之后进行调用。
     */
    public class TaggedQueryCommandInterceptor:DbCommandInterceptor
    {
        public override InterceptionResult<DbDataReader> ReaderExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result)
        {
            ManipulateCommand(command);
            return result;
        }

        public override ValueTask<InterceptionResult<DbDataReader>> ReaderExecutingAsync(DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result, CancellationToken cancellationToken = default)
        {
            ManipulateCommand(command);
            return new ValueTask<InterceptionResult<DbDataReader>>(result);
        }

        private static void ManipulateCommand(DbCommand command)
        {
            if (command.CommandText.StartsWith("-- Use hint: robust plan", StringComparison.Ordinal))
            {
                command.CommandText += " OPTION (ROBUST PLAN)";
            }
        }
    }
}
