using UnityEngine;

public class Relogio 
{
    private Transform transformSegundos;
    private Transform transformMinutos;
    private Transform transformHoras;

    private int contadorSegundosParaMinutos;
    private int contadorSegundosParaHoras;

    private ContadorDeTempo contadorTempo;

    public Relogio(Transform transformSegundos, Transform transformMinutos, Transform transformHoras)
    {
        this.transformSegundos = transformSegundos;
        this.transformMinutos = transformMinutos;
        this.transformHoras = transformHoras;

        contadorTempo = new ContadorDeTempo(1.0f);
    }

    public void updateSegundo()
    {
        bool contou1Segundo = contadorTempo.contarTempoFDT();
        if (contou1Segundo)
        {
            andarPonteiro(transformSegundos);

            contadorSegundosParaMinutos++;
            if (contadorSegundosParaMinutos == 60)
            {
                andarPonteiro(transformMinutos);
                contadorSegundosParaMinutos = 0;
            }

            contadorSegundosParaHoras++;
            if (contadorSegundosParaHoras == 3600)
            {
                andarPonteiro(transformHoras);
                contadorSegundosParaHoras = 0;
            }

            contadorTempo.resetContador();
        }
    }

    private void andarPonteiro(Transform transform)
    {
        Vector3 acrescimo = transform.rotation.eulerAngles - new Vector3(0, 0, 6);
        Quaternion rotacao = Quaternion.Euler(acrescimo);
        transform.rotation = rotacao;
    }
}
