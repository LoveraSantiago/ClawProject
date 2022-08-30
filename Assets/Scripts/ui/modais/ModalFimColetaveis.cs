public class ModalFimColetaveis : AbstractModalFim
{
    public override void configurar(ModalManipulacao modalManipulacao)
    {
        int idColetavel = PlayerPrefsColetaveis.recuperarNavegacaoColetavel();        
        ColetavelEntidade coletavel = HelperColetavelEntidade.getColetavelEntidadeById(idColetavel);

        modalManipulacao.setScoreAtual("Coletou " + coletavel.nome);
        PlayerPrefsColetaveis.disponibilizarColetavel(coletavel.nome);
    }

    protected override void irParaCena()
    {
        CenaUtils.irParaCenaColetaveis();
    }
}
