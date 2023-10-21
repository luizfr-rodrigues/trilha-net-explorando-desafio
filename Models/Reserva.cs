namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            if (hospedes.Count <= this.Suite.Capacidade)
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new Exception("Número de hóspedes é maior que a capacidade da suíte\n" +
                                    $"Hóspedes: {hospedes.Count} Capacidade suíte: {this.Suite.Capacidade}");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            return this.Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            decimal valor = this.DiasReservados * this.Suite.ValorDiaria;

            if (VerificarSeDeveConcederDesconto())
            {
                decimal PercDescontoDiaria = 10;
                decimal valorDesconto = valor * (PercDescontoDiaria / 100);
                valor -= valorDesconto;
            }

            return valor;
        }

        private bool VerificarSeDeveConcederDesconto()
        {
          int QtdeDiasParaConcederDesconto = 10;
          return this.DiasReservados >= QtdeDiasParaConcederDesconto;
        }        

    }
}