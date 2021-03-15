using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Garra : MonoBehaviour
{

    private Rigidbody2D rgbd2d;
    private float move;

    [SerializeField]
    private float speed;
    [SerializeField]
    private float gravity;
    private bool movingDown;
    
    private Vector2 moveToTarget;
    private bool moveToPosition;

    private bool movingEnable = true;
    private bool checkCombinacao = false;

    [SerializeField]
    private float coletadoScale;
    [SerializeField]
    private GameObject[] coletadoPosicoes = new GameObject[3]; 
    private GameObject[] coletados = new GameObject[3];
    private Vector2[] coletadosBackPosition = new Vector2[3];

    private int score = 0;
    private int maxScore = 4;

    [SerializeField] protected Text scoreTextField;

    

    // Start is called before the first frame update
    void Start()
    {
        rgbd2d = GetComponent<Rigidbody2D>();        

    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxis("Horizontal");
        

        if (Input.GetButtonDown("Jump"))
        {
            moveToTarget = rgbd2d.transform.position;            
            movingEnable = false;
            movingDown = true;
        }
    }

    private void FixedUpdate()
    {
        if (movingEnable)
        {
            rgbd2d.velocity = new Vector2(move * speed, rgbd2d.velocity.y);
        }        

        if (movingDown)
        {                        
            rgbd2d.gravityScale = gravity;            
            movingDown = false;
        }

        if (moveToPosition)
        {
            rgbd2d.position = moveToTarget;
            moveToPosition = false;
            movingEnable = true;
        }

        if (checkCombinacao)
        {
            GameObject checkColetavel= coletados[1];
            bool resposta = false;

            foreach (GameObject coletavel in coletados)
            {                
                if(checkColetavel.gameObject.CompareTag(coletavel.tag))
                {
                    resposta = true;
                }
                else
                {
                    resposta = false;
                }
            }

            if (resposta)
            {
                Debug.Log("yes");

                for (int i = 0; i < coletados.Length; i++)
                {
                    Destroy(coletados[i]);
                }

                score += 1;
                scoreTextField.text = score.ToString();

                if(score == maxScore)
                {
                    OnClickPlay();
                }
            }
            else
            {
                Debug.Log("noooo");

                for (int i = 0; i < coletados.Length; i++)
                {
                    coletados[i].transform.localScale += Vector3.one * coletadoScale;
                    coletados[i].gameObject.transform.position = coletadosBackPosition[i];
                    //coletadoPosicoes[i].gameObject.transform.position = coletadoOldPosicoes[i].transform.position;
                }
            }           

            coletados = new GameObject[3];
            coletadosBackPosition = new Vector2[3];
            checkCombinacao = false;
        }

        
    }   

    private void OnCollisionEnter2D(Collision2D other)
    {
        //if (other.gameObject.tag == "Gummy")
        //{            
            rgbd2d.gravityScale = 0.0f;

            
            //other.transform.position = coletado1.transform.position;

            for (int i = 0; i < coletados.Length; i++)
            {
                if (coletados[i] == null)
                {
                //coletadoOldPosicoes[i] = other.gameObject;
                    coletados[i] = other.gameObject;
                    coletadosBackPosition[i] = other.gameObject.transform.position;

                    other.transform.localScale -= Vector3.one * coletadoScale;
                    other.transform.position = coletadoPosicoes[i].transform.position;
                                    
                    if ( i == coletados.Length - 1)
                    {
                        checkCombinacao = true;
                    }

                    moveToPosition = true;
                    //Destroy(other.gameObject);
                    return;
                }
            }                      
        //}
    }

    public void OnClickPlay()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
