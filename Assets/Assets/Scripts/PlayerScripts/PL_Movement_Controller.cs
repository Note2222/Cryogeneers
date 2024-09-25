using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Unity.Netcode;
public class PL_Movement_Controller : NetworkBehaviour
{
    public GameObject Player;
    public GameObject playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;
    public Rigidbody rb; [SerializeField]

    PL_Inv_Controller inventoryController;



    float StartingMovementSpeedCoefficient = 1f; [SerializeField]
    public float CurrentMovementSpeedCoefficient = 1f;

    public float BareHandedMovespeedMultiplier = 1.15f;

    public float MovementSpeed = 5f;
    float rotationX = 0;
    // Start is called before the first frame update
    void Start()
    {
        if(IsLocalPlayer != true)
        {
            CurrentMovementSpeedCoefficient = StartingMovementSpeedCoefficient;

            this.enabled = false;
        }
        inventoryController = GetComponent<PL_Inv_Controller>();

        //player = this.GetComponent<GameObject>();
    }

    void Update()
    {
        CameraRotation();
        PlayerMovement();
    }

    void PlayerMovement()
    {

        float vertical;
        float horizontal;

        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        rb.velocity = (transform.forward * vertical) * (MovementSpeed * CurrentMovementSpeedCoefficient) * Time.fixedDeltaTime + (transform.right * horizontal) * (MovementSpeed * CurrentMovementSpeedCoefficient) * Time.fixedDeltaTime;

    }


    void InventoryBareHandedCheck()
    {
        if (inventoryController.SelectedSlot == 0 || (inventoryController.SelectedSlot == 1 && inventoryController.Slot1 == null) || (inventoryController.SelectedSlot == 2 && inventoryController.Slot2 == null))
        {
            CurrentMovementSpeedCoefficient = BareHandedMovespeedMultiplier;
        }
    }


    void CameraRotation()
    {


        rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, Mathf.Clamp(0,0,0), Mathf.Clamp(0, 0, 0));
        
        transform.rotation *= Quaternion.Euler(Mathf.Clamp(0, 0, 0), Input.GetAxis("Mouse X") * lookSpeed, Mathf.Clamp(0, 0, 0));

        
    }
}
