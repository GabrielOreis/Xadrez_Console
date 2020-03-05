using System;
using tabuleiro;
using xadrez;

namespace Xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.Terminada)
                {
                    try
                    {
                        Console.Clear();
                        Tela.imprimirTabuleirio(partida.Tab);

                        Console.WriteLine("\nTurno: " + partida.Turno);
                        Console.WriteLine("Aguardando jogada: " + partida.JogadorAtual);

                        Console.Write("\nOrigem: ");
                        Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
                        partida.validarPosicaoDeOrigem(origem);

                        bool[,] posicoesPossiveis = partida.Tab.peca(origem).movimentosPossiveis();

                        Console.Clear();
                        Tela.imprimirTabuleirio(partida.Tab, posicoesPossiveis);

                        Console.Write("\nDestino: ");
                        Posicao destino = Tela.lerPosicaoXadrez().toPosicao();
                        partida.validarPosicaoDeDestino(origem,destino);

                        partida.realizaJogada(origem, destino);
                    }
                    catch(TabuleiroException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }

                }
            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
            /*
            PosicaoXadrez pos = new PosicaoXadrez('c',7);

            Console.WriteLine(pos);
            Console.WriteLine(pos.toPosicao());
            */

            Console.ReadLine();

        }
    }
}
