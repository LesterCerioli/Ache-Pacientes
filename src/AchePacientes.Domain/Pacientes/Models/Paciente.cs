using AchePacientes.Domain.Pacientes.ValueObjects;
using NetDevPack.Domain;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace AchePacientes.Domain.Pacientes.Models
{
    public class Paciente : Entity, IAggregateRoot
    {
        public Paciente(Nome nome, string telefoneMumero, Cpf cpf, string telefoneRegiao, bool accetptComm, bool acceptTerm, DateTime dataNascimento)
        {
            Nome = nome;
            TelefoneNumero = telefoneMumero;
            Cpf = cpf;
            TelefoneRegiao = telefoneRegiao;
            AceitouComunicacao = accetptComm;
            AceitouTermo = acceptTerm;
            DataLog = new DataLog(DateTime.Now, null);
            DataNascimento = dataNascimento;
        }

        public Paciente() { }
        
        public Nome Nome { get; private set; }

        [Required(ErrorMessage = "O preenchimento do telefone é obrigatório")]
        [MinLength(10)]
        public string TelefoneNumero { get; private set; }

        public string TelefoneRegiao { get; private set; }
        
        public bool AceitouComunicacao { get; private set; }
        
        public bool AceitouTermo { get; private set; }

        public Cpf Cpf { get; private set; }

        public DateTime? DataNascimento { get; private set; }

        public DataLog DataLog { get; private set; }

        

        public static bool ValidarTelefone(string telefone)
        {
            string shortenNum = Regex.Replace(telefone, @"[^0-9a-zA-Z]+", "");

            if (telefone.Length == 13)
            {
                Console.WriteLine("O número de telefone é válido");
                return true;
            }

            else
            {
                Console.Write("O número de telefone é inválido");
                return false;
            }
        }

        
    }

}

