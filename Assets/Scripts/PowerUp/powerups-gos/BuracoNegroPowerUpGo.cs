using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuracoNegroPowerUpGo : PowerUpSemInteracao
{
    public Coletavel atraido1;
    public Coletavel atraido2;
    public Coletavel atraido3;

    public BuracoNegroPowerUpGo() : 
        base(powerUpDto.BuracoNegroDto.BuracoNegroGo, "Buraco Negro"){}

    public override void configurarPup()
    {
        Transform transform = goColetavel.transform.Find("atraido1").transform;
        atraido1 = new Coletavel(transform.gameObject, "atraido1");

        Transform transform2 = goColetavel.transform.Find("atraido2").transform;
        atraido2 = new Coletavel(transform2.gameObject, "atraido2");

        Transform transform3 = goColetavel.transform.Find("atraido3").transform;
        atraido3 = new Coletavel(transform3.gameObject, "atraido3");
    }

    public override void iniciarPup()
    {
        ligar();
    }

    public override void resetPup()
    {
        atraido1.desligar();
        atraido2.desligar();
        atraido3.desligar();
    }
}
