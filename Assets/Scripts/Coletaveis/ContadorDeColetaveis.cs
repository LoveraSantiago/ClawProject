using UnityEngine;

public class ContadorDeColetaveis {
    private int qtdColetados = 0;
    private Sprite[] spritesDeColetados = new Sprite[3];


    private ColetavelCallback callback;


    public ContadorDeColetaveis(ColetavelCallback callback) {
        this.callback = callback;
    }

    public void adicionarColetado(Sprite coletado) {
        adicionaAoContainerDeColetados(coletado);

        if (qtdColetados > spritesDeColetados.Length - 1) {
            if (isCombinacaoValida()) {
                AudioController.current.PlayAudio(AudioController.current.combinacaoOk);
                adicionaPontuacao();
            } else {
                AudioController.current.PlayAudio(AudioController.current.combinacaoNok);
                retornaObjetosParaBoard();
            }

            resetarColetados();
        }

    }

    public int getQtdColetados() {
        return qtdColetados;
    }

    private bool isCombinacaoValida() {
        Sprite primeiroSprite = spritesDeColetados[0];
        for (int i = 0; i < spritesDeColetados.Length; i++) {
            if (primeiroSprite != spritesDeColetados[i]) {
                return false;
            }
        }
        return true;
    }

    private void adicionaAoContainerDeColetados(Sprite coletado) {
        spritesDeColetados[qtdColetados] = coletado;
        qtdColetados++;
    }

    private void retornaObjetosParaBoard() {
        if (callback != null) {
            callback.match(false);
        }
    }

    private void adicionaPontuacao() {
        if (callback != null) {
            callback.match(true);
        }
    }

    private void resetarColetados() {
        qtdColetados = 0;
    }

    public interface ColetavelCallback {
        void match(bool result);
    }
}
