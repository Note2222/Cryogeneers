using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject Player;
    public GameObject playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;

    public float MovementSpeed = 5f;
    float rotationX = 0;
    // Start is called before the first frame update
    void Start()
    {
        //player = this.GetComponent<GameObject>();
    }

    void Update()
    {
        rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);




    }
}
