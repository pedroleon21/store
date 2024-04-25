using Store.Commands;

namespace Store.Handlers
{
    public interface IGetLoiaHandler
    {
        public LojaResponse Handler(int id);
    }
}
