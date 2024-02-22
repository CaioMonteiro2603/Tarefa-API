using Microsoft.EntityFrameworkCore;
using Tarefa.Data;
using Tarefa.Models;
using Tarefa.Repository.Interface;

namespace Tarefa.Repository
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly DataContext _dataContext;

        public TarefaRepository(DataContext context)
        {
            _dataContext = context;
        }

        public async void Delete(int id)
        {
            var deleteTarefa = new TarefaModel();
            deleteTarefa.TarefaId = id; 

            _dataContext.Tarefas.Remove(deleteTarefa);
            _dataContext.SaveChanges();
        }
        public async void Update(TarefaModel tModel)
        {
            _dataContext.Tarefas.Update(tModel);
            _dataContext.SaveChanges(); 
        }
        public async Task<int> Insert(TarefaModel tModel)
        {
            _dataContext.Tarefas.Add(tModel);
            _dataContext.SaveChanges();

            return tModel.TarefaId; 
        }
        public async Task<IList<TarefaModel>> FindAll()
        {
            var findTask = await _dataContext.Tarefas.AsNoTracking().ToListAsync();

            return findTask;
        }

        public async Task<TarefaModel> FindById(int id)
        {
            var findId = await _dataContext.Tarefas
                                           .AsNoTracking()
                                           .FirstOrDefaultAsync(i => i.TarefaId == id);

            return findId; 
        }
    }
}
