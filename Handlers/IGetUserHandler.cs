using Store.Commands;
using System.Collections.Generic;

namespace Store.Handlers
{
    public interface IGetUserHandler
    {
        public UserResponse Handler(int id);
    }
}
