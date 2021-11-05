using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorJugador : MonoBehaviour
{

    public float speed = 10f;
    private float translation;
    private float straffe;

    public Camera MainCamera;
    public Camera Retrovisor;
    public Camera CamaraPared;

    void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;
        MainCamera.enabled = true;
        Retrovisor.enabled = true;
        CamaraPared.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        straffe = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(straffe, 0, translation);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (MainCamera.enabled == true)
            {
                MainCamera.enabled = false;
                Retrovisor.enabled = false;
                CamaraPared.enabled = true;
                GameObject.Find("Canvas").GetComponent<Canvas>().enabled = false;
            }
            else
            {
                MainCamera.enabled = true;
                Retrovisor.enabled = true;
                CamaraPared.enabled = false;
                GameObject.Find("Canvas").GetComponent<Canvas>().enabled = true;
            }
        }

        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }

    }
}
