using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;

namespace Jogo_de_Xadrez.xadrez
{
    class Cavalo : Peca
    {
        public Cavalo(Tabuleiro tab, Cor cor) : base(cor, tab)
        {
        }

        private bool PodeMover(Posicao pos)
        {
            Peca p = tab.peca(pos);

            if (p == null || p.cor != cor)
            {
                return true;
            }
            return false;
        }
        public override string ToString()
        {
            return "C";
        }


        public override bool[,] movimentosPossiveis()
        {
            //A torre pode se mover para esquerda/direita/acima/abaixo até que chegue no final do tabuleiro
            // ou até atingir/capturar uma peça
            bool[,] mat = new bool[tab.linhas, tab.colunas];

            Posicao pos = new Posicao(0, 0);
            pos.linha = posicao.linha;


            for (int linhas = -2; linhas <= 2; linhas++)
            {
                for (int colunas = -2; colunas <= 2; colunas++)
                {
                    pos.DefinirValores(posicao.linha + linhas, posicao.coluna + colunas);

                    if (tab.posicaoValida(pos) && PodeMover(pos))
                    {
                        mat[pos.linha, pos.coluna] = true;
                    }
                }

            }

            return mat;
        }

    }
}
