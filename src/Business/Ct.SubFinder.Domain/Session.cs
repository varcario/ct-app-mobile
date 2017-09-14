
namespace Ct.SubFinder.Domain
{    
    public class Session
    {        
        public string SessionId { get; set; } 
        public string Username { get; set; }
        public string Secrete { get; set; }
        
        public Credential Credential { get; set; }
    }
}
