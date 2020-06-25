using FuhoCommerce.Application.UseCases.CartUseCases.Query;


namespace FuhoCommerce.Application.UseCases.CartUseCases.Command
{
    public class CreateCartResponse
    {
        public CartDto CartDto { get; set; }

        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorMessageCode { get; set; }
        public CreateCartResponse() { }

        public CreateCartResponse(CreateCartResponse orther)
        {
            CartDto = orther.CartDto != null ? orther.CartDto : null;
            ErrorCode = orther.ErrorCode;
            ErrorMessage = orther.ErrorMessage;
            ErrorMessageCode = orther.ErrorMessageCode;
        }
    }
}
