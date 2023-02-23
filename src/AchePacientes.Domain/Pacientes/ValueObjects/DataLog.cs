using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AchePacientes.Domain.Pacientes.ValueObjects
{
    public class DataLog : ValueObject
    {
        public DataLog(DateTime dataCriacao, DateTime? dataAtualizacao)
        {
            DataCriacao = dataCriacao;
            DataAtualizacao = dataAtualizacao;
        }

        public DateTime DataCriacao { get; private set; }

        public DateTime? DataAtualizacao { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}
