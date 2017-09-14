
namespace Ct.SubFinder.Infrastructure.Messages
{
    public class Content<REQ, RES> where REQ : Request where RES : Response
    {
        public REQ Request { get; set; }
        public RES Response { get; set; }
    }
}
