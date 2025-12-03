using CBTPRDM_PROVA_02.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Desenvolvido por Beatriz Bastos Borges e Miguel Luizatto Alves

namespace CBTPRDM_PROVA_02.Repositories
{
    public class LivroRepository
    {
        SQLiteAsyncConnection Database;

        private async Task Init()
        {
            if (Database != null)
                return;

            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);

            var result = await Database.CreateTableAsync<Livro>();
        }

        public async Task<int> SaveLivroAsync(Livro livro)
        {
            await Init();
            if(livro.Id != 0)
                return await Database.UpdateAsync(livro);
            else
                return await Database.InsertAsync(livro);
        }

        public async Task<List<Livro>> GetLivrosAsync()
        {
            await Init();
            return await Database.Table<Livro>().ToListAsync();
        }

        public async Task<Livro> GetLivroByIdAsync(int id)
        {
            await Init();
            return await Database.Table<Livro>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> DeleteLivroAsync(Livro item)
        {
            await Init();
            return await Database.DeleteAsync(item);
        }
    }
}
