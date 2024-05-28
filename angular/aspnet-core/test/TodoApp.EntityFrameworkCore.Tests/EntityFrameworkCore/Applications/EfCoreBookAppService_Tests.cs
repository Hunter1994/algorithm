using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Books;
using Xunit;

namespace TodoApp.EntityFrameworkCore.Applications
{
    [Collection(TodoAppTestConsts.CollectionDefinitionName)]
    public class EfCoreBookAppService_Tests : BookAppService_Tests<TodoAppEntityFrameworkCoreTestModule>
    {

    }
}
