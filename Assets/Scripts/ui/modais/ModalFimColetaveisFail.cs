public class ModalFimColetaveisFail : ModalFimColetaveis
{
    public override void configurar(ModalManipulacao modalManipulacao)
    {
        int idColetavel = PlayerPrefsColetaveis.recuperarNavegacaoColetavel();
        HelperColetavelEntidade helperColetaveis = new HelperColetavelEntidade();
        ColetavelEntidade coletavel = helperColetaveis.getColetavelEntidadeById(idColetavel);

        modalManipulacao.setScoreAtual("Falha ao Coletar " + coletavel.nome);
    }
}
