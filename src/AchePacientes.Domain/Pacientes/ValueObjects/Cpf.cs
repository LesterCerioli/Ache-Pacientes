using NetDevPack.Domain;

namespace AchePacientes.Domain.Pacientes.ValueObjects
{
    public class Cpf : ValueObject
    {
        private string _cpfNumero;

        public Cpf(string cpfNumero)
        {
            if (!IsValid(cpfNumero))
                throw new Exception("Número de CPF Inválido");


            _cpfNumero = cpfNumero;
        }

        public Cpf()
        {
        }

        public string CPFNumero
        {
            get { return _cpfNumero; }
            set { _cpfNumero = value; }
        }

        private bool IsValid(string cpfNumero)
        {
            //Validação do CPF
            if (string.IsNullOrWhiteSpace(cpfNumero))
                return false;

            cpfNumero = cpfNumero.Trim().Replace(".", "").Replace("-", "");

            if (cpfNumero.Length != 11)
                return false;

            if (cpfNumero == "00000000000" || cpfNumero == "11111111111" || cpfNumero == "22222222222" || cpfNumero == "33333333333" || cpfNumero == "44444444444" || cpfNumero == "55555555555" || cpfNumero == "66666666666" || cpfNumero == "77777777777" || cpfNumero == "88888888888" || cpfNumero == "99999999999")
                return false;

            var sum = 0;
            var rest = 0;
            for (var i = 1; i <= 9; i++)
                sum = sum + int.Parse(cpfNumero[i - 1].ToString()) * (11 - i);
            rest = (sum * 10) % 11;

            if ((rest == 10) || (rest == 11))
                rest = 0;
            if (rest != int.Parse(cpfNumero[9].ToString()))
                return false;

            sum = 0;
            for (var i = 1; i <= 10; i++)
                sum = sum + int.Parse(cpfNumero[i - 1].ToString()) * (12 - i);
            rest = (sum * 10) % 11;

            if ((rest == 10) || (rest == 11))
                rest = 0;
            if (rest != int.Parse(cpfNumero[10].ToString()))
                return false;

            return true;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}
