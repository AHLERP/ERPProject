using ERPProject.UI.Exceptions;
using System.Net;

namespace ERPProject.UI.Handler
{
    public class AuthTokenHandler : DelegatingHandler
    {
        public AuthTokenHandler()
        {
            
        }
        private IHttpContextAccessor _httpContextAccessor;

        public AuthTokenHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                string _token = _httpContextAccessor.HttpContext.Session.GetString("token");
                if (!String.IsNullOrEmpty(_token))
                {
                    request.Headers.Add("Authorization",$"Bearer {_token}");
                }
            }
            var response=await base.SendAsync(request, cancellationToken);
            if (response.StatusCode == HttpStatusCode.Forbidden)
            {
                throw new UnAuthorizeException("Hakan'ın dediği olsun");
            }
            if(response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnAuthorizeException("Hakan'ın dediği olmaaaaz");

            }
            return response;
        }
    }
}
