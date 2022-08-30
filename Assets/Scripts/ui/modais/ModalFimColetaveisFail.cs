public class ModalFimColetaveisFail : ModalFimColetaveis
{
    public override void configurar(ModalManipulacao modalManipulacao)
    {
        int idColetavel = PlayerPrefsColetaveis.recuperarNavegacaoColetavel();        
        ColetavelEntidade coletavel = HelperColetavelEntidade.getColetavelEntidadeById(idColetavel);

        modalManipulacao.setScoreAtual("Falha ao Coletar " + coletavel.nome);
    }
}
