using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchTest : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        //if(Input.touchCount > 0)
        //{
        //    Touch touch = Input.GetTouch(0);
        //    Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
        //    touchPos.z = 0f;

        //    transform.position = touchPos;

        //}

        //for(int i = 0; i < Input.touchCount; i++)
        //{
        //    Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.touches[i].position);
        //    Debug.DrawLine(Vector3.zero,touchPos,Color.red);
        //}

        //checa se esta tocando a tela, o touchcount conta quantos dedos estão tocando a tela ou seja se for maior que 0 esta tocando a tela
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
               

                print("Tocou!");
            }

            //não considera touch
            if (touch.phase == TouchPhase.Canceled)
            {
                print("toque incorreto!");
            }

            //tirou o dedo da tela
            if (touch.phase == TouchPhase.Ended)
            {
                print("tirou o dedo!");
            }

            //movimentou o dedo
            if (touch.phase == TouchPhase.Moved)
            {
                Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
                touchPos.z = 0f;
                transform.position = touchPos;

                print("moveu o dedo!");
            }

            //dedod parado sem se mover na tela
            if (touch.phase == TouchPhase.Stationary)
            {
                print("dedo parado na tela!");
            }
        }


    }
}
