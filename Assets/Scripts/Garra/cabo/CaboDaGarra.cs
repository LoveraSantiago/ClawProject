using System.Collections.Generic;
using UnityEngine;

public class CaboDaGarra 
{
    private CaboGarraDto caboDto;
    private Transform posicaoGarra;

    private List<SegmentoCabo> ropeSegments;
    private Vector3 ropeStartPoint;

    public CaboDaGarra(CaboGarraDto caboGarraDto, Transform posicaoGarra)
    {
        this.caboDto = caboGarraDto;
        this.posicaoGarra = posicaoGarra;

        ropeSegments = new List<SegmentoCabo>();
    }

    public void start()
    {
        definirGrossuraDoCabo();

        Vector3[] ropePositions = new Vector3[caboDto.LineRenderer.positionCount];
        caboDto.LineRenderer.GetPositions(ropePositions);

        for(int contador = 0; contador < ropePositions.Length; contador++)
        {
            ropeSegments.Add(new SegmentoCabo(ropePositions[contador]));            
        }
    }

    public void update()
    {
        desenharCabo();
    }

    public void fixedUpdate()
    {
        simularGravidade();
    }

    private void definirGrossuraDoCabo()
    {
        caboDto.LineRenderer.startWidth = caboDto.GrossuraLinha;
        caboDto.LineRenderer.endWidth   = caboDto.GrossuraLinha;
    }

    private void desenharCabo()
    {
        Vector3[] ropePositions = new Vector3[ropeSegments.Count];
        for (int i = 0; i < ropePositions.Length; i++)
        {
            ropePositions[i] = ropeSegments[i].posNow;
        }

        caboDto.LineRenderer.positionCount = ropePositions.Length;
        caboDto.LineRenderer.SetPositions(ropePositions);
    }

    private void simularGravidade()
    {
        Vector2 forceGravity = new Vector2(0f, -1f);
        for (int i = 0; i < ropeSegments.Count; i++)
        {
            SegmentoCabo firstSegment = ropeSegments[i];
            Vector2 velocity = firstSegment.posNow - firstSegment.posOld;
            firstSegment.setPosOld(firstSegment.posNow);
            firstSegment.addPosNow(velocity);
            firstSegment.addPosNow(forceGravity * Time.fixedDeltaTime);
            ropeSegments[i] = firstSegment;
        }

        esticarSegmentos();
    }

    private void esticarSegmentos()
    {
        SegmentoCabo firstSegment = ropeSegments[0];
        firstSegment.setPosNow(caboDto.TransfInicioCabo.position);
        ropeSegments[0] = firstSegment;

        SegmentoCabo.limiteMaxX = posicaoGarra.position.x;
        SegmentoCabo endSegment = ropeSegments[ropeSegments.Count - 1];
        Vector3 posicao = posicaoGarra.position;
        //posicao.y = posYInicial;
        endSegment.setPosNow(posicao);

        ropeSegments[ropeSegments.Count - 1] = endSegment;

        for (int i = 0; i < ropeSegments.Count - 1; i++)
        {
            SegmentoCabo firstSeg = this.ropeSegments[i];
            SegmentoCabo secondSeg = this.ropeSegments[i + 1];

            float dist = (firstSeg.posNow - secondSeg.posNow).magnitude;
            float error = Mathf.Abs(dist - caboDto.TamanhoSegmento);
            Vector2 changeDir = Vector2.zero;

            if (dist > caboDto.TamanhoSegmento)
            {
                changeDir = (firstSeg.posNow - secondSeg.posNow).normalized;
            }
            else if (dist < caboDto.TamanhoSegmento)
            {
                changeDir = (secondSeg.posNow - firstSeg.posNow).normalized;
            }

            Vector2 changeAmount = changeDir * error;
            if (i != 0)
            {
                firstSeg.subPosNow(changeAmount * 0.5f);
                this.ropeSegments[i] = firstSeg;
                secondSeg.addPosNow(changeAmount * 0.5f);
                this.ropeSegments[i + 1] = secondSeg;
            }
            else
            {
                secondSeg.addPosNow(changeAmount);
                this.ropeSegments[i + 1] = secondSeg;
            }
        }
    }
}
