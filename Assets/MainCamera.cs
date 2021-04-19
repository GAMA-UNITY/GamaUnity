using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public float dragSpeed = 200;
    private Vector3 dragOrigin;



    private Vector3 ResetCamera; // original camera position
    private Vector3 Origin; // place where mouse is first pressed
    private Vector3 Diference; // change in position of mouse relative to origin

    // Start is called before the first frame update
    void Start()
    {
        ResetCamera = Camera.main.transform.position;
    }

    // Update is called once per frame
    void Update()
    {



        if (Input.GetMouseButtonDown(0)) {
            Origin = MousePos();
        }
        if (Input.GetMouseButton(0)) {
            Diference = MousePos() - transform.position;
            transform.position = Origin - Diference;
        }
        if (Input.GetMouseButton(1)) // reset camera to original position
        {
            transform.position = ResetCamera;
        }
        /*
        if (Input.GetMouseButtonDown(0)) {
            dragOrigin = Input.mousePosition;
            return;
        }

        if (!Input.GetMouseButton(0)) return;

        Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
        Vector3 move = new Vector3(pos.x * dragSpeed, 0, pos.y * dragSpeed);

        transform.Translate(move, Space.World);
        */
    }

    Vector3 MousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
