using System;

namespace TokenManager.Entities
{
    public class Token
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string expires_in { get; set; }
        
        public bool IsExpired()
        {
            var dataTokenExpirar =  DateTime.Now.AddSeconds(Convert.ToDouble(this.expires_in));
            var dataMomentoAtual = DateTime.Now;
            
            return dataMomentoAtual.Hour >= dataTokenExpirar.Hour ? true : false;
        }

    }
}