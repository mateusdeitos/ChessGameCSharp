using tabuleiro;

namespace xadrez
{
    class Torre : Peca
    {
        public Torre(Tabuleiro tab, Cor cor) : base(cor, tab)
        {

        }
        public override bool[,] movimentosPossiveis()
        {
            //A torre pode se mover para esquerda/direita/acima/abaixo até que chegue no final do tabuleiro
            // ou até atingir/capturar uma peça
            bool[,] mat = new bool[tab.linhas, tab.colunas];

            Posicao pos = new Posicao(0, 0);
            pos.linha = posicao.linha;

            //acima
            pos.DefinirValores(posicao.linha - 1, posicao.coluna);
            while (tab.posicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != this.cor)
                {
                    break;
                }
                pos.linha--;
            }

            pos.DefinirValores(posicao.linha + 1, posicao.coluna);
            //abaixo
            while (tab.posicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != this.cor)
                {
                    break;
                }
                pos.linha++;
            }

            pos.DefinirValores(posicao.linha, posicao.coluna - 1);
            //esquerda
            while (tab.posicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != this.cor)
                {
                    break;
                }
                pos.coluna--;
            }

            pos.DefinirValores(posicao.linha, posicao.coluna + 1);
            //direita
            while (tab.posicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != this.cor)
                {
                    break;
                }
                pos.coluna++;
            }

            return mat;
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
            return "T";
        }
    }
}
