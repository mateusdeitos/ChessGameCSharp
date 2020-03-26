using tabuleiro;

namespace xadrez
{
    class Rei : Peca
    {
        public Rei(Tabuleiro tab, Cor cor) : base(cor, tab)
        {

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
            return "R";
        }
    }
}
