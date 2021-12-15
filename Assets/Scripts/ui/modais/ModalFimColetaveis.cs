using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModalFimColetaveis : AbstractModalFim
{
    public override void configurar(ModalManipulacao modalManipulacao)
    {
        int idColetavel = PlayerPrefsColetaveis.recuperarNavegacaoColetavel();
        HelperColetavelEntidade helperColetaveis = new HelperColetavelEntidade();
        ColetavelEntidade coletavel = helperColetaveis.getColetavelEntidadeById(idColetavel);

        modalManipulacao.setScoreAtual("Coletou " + coletavel.nome);
        PlayerPrefsColetaveis.disponibilizarColetavel(coletavel.nome);
    }

    protected override void irParaCena()
    {
        CenaUtils.irParaCenaColetaveis();
    }
}
