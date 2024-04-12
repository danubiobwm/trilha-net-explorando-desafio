using System;
using System.Collections.Generic;

namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; private set; }
        public Suite Suite { get; private set; }
        public int DiasReservados { get; set; }

        public Reserva()
        {
            Hospedes = new List<Pessoa>();
        }

        public Reserva(Pessoa hospede, Suite suite, int diasReservados) : this()
        {
            if (suite.Capacidade < 1)
                throw new ArgumentException("Suíte sem capacidade.");

            Suite = suite;
            Hospedes.Add(hospede);
            DiasReservados = diasReservados;
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            Hospedes.AddRange(hospedes);
        }

        public int ObterQuantidadeHospedes()
        {
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            decimal valorTotal = DiasReservados * Suite.ValorDiaria;
            if (DiasReservados >= 10)
            {
                valorTotal *= 0.9m;
            }
            return valorTotal;
        }
    }
}
