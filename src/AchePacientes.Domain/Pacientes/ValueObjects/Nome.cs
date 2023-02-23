using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AchePacientes.Domain.Pacientes.ValueObjects
{
    public class Nome : ValueObject
    {
        public Nome(string nomeCompleto)
        {
            NomeCompleto = nomeCompleto;
            if (string.IsNullOrEmpty(nomeCompleto))
            {
                throw new Exception("O NOME deve ser informado");
            }
        }

        [Required(ErrorMessage = "O preenchimento do NOME é obrigatório")]
        [MinLength(8)]
        [MaxLength(40)]
        public string NomeCompleto { get; protected set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}
