using Microsoft.AspNetCore.Authorization;
namespace AuthorizationApiDemo
{
    public class CustomerAuthorizationRequirment : IAuthorizationRequirement
    {
        public string Name { get; set; }
        public CustomerAuthorizationRequirment(string name) { 
            this.Name = name;
        }
    }
}
