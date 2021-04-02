using UnityEngine;

public class SensoresManager 
{
    private SensorDeColetado sensorDeColetado;

    public SensoresManager(SensoresDto sensoresDto)
    {
        configurarSensorDeColetado(sensoresDto);
    }

    private void configurarSensorDeColetado(SensoresDto sensoresDto)
    {
        sensorDeColetado = new SensorDeColetado();

        DetectorDeTriggers detectorDeTrigger = sensoresDto.SensorDeColetado.GetComponent<DetectorDeTriggers>();
        detectorDeTrigger.registrarConsumidorDeTrigger(sensorDeColetado);
    }

    public ProdutorDeEvento<GameObject> getProdutorDeEventoDeColetado()
    {
        return sensorDeColetado.getProdutorDeEventoDeColetado();
    }
}
