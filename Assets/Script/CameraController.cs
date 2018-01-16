using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float scrollSpeed = 70f;
    public float minY = 5;
    public float maxY = 40f;

    public float paneSpeed = 30f;
    public float paneBorderThickness = 10f;

    public bool useMouse = false;

    public KeyCode moveActiveKey;
    private bool doMovement = true;

	


	void Update () {

        if (Input.GetKeyDown(moveActiveKey))
        {
            doMovement = !doMovement;
        }


        if (doMovement)
        {

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(Vector3.forward * paneSpeed * Time.deltaTime, Space.World);
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(Vector3.back * paneSpeed * Time.deltaTime, Space.World);
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(Vector3.left * paneSpeed * Time.deltaTime, Space.World);
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(Vector3.right * paneSpeed * Time.deltaTime, Space.World);
            }




            if (useMouse)
            {
                if (Input.mousePosition.y >= (Screen.height - paneBorderThickness))
                {
                    transform.Translate(Vector3.forward * paneSpeed * Time.deltaTime, Space.World);
                }
                if (Input.mousePosition.y <= paneBorderThickness)
                {
                    transform.Translate(Vector3.back * paneSpeed * Time.deltaTime, Space.World);
                }
                if (Input.mousePosition.x <= paneBorderThickness)
                {
                    transform.Translate(Vector3.left * paneSpeed * Time.deltaTime, Space.World);
                }
                if (Input.mousePosition.x >= Screen.width - paneBorderThickness)
                {
                    transform.Translate(Vector3.right * paneSpeed * Time.deltaTime, Space.World);
                }
            }




            float scroll = Input.GetAxis("Mouse ScrollWheel");
            Vector3 pos = transform.position;

            pos.y -= scroll * scrollSpeed * Time.deltaTime;
            pos.y = Mathf.Clamp(pos.y, minY, maxY);

            transform.position = pos;


        }

    }
}
