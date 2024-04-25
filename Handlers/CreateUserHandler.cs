using Store.Commands;
using Store.Data;
using Store.Models;

namespace Store.Handlers
{
    public class CreateUserHandler : ICreateUserHandler
    {
        private DataContext dataContext;
        public CreateUserHandler(DataContext dataContext) 
        {
            this.dataContext = dataContext;
        }
        public UserResponse Handler(CreateUserAction request)
        {
            var user = new Usuario
            {
                Nome = request.Nome,
                Email = request.Email,
                Username = request.Username,
                Password = request.Password
            };
            var result = dataContext.Users.Add(user);
            dataContext.SaveChanges();
            return new UserResponse(result.Entity);
        }
    }
}
