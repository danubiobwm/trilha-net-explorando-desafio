using System;
using System.Collections.Generic;
using System.Text;
using DesafioProjetoHospedagem.Models;

namespace DesafioProjetoHospedagem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            List<Reserva> reservas = new List<Reserva>();

            bool sair = false;
            while (!sair)
            {
                Console.WriteLine("=== Menu de Cadastro de Reservas ===");
                Console.WriteLine("1. Cadastrar uma nova reserva");
                Console.WriteLine("2. Alterar uma reserva existente");
                Console.WriteLine("3. Excluir uma reserva");
                Console.WriteLine("4. Listar todas as reservas");
                Console.WriteLine("5. Sair");
                Console.Write("Escolha uma opção: ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        CadastrarReserva(reservas);
                        break;
                    case "2":
                        AlterarReserva(reservas);
                        break;
                    case "3":
                        ExcluirReserva(reservas);
                        break;
                    case "4":
                        ListarReservas(reservas);
                        break;
                    case "5":
                        sair = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida! Tente novamente.");
                        break;
                }
            }
        }

        static void CadastrarReserva(List<Reserva> reservas)
        {
            Console.WriteLine("Cadastro de Nova Reserva:");

            Console.Write("Nome do Hóspede: ");
            string nomeHospede = Console.ReadLine();

            Console.Write("Tipo de Suíte: ");
            string tipoSuite = Console.ReadLine();

            Console.Write("Capacidade da Suíte: ");
            int capacidadeSuite = Convert.ToInt32(Console.ReadLine());

            Console.Write("Valor da Diária: ");
            decimal valorDiaria = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Número de Dias Reservados: ");
            int diasReservados = Convert.ToInt32(Console.ReadLine());

            Pessoa hospede = new Pessoa(nomeHospede);
            Suite suite = new Suite(tipoSuite, capacidadeSuite, valorDiaria);
            Reserva novaReserva = new Reserva();
            novaReserva.CadastrarHospedes(new List<Pessoa>() { hospede });
            novaReserva.CadastrarSuite(suite);
            novaReserva.DiasReservados = diasReservados;
            reservas.Add(novaReserva);

            Console.WriteLine("Reserva cadastrada com sucesso!");
        }

        static void AlterarReserva(List<Reserva> reservas)
        {
            Console.WriteLine("Alteração de Reserva:");

            ListarReservas(reservas);

            Console.Write("Informe o índice da reserva a ser alterada: ");
            int indiceReserva = Convert.ToInt32(Console.ReadLine());

            indiceReserva--;

            if (indiceReserva >= 0 && indiceReserva < reservas.Count)
            {
                Console.WriteLine("Informe os novos dados da reserva:");

                Console.Write("Número de Dias Reservados: ");
                int novosDiasReservados = Convert.ToInt32(Console.ReadLine());

                reservas[indiceReserva].DiasReservados = novosDiasReservados;

                Console.WriteLine("Reserva alterada com sucesso!");
            }
            else
            {
                Console.WriteLine("Índice de reserva inválido!");
            }
        }

        static void ExcluirReserva(List<Reserva> reservas)
        {
            Console.WriteLine("Exclusão de Reserva:");

            ListarReservas(reservas);

            Console.Write("Informe o índice da reserva a ser excluída: ");
            int indiceReserva = Convert.ToInt32(Console.ReadLine());

            indiceReserva--;

            if (indiceReserva >= 0 && indiceReserva < reservas.Count)
            {
                reservas.RemoveAt(indiceReserva);
                Console.WriteLine("Reserva excluída com sucesso!");

                ListarReservas(reservas);
            }
            else
            {
                Console.WriteLine("Índice de reserva inválido!");
            }
        }

        static void ListarReservas(List<Reserva> reservas)
        {
            Console.WriteLine("Lista de Reservas:");

            for (int i = 0; i < reservas.Count; i++)
            {
                Console.WriteLine($"Reserva {i + 1}:");
                Console.WriteLine($"Hóspede: {reservas[i].Hospedes[0].Nome}");
                Console.WriteLine($"Tipo de Suíte: {reservas[i].Suite.TipoSuite}");
                Console.WriteLine($"Dias Reservados: {reservas[i].DiasReservados}");
                Console.WriteLine($"Valor Total: {reservas[i].CalcularValorDiaria()}");
                Console.WriteLine();
            }
        }
    }
}
