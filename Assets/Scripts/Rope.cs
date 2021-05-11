using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    public Transform tranfFinal;

    private LineRenderer lineRenderer;
    private List<RopeSegment> ropeSegments = new List<RopeSegment>();
    private float ropeSegLen = 0.15f;
    private int segmentLenght = 20;

    //private float ropeSegLen = 0.5f;
    //private int segmentLenght = 10;
    
    private float lineWidth = 0.1f;

    //private Vector3 ropeStartPoint;
    //float posYInicial;

    void Start()
    {
        this.lineRenderer = this.GetComponent<LineRenderer>();
        //posYInicial = tranfFinal.position.y;
        definirGrossuraDoCabo();

        //ropeStartPoint = this.transform.position;

        Vector3[] ropePositions = new Vector3[this.segmentLenght];
        lineRenderer.GetPositions(ropePositions);

        for (int i = 0; i < segmentLenght; i++)
        {
            this.ropeSegments.Add(new RopeSegment(ropePositions[i]));
          //  ropeStartPoint.y -= ropeSegLen;
        }
    }

    private void definirGrossuraDoCabo()
    {        
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
    }

    // Update is called once per frame
    void Update()
    {
        this.drawRope();   
    }

    private void FixedUpdate()
    {
        simulate();
    }

    private void simulate()
    {
        Vector2 forceGravity = new Vector2(0f, -1f);
        for(int i = 0; i < this.segmentLenght; i++)
        {
            RopeSegment firstSegment = this.ropeSegments[i];
            Vector2 velocity = firstSegment.posNow - firstSegment.posOld;
            firstSegment.setPosOld(firstSegment.posNow);
            firstSegment.addPosNow(velocity);
            firstSegment.addPosNow(forceGravity * Time.fixedDeltaTime);
            this.ropeSegments[i] = firstSegment;
        }

        this.applyConstraint();        
    }

    private void applyConstraint()
    {
        RopeSegment firstSegment = this.ropeSegments[0];
        firstSegment.setPosNow(this.transform.position);
        this.ropeSegments[0] = firstSegment;

        RopeSegment.limiteMaxX = tranfFinal.position.x;
        RopeSegment endSegment = this.ropeSegments[this.segmentLenght - 1];
        Vector3 posicao = tranfFinal.transform.position;
        //posicao.y = posYInicial;
        endSegment.setPosNow(posicao);

        this.ropeSegments[this.segmentLenght - 1] = endSegment;

        for(int i = 0; i < this.segmentLenght - 1; i++)
        {
            RopeSegment firstSeg = this.ropeSegments[i];
            RopeSegment secondSeg = this.ropeSegments[i + 1];

            float dist = (firstSeg.posNow - secondSeg.posNow).magnitude;
            float error = Mathf.Abs(dist - this.ropeSegLen);
            Vector2 changeDir = Vector2.zero;

            if(dist > ropeSegLen)
            {
                changeDir = (firstSeg.posNow - secondSeg.posNow).normalized;
            }
            else if(dist < ropeSegLen)
            {
                changeDir = (secondSeg.posNow - firstSeg.posNow).normalized;
            }

            Vector2 changeAmount = changeDir * error;
            if(i != 0)
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

    private void drawRope()
    {
        Vector3[] ropePositions = new Vector3[this.segmentLenght];
        for(int i = 0; i < this.segmentLenght; i++)
        {
            ropePositions[i] = this.ropeSegments[i].posNow;
        }

        lineRenderer.positionCount = ropePositions.Length;
        lineRenderer.SetPositions(ropePositions);
    }

    public struct RopeSegment
    {
        public static float limiteMaxX;

        public Vector2 posNow { get; private set; }
        public Vector2 posOld { get; private set; }

        public RopeSegment(Vector2 pos)
        {
            this.posNow = pos;
            this.posOld = pos;
        }

        public void setPosNow(Vector2 posNow)
        {
            if(posNow.x < -2.5f)
            {
                posNow.x = -2.5f;
            }

            if(posNow.x > limiteMaxX)
            {
                posNow.x = limiteMaxX;
            }
            this.posNow = posNow;
        }
        
        public void setPosOld(Vector2 posOld)
        {
            this.posOld = posOld;
        }

        public void addPosNow(Vector2 posNow)
        {
            Vector2 soma = this.posNow + posNow;
            setPosNow(soma);            
        }

        public void subPosNow(Vector2 posNow)
        {
            Vector2 sub = this.posNow - posNow;
            setPosNow(sub);
        }
    }
}
