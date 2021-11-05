using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCamLook : MonoBehaviour
{

    public float sensitivity = 5.0f;
    public float smoothing = 2.0f;
    public GameObject jugador;
    private Vector2 mouseLook;
    private Vector2 smoothV;


    void Start()
    {
        jugador = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));

        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);

         mouseLook += smoothV;
        transform.localRotation = Quaternion.AngleAxis(-Mathf.Clamp(mouseLook.y, -90, 90), Vector3.right);
        jugador.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, jugador.transform.up);

    }
}