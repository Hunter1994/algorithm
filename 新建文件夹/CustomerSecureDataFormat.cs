using Microsoft.AspNetCore.Authentication;

namespace WebApplication1
{
    public class CustomerSecureDataFormat : ISecureDataFormat<AuthenticationTicket>
    {
        public string Protect(AuthenticationTicket data)
        {
            throw new NotImplementedException();
        }

        public string Protect(AuthenticationTicket data, string? purpose)
        {
            throw new NotImplementedException();
        }

        public AuthenticationTicket? Unprotect(string? protectedText)
        {
            throw new NotImplementedException();
        }

        public AuthenticationTicket? Unprotect(string? protectedText, string? purpose)
        {
            throw new NotImplementedException();
        }
    }
}
