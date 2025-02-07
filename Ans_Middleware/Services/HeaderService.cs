using Ans_Middleware.Models;

namespace Ans_Middleware.Services
{
    public class HeaderService
    {

        private Header Header1= new Header();

        public void SetHeaders(Header headers)
        {
            Header1 = headers;
        }
        public Header GetHeaders()
        {
            return Header1;
        }


    }
}
