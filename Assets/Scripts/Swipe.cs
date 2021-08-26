using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    private Vector2 fingerDown;
    private Vector2 fingerUp;
    public bool DetectFinalSwipe = false;

    public float Swipe_Sensitivity = 20f;

    // Update is called once per frame
    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                fingerUp = touch.position;
                fingerDown = touch.position;
            }

            //Detecta Swipe enquanto o dedo move 
            if (touch.phase == TouchPhase.Moved)
            {
                if (!DetectFinalSwipe)
                {
                    fingerDown = touch.position;
                    checkSwipe();
                }
            }

            //Detecta Swipe somente quando tira o dedo
            if (touch.phase == TouchPhase.Ended)
            {
                fingerDown = touch.position;
                checkSwipe();

            }

        }
    }


    void checkSwipe()
    {
        //Checa se o Swipe é vertical
        if (verticalMove() > Swipe_Sensitivity && verticalMove() > horizontalMove())
        {
            //Debug.log("Vertical");
            if (fingerDown.y - fingerUp.y > 0)//cima
            {
                OnSwipeUp();
            }
            else if (fingerDown.y - fingerUp.y < 0)//baixo
            {
                OnSwipeDown();
            }
            fingerUp = fingerDown;
        }

        //checa se o movimento é horizontal
        else if (horizontalMove() > Swipe_Sensitivity && horizontalMove() > verticalMove())
        {
            if (fingerDown.x - fingerUp.x > 0)//direita
            {
                onSwipeRight();
            }
            else if (fingerDown.x - fingerUp.x < 0)//esquerda
            {
                onSwipeLeft();
            }
            fingerUp = fingerDown;

        }

        //sem movimento
        else
        {
            Debug.Log("Sem Swipe!");
        }
    }

    //retorna valor absoluto entre os eixos verticais
    float verticalMove()
    {
        return Mathf.Abs(fingerDown.y - fingerUp.y);
    }

    //retorna valor absoluto entre os eixos horizontais
    float horizontalMove()
    {
        return Mathf.Abs(fingerDown.x - fingerUp.x);
    }

    //retornos
    void OnSwipeUp()
    {
        print("cima");
    }

    void OnSwipeDown()
    {
        print("baixo");
    }

    void onSwipeLeft()
    {
        print("esquerda");
    }

    void onSwipeRight()
    {
        print("direita");
    }

}