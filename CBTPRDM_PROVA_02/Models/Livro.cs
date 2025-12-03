using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBTPRDM_PROVA_02.Models
{
    public class Livro
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string NomeLivro { get; set; }
        public string NomeAutor { get; set; }
        public string EmailAutor { get; set; }
        public string ISBN { get; set; }
    }
}
