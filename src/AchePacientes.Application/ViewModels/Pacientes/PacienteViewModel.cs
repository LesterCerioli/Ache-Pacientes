using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AchePacientes.Application.ViewModels.Pacientes
{
    public class PacienteViewModel
    {

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O preenchimento do NOME é obrigatório")]
        [MinLength(8)]
        [MaxLength(40)]
        [DisplayName("Nome")]
        public string NomeCompleto { get; set; }

        [Required(ErrorMessage = "O preenchimento do telefone é obrigatório")]
        [MinLength(10)]
        [DisplayName("Telefone")]
        public string TelefoneMumero { get; set; }

        [Required(ErrorMessage = "O preenchimento do CPF é obrigatório")]
        [MinLength(11)]
        [DisplayName("CPF")]
        public string CpfNumero { get; private set; }

        [Required(ErrorMessage = "A data de nascimento é obrigatório")]
        [DisplayName("DataNascimento")]
        public string DataNascimento { get; private set; }


    }
}
