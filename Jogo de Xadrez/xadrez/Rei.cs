using tabuleiro;

namespace xadrez
{
    class Rei : Peca
    {
        private PartidaDeXadrez partida;

        public Rei(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(cor, tab)
        {
            this.partida = partida;
        }

        public override bool[,] movimentosPossiveis()
        {
            //O Rei pode se mover para todas as direções, porém, apenas 1 posição
            bool[,] mat = new bool[tab.linhas, tab.colunas];

            Posicao pos = new Posicao(0, 0);
            pos.linha = posicao.linha;

            for (int linhas = -1; linhas <= 1 ; linhas++)
            {
                for (int colunas = -1; colunas <= 1; colunas++)
                {
                    pos.DefinirValores(posicao.linha + linhas, posicao.coluna + colunas);

                    if (tab.posicaoValida(pos) && PodeMover(pos))
                    {
                        mat[pos.linha, pos.coluna] = true;
                    }
                }

            }

            // #jogadaespecial roque

            if (qtdMovimentos == 0 && !partida.xeque)
            {
                // #jogadaespecial roque pequeno

                // Posição que a Torre tem que estar para poder fazer o roque
                Posicao posTorre1 = new Posicao(posicao.linha, posicao.coluna + 3);
                if (testeTorreParaRoque(posTorre1))
                {
                    Posicao pRei1 = new Posicao(posicao.linha, posicao.coluna + 1);
                    Posicao pRei2 = new Posicao(posicao.linha, posicao.coluna + 2);

                    if (tab.peca(pRei1) == null && tab.peca(pRei2) == null)
                    {
                        mat[posicao.linha, posicao.coluna + 2] = true;
                    }

                }

                // #jogadaespecial roque grande

                // Posição que a Torre tem que estar para poder fazer o roque
                Posicao posTorre2 = new Posicao(posicao.linha, posicao.coluna - 4);
                if (testeTorreParaRoque(posTorre2))
                {
                    Posicao pRei1 = new Posicao(posicao.linha, posicao.coluna - 1);
                    Posicao pRei2 = new Posicao(posicao.linha, posicao.coluna - 2);
                    Posicao pRei3 = new Posicao(posicao.linha, posicao.coluna - 3);

                    if (tab.peca(pRei1) == null && tab.peca(pRei2) == null && tab.peca(pRei3) == null)
                    {
                        mat[posicao.linha, posicao.coluna - 2] = true;
                    }

                }
            }

            return mat;
        }

        private bool testeTorreParaRoque(Posicao pos)
        {
            Peca p = tab.peca(pos);

            return p != null && p is Torre && p.cor == cor && p.qtdMovimentos == 0;
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
            return "R";
        }
    }
}
