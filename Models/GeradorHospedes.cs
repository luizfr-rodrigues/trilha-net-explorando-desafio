using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioProjetoHospedagem.Models
{
    public class GeradorHospedes
    {
        
        public List<Pessoa> Hospedes { get; set; }

        public GeradorHospedes(List<Pessoa> hospedes)
        {
            Hospedes = hospedes;
        }

        public void GerarHospedes(int quantidade)
        {
            for (int i = 0; i < quantidade; i++)
            {
                AdicionarHospede();
            };
        }

        private void AdicionarHospede()
        {
            Pessoa novoHospede = new Pessoa(nome: $"Hóspede {this.Hospedes.Count + 1}");
            this.Hospedes.Add(novoHospede);         
        }
    }
}