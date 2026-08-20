namespace Customer.Domain.Shared
{
    public class DefaultResult
    {
        public DefaultResult(){}
        public DefaultResult(bool sucesso, string mensagem, string identificador)
        {
            Sucess = sucesso;
            Mensagem = mensagem;
            Identificador = identificador;
        }

        public bool Sucess { get; set; }
        public string Mensagem { get; set; }
        public string Identificador { get; set; }

    }
}
