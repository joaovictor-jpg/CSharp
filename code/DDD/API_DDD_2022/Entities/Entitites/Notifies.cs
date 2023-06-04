namespace Entities.Entitites
{
    internal class Notifies
    {
        public string NomePropriedade { get; set; }
        public string mensagem { get; set; }
        public List<Notifies> Notitycoes { get; set; }

        public Notifies()
        {
            Notitycoes = new List<Notifies>();
        }

        public bool ValidarPropriedadeString(string valor, string nomePropriedade)
        {
           if(string.IsNullOrWhiteSpace(valor) || string.IsNullOrWhiteSpace(nomePropriedade))
            {
                Notitycoes.Add(new Notifies
                {
                    mensagem = "Campo obrigatório",
                    NomePropriedade = nomePropriedade
                });
                return false;
            }
           return true;
        }

        public bool ValidarPropriedadeInt(int valor, string nonePropriedade)
        {
            if(valor < 1 || string.IsNullOrEmpty(nonePropriedade))
            {
                Notitycoes.Add(new Notifies
                {
                    mensagem = "Campo Obrigatório",
                    NomePropriedade = nonePropriedade
                });
                return false;
            }
            return true;
        }
    }
}
