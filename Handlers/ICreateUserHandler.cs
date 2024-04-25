using Microsoft.AspNetCore.Http.HttpResults;
using Store.Commands;

namespace Store.Handlers
{
    public interface ICreateUserHandler
    {
        public UserResponse Handler(CreateUserAction request);
    }
}
