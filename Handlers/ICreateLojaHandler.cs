using Store.Commands;

namespace Store.Handlers
{
    public interface ICreateLojaHandler
    {
        public LojaResponse Handler(CreateLojaAction request);
    }
}
