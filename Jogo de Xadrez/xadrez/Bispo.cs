using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;

namespace Jogo_de_Xadrez.xadrez
{
    class Bispo : Peca
    {
        public Bispo(Tabuleiro tab, Cor cor) : base(cor, tab)
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
            return "B";
        }
        public override bool[,] movimentosPossiveis()
        {
            //A torre pode se mover para esquerda/direita/acima/abaixo até que chegue no final do tabuleiro
            // ou até atingir/capturar uma peça
            bool[,] mat = new bool[tab.linhas, tab.colunas];

            Posicao pos = new Posicao(0, 0);
            pos.linha = posicao.linha;

            //NE
            pos.DefinirValores(posicao.linha - 1, posicao.coluna + 1);
            while (tab.posicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != this.cor)
                {
                    break;
                }
                pos.linha--;
                pos.coluna++;
            }

            pos.DefinirValores(posicao.linha - 1, posicao.coluna - 1);
            //NO
            while (tab.posicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != this.cor)
                {
                    break;
                }
                pos.linha--;
                pos.coluna--;
            }

            pos.DefinirValores(posicao.linha + 1, posicao.coluna - 1);
            //SO
            while (tab.posicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != this.cor)
                {
                    break;
                }
                pos.linha++;
                pos.coluna--;

            }

            pos.DefinirValores(posicao.linha + 1, posicao.coluna + 1);
            //SE
            while (tab.posicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != this.cor)
                {
                    break;
                }
                pos.linha++;
                pos.coluna++;
            }

            return mat;
        }

    }
}
