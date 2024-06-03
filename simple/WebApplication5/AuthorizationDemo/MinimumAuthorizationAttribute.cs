using Microsoft.AspNetCore.Authorization;

namespace AuthorizationDemo
{
    public class MinimumAuthorizationAttribute : AuthorizeAttribute, IAuthorizationRequirement, IAuthorizationRequirementData
    {
        public MinimumAuthorizationAttribute(int age)
        {
            this.Age = age;
        }

        public int Age { get; }

        public IEnumerable<IAuthorizationRequirement> GetRequirements()
        {
            yield return this;
        }
    }
}
