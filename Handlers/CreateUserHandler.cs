using Store.Commands;
using Store.Data;
using Store.Models;

namespace Store.Handlers
{
    public class CreateUserHandler : ICreateUserHandler
    {
        private DataContext dataContext;
        private IEmailSender sendEmail;
        public CreateUserHandler(DataContext dataContext, IEmailSender sendEmail) 
        {
            this.dataContext = dataContext;
            this.sendEmail= sendEmail;
        }
        public UserResponse Handler(CreateUserAction request)
        {

            var user = new Usuario
            {
                Nome = request.Nome,
                Email = request.Email,
                Username = request.Email.Split("@")[0],
                Password = request.Password
            };
            var result = dataContext.Users.Add(user);
            dataContext.SaveChanges();
            sendEmail.SendEmailAsync(user.Email, "Cadastro", "<h1>Parabens! você se cadastrou</h1>");
            return new UserResponse(result.Entity);
        }
    }
}
