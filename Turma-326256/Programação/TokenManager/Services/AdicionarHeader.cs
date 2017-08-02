using System.Threading.Tasks;
using TokenManager.Entities;

namespace TokenManager.Services
{
    public class AdicionarHeader
    {
        public Token _token { get; private set; }
        public Request _requestToken { get; private set; }
        
        public AdicionarHeader(Token token, Request requestToken)
        {
            _token = token;
            _requestToken = requestToken;
        }
        public async Task<Token> TokenDeAutorizacao()
        {
            if((_token.access_token == null) || (_token.IsExpired()))
            {
                return await _requestToken.RequisitarToken();   
            }

            return this._token;
        }
    }
}