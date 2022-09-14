public class ModalFimColetaveis : AbstractModalFim
{
    public override void configurar(ModalManipulacao modalManipulacao)
    {
        int idColetavel = PlayerPrefsColetaveis.recuperarNavegacaoColetavel();
        ColetavelEntidade coletavel = ContextoEstaticoUtils.mapaEntidade.getColetavelEntidadeByIndice(idColetavel);

        modalManipulacao.setScoreAtual("Coletou " + coletavel.nome);
        PlayerPrefsColetaveis.disponibilizarColetavel(coletavel.nome);
    }

    protected override void irParaCena()
    {
        CenaUtils.irParaCenaColetaveis();
    }
}
