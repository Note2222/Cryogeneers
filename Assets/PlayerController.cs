using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Unity.Netcode;
public class PlayerController : NetworkBehaviour
{
    public GameObject Player;
    public GameObject playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;
    public Rigidbody rb; [SerializeField]


    public float Speedcap = 2f;
    public float MovementSpeed = 5f;
    float rotationX = 0;
    // Start is called before the first frame update
    void Start()
    {
        if(IsLocalPlayer != true)
        {
            this.enabled = false;
        }
        //player = this.GetComponent<GameObject>();
    }

    void Update()
    {
        CameraRotation();
        PlayerMovement();
    }

    void PlayerMovement()
    {

        if(Input.GetAxis("Vertical") > 0)
        {
            rb.AddRelativeForce(Input.GetAxis("Vertical") * MovementSpeed * Vector3.forward);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddRelativeForce(-Input.GetAxis("Vertical") * MovementSpeed * -Vector3.forward);
        }



        if (Input.GetAxis("Horizontal") > 0)
        {
            rb.AddRelativeForce(Input.GetAxis("Horizontal") * MovementSpeed * -Vector3.left);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddRelativeForce(-Input.GetAxis("Horizontal") * MovementSpeed * Vector3.left);
        }



        //rb.AddForce(new Vector3(Input.GetAxis("Horizontal") * MovementSpeed,0, Input.GetAxis("Vertical") * MovementSpeed),ForceMode.Acceleration);
    }

    void CameraRotation()
    {


        rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, Mathf.Clamp(0,0,0), Mathf.Clamp(0, 0, 0));
        
        transform.rotation *= Quaternion.Euler(Mathf.Clamp(0, 0, 0), Input.GetAxis("Mouse X") * lookSpeed, Mathf.Clamp(0, 0, 0));

        
    }
}
