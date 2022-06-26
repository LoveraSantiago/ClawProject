using UnityEngine;

public class FichaAnimada : AcaoBotaoPowerUpEscolhido.ConsumidorEvento
{
    private static readonly int FICHA_GIRANDO = Animator.StringToHash("ficha-girando");
    private FichaAnimadaDto fichaAnimadaDto;

    public FichaAnimada(FichaAnimadaDto fichaAnimadaDto)
    {
        this.fichaAnimadaDto = fichaAnimadaDto;
    }

    public void girarFicha(int indiceBtn)
    {
        Transform posBtnEscolhido = fichaAnimadaDto.PosFichas[indiceBtn];        

        fichaAnimadaDto.AnimatorFicha.gameObject.transform.position = posBtnEscolhido.position;
        fichaAnimadaDto.AnimatorFicha.gameObject.SetActive(true);
        fichaAnimadaDto.AnimatorFicha.Play(FICHA_GIRANDO);
    }

    void AcaoBotaoPowerUpEscolhido.ConsumidorEvento.consumirEvento(int evento)
    {
        girarFicha(evento);
    }
}
