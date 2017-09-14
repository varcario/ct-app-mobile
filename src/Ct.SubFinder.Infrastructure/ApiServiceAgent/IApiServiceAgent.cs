using Ct.SubFinder.Infrastructure.Messages;

namespace Ct.SubFinder.Infrastructure.ApiServiceAgent
{
    public interface IApiServiceAgent<REQ, RES> where REQ: Request where RES: Response
    {
        /// <summary>
        /// Invokes the 
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        Content<REQ, RES> Invoke(Content<REQ, RES> content);         
    }
}
