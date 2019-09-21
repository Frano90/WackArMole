using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppController : MonoBehaviour
{
    private Maquinola _currentMaquinola;
    public Maquinola maquinola_prefab;
    private bool isMaquinolaDeployed = false;
    public Camera arCamera;
    public Martillo martillo;

    private void Start()
    {
        //_currentMaquinola = Instantiate<Maquinola>(maquinola_prefab);
    }

    public void BackToMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    public void OnMaquinolaDeployed()
    {
        isMaquinolaDeployed = !isMaquinolaDeployed;
    }

    void Update()
    {
        //hacer que cuando toco la pantalla, tire un rayo en la direccion seleccionada
        //si choca contra un enemigo, le hago daño al enemigo

        //if (!isMaquinolaDeployed)
        //    return;

        if(Input.touchCount == 1)
        {
            //Debug.Log("toque");

            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = arCamera.ScreenPointToRay(touch.position);
                RaycastHit hitObject;
                if (Physics.Raycast(ray, out hitObject))
                {
                    Enemy hittedObject = hitObject.transform.GetComponent<Enemy>();
                    if (hittedObject != null)
                    {
                        martillo.DoTheHit(hittedObject, delegate { hittedObject.DamageEnemy(1); } );
                        //hittedObject.DamageEnemy(1);
                        //Debug.Log("Te hago dano");
                    }
                }
            }
        }
    }


    //TODO la parte de AR sera en el segundo paso, pero hay que hacer que detecte un plano, coloque ahi la maquinola.
}
