using Store.Commands;

namespace Store.Handlers
{
    public interface IGetLojaHandler
    {
        public LojaResponse Handler(int id);
    }
}
