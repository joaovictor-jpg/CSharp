using System.ComponentModel.DataAnnotations.Schema;

namespace Entitites.Entities
{
    public class Notifies
    {
        [NotMapped]
        public string NomePropiedade { get; set; }
        [NotMapped]
        public string mensagem { get; set; }
        [NotMapped]
        public List<Notifies> Notitycoes { get; set; }

        public Notifies()
        {
            Notitycoes = new List<Notifies>();
        }

        public bool ValidarPropriedadeString(string valor, string nomePropriedade)
        {
            if(string.IsNullOrWhiteSpace(valor) || string.IsNullOrWhiteSpace(nomePropriedade)) {
                Notitycoes.Add(new Notifies
                {
                    mensagem = "Campo Obrigatório",
                    NomePropiedade = nomePropriedade
                });
                return false;
            }
            return true;
        }

        public bool ValidarPropriedadeInt(int valor, string nomePropriedade)
        {
            if (valor < 1 || string.IsNullOrWhiteSpace(nomePropriedade))
            {
                Notitycoes.Add(new Notifies
                {
                    mensagem = "Campo Obrigatório",
                    NomePropiedade = nomePropriedade
                });
                return false;
            }
            return true;
        }
    }
}
