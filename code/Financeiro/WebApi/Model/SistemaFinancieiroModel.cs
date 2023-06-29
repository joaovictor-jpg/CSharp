namespace WebApi.Model
{
    public class SistemaFinancieiroModelModel
    {
        public string nome { get; set; }
        public int mes { get; set; }
        public int ano { get; set; }
        public int diaFechamento { get; set; }
        public bool gerarCopiaDespesa { get; set; }
        public int copiaMes { get; set; }
        public int copiaAno { get; set; }
    }
}
