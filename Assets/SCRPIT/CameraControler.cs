using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    // variables
    public float mouseSensitivity;

    private Transform parent;//telling to the camera that the object which rotation  affect will be the  parent

    void Start()
    {
        parent = transform.parent;
        Cursor.lockState = CursorLockMode.Locked; //press [esc] to exit the mode
    }

    void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        parent.Rotate(Vector3.up, mouseX);
    }
}
