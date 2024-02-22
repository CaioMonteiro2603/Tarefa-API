using Tarefa.Models;

namespace Tarefa.Repository.Interface
{
    public interface ITarefaRepository
    {
        public Task<IList<TarefaModel>> FindAll();

        public Task<TarefaModel> FindById(int id);

        public Task<int> Insert(TarefaModel tModel);

        public void Update(TarefaModel tModel);

        public void Delete(int id);
    }
}
