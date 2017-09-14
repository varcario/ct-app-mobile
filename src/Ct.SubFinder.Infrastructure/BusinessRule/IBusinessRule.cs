using Ct.SubFinder.Infrastructure.Messages;

namespace Ct.SubFinder.Infrastructure
{
    public interface IBusinessRule<REQ, RES> where REQ : Request where RES : Response
    {
        Content<REQ, RES> Evaluate(Content<REQ, RES> request);
    }
}
