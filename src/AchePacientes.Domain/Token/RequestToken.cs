namespace AchePacientes.Domain.Token
{
    public class RequestToken
    {
        public int Id { get; set; }

        public Guid RequestId { get; set; }

        public string NomeCompleto { get; set; }

        public string TelefoneRegiao { get; set; }

        public string Telefone { get; set; }

        public DateTime Created { get; set; }

        public DateTime? Validated { get; set; }

        public string Token { get; set; }

        public RequestToken()
        {

        }

        public RequestToken(Guid requestId, string nome, string telefoneRegiao,  string telefone, DateTime created)
        {
            RequestId = requestId;
            NomeCompleto = nome;
            TelefoneRegiao = telefoneRegiao;
            Telefone = telefone;
            Created = created;
            Token = GetToken();
        }
        private string GetToken()
        {
            Random rand = new Random();
            int on = rand.Next(0, 9);
            int tw = rand.Next(0, 9);
            int tr = rand.Next(0, 9);
            int fo = rand.Next(0, 9);

            return on.ToString() + tw.ToString() + tr.ToString() + fo.ToString();
        }
    }
}
