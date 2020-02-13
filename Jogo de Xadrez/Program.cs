using System;
using tabuleiro;
using xadrez;

namespace Jogo_de_Xadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.terminada)
                {
                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.tab);

                    Console.WriteLine();

                    Console.Write("Origem: ");

                    Posicao origem = Tela.LerPosicaoXadrez().toPosicao();

                    Console.Write("Destino: ");

                    Posicao destino = Tela.LerPosicaoXadrez().toPosicao();

                    partida.executaMovimento(origem, destino);

                }


                Tela.ImprimirTabuleiro(partida.tab);
            }
            catch (TabuleiroException e)
            {

                Console.WriteLine(e.Message);
            }



        }
    }
}
