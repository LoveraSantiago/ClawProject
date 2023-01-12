public interface TutorialPowerUp : AcaoPowerUpAcionado.ConsumidorEvento,
                                   AcaoColetado.ProdutorEvento
{
    void iniciar();
}
