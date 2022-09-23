public class ModalFimColetaveisFail : ModalFimColetaveis
{
    public override void configurar(ModalManipulacao modalManipulacao)
    {
        int idColetavel = PlayerPrefsColetaveis.recuperarNavegacaoColetavel();
        ColetavelEntidade coletavel = ContextoEstaticoUtils.mapaEntidade.getColetavelEntidadeByIndice(idColetavel);

        modalManipulacao.setScoreAtual("Falha ao Coletar " + coletavel.nome);
    }
}
