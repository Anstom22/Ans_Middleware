using Ans_Middleware.Models;

namespace Ans_Middleware.Services
{
    public class CurrentHeader
    {
        private Header? latestHeader;
        public void SetHeaders(Header headers)
        {
            this.latestHeader = headers;
        }

        public Header? GetHeaders()
        {
            return this.latestHeader;
        }


    }
}
