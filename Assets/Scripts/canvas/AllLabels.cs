public class AllLabels : AcaoPUpEntidade.ConsumidorEvento
{
    private AllLabelsDto labelsDto;

    public AllLabels(AllLabelsDto labelsDto)
    {
        this.labelsDto = labelsDto;
    }

    void AcaoPUpEntidade.ConsumidorEvento.consumirEvento(PowerUpEntidade evento)
    {
        labelsDto.LblPup.text = evento.name.ToString();
    }
}
