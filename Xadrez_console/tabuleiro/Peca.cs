﻿
namespace tabuleiro
{
    abstract class Peca
    {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QteMovimentos { get; protected set; }
        public Tabuleiro Tab { get ;protected set; }

        public Peca( Cor cor, Tabuleiro tab)
        {
            Posicao = null;
            Cor = cor;
            Tab = tab;
            QteMovimentos = 0;
        }

        public abstract bool[,] movimentosPossiveis();

        public bool existeMovimentosPossiveis()
        {
            bool[,] mat = movimentosPossiveis();
            for (int i = 0; i<Tab.Linhas; i++)
            {
                for (int j = 0; j< Tab.Colunas;j++)
                {
                    if(mat[i,j] )
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool podeMoverPara(Posicao pos)
        {
            return movimentosPossiveis()[pos.Linha,pos.Coluna];
        }

        public void incrementarQteMovimentos()
        {
            QteMovimentos++;
        }

        public void decrementarQteMovimentos()
        {
            QteMovimentos--;
        }
    }
}
