﻿using tabuleiro;

namespace xadrez {
    class Rei : Peca {
        private PartidaDeXadrez partida;
        public Rei(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(tab, cor) {
            this.partida = partida;
        }

        public override string ToString() {
            return "R";
        }

        private bool podeMover(Posicao pos) {
            Peca p = tab.peca(pos);
            return p == null || p.cor != this.cor;
        }

        private bool testeTorreParaRoque(Posicao pos) {
            Peca p = tab.peca(pos);
            return p != null && p is Torre && p.cor == this.cor && p.qtdeMovimentos == 0;
        }

        public override bool[,] movimentosPossiveis() {
            bool[,] matrix = new bool[tab.linhas, tab.colunas];

            Posicao pos = new Posicao(0, 0);

            // acima
            pos.definirValores(posicao.linha - 1, posicao.coluna);
            if (tab.posicaoValida(pos) && podeMover(pos)) {
                matrix[pos.linha, pos.coluna] = true;
            }

            // ne
            pos.definirValores(posicao.linha - 1, posicao.coluna + 1);
            if (tab.posicaoValida(pos) && podeMover(pos)) {
                matrix[pos.linha, pos.coluna] = true;
            }

            // direita
            pos.definirValores(posicao.linha, posicao.coluna + 1);
            if (tab.posicaoValida(pos) && podeMover(pos)) {
                matrix[pos.linha, pos.coluna] = true;
            }

            // se
            pos.definirValores(posicao.linha + 1, posicao.coluna + 1);
            if (tab.posicaoValida(pos) && podeMover(pos)) {
                matrix[pos.linha, pos.coluna] = true;
            }

            // abaixo
            pos.definirValores(posicao.linha + 1, posicao.coluna);
            if (tab.posicaoValida(pos) && podeMover(pos)) {
                matrix[pos.linha, pos.coluna] = true;
            }

            // so
            pos.definirValores(posicao.linha + 1, posicao.coluna - 1);
            if (tab.posicaoValida(pos) && podeMover(pos)) {
                matrix[pos.linha, pos.coluna] = true;
            }

            // esquerda
            pos.definirValores(posicao.linha, posicao.coluna - 1);
            if (tab.posicaoValida(pos) && podeMover(pos)) {
                matrix[pos.linha, pos.coluna] = true;
            }

            // no
            pos.definirValores(posicao.linha - 1, posicao.coluna - 1);
            if (tab.posicaoValida(pos) && podeMover(pos)) {
                matrix[pos.linha, pos.coluna] = true;
            }

            // #jogada especial roque
            if (qtdeMovimentos == 0 && !partida.xeque) {
                // #jogada especial roque pequeno
                Posicao posTorreDireita = new Posicao(posicao.linha, posicao.coluna + 3);

            }

            return matrix;
        }
    }
}
