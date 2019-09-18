using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Martillo : MonoBehaviour
{
    public float maxOffset;
    public float smoothSpeed = 0.125f;
    public Transform idleSpot;
    private Vector3 localPosOrigin;
    public MartilloAnim_helper model;

    public void DoTheHit(Enemy enemy, Action<int> callback)
    {
        //Hacer que el martillo vaya hacia el target
        //Ejecute animacion de golpe
        //Vuelva a su lugar

        Vector3 startPos = transform.position;
        Vector3 endPos = enemy.spawner.hammerPlace.transform.position;

        StartCoroutine(AproachEnemy(startPos, endPos));
        
    }

    private IEnumerator AproachEnemy(Vector3 startPos, Vector3 endPos)
    {
        
        while (Vector3.Distance(transform.position, endPos) >= maxOffset)
        {
            Vector3 smoothPos = Vector3.Lerp(transform.position, endPos, smoothSpeed);
            transform.position = smoothPos;
            yield return new WaitForEndOfFrame();
        }

        transform.position = endPos;
   
        GetComponentInChildren<Animator>().SetTrigger("Hit");



    }

    private IEnumerator AproachIdlePlace(Vector3 startPos, Vector3 endPos)
    {

        while (Vector3.Distance(transform.position, endPos) >= maxOffset)
        {
            Vector3 smoothPos = Vector3.Lerp(transform.position, endPos, smoothSpeed);
            transform.position = smoothPos;
            yield return new WaitForEndOfFrame();
        }

        transform.position = endPos;
        model.transform.localPosition = model.localPosOrigin;

    }

    public void GoBackToPos()
    {
        StartCoroutine(AproachIdlePlace(transform.position , idleSpot.position));
    }
    private void Update()
    {
        
    }
}
