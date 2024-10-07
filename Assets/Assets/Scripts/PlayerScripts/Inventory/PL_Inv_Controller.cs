using UnityEngine;

public class PL_Inv_Controller : MonoBehaviour
{
    public GameObject Player;


    public ScriptObj_PlayerInventoryObject Slot0;
    public float slot0health;
    public ScriptObj_PlayerInventoryObject Slot1;
    public float slot1health;
    public ScriptObj_PlayerInventoryObject Slot2;
    public float slot2health;

    public Transform HoldPosition;

    private void Start()
    {
        Slot0 = null;
        Slot1 = null;
        Slot2 = null;
    }




    public int SelectedSlot = 0;


    private void Update()
    {
        Slot0 = null;
        // Gets inputs
        PlayerInputs();
    }

    void PlayerInputs()
    {
        PickUpItem();


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (HoldPosition.transform.childCount != 0)
            {
                Destroy(HoldPosition.transform.GetChild(0).gameObject);
            }
            SelectedSlot = 0;
        }



        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (HoldPosition.transform.childCount != 0)
            {
                slot1health = HoldPosition.transform.GetChild(0).gameObject.GetComponent<HeldObjectContainer>().Health;
                Destroy(HoldPosition.transform.GetChild(0).gameObject);
            }
            if (Slot2 != null)
            {
                GameObject SlotObject1 = Instantiate(Slot2.Prefab, HoldPosition);
                SlotObject1.GetComponent<HeldObjectContainer>().Health = slot2health;
                slot2health = SlotObject1.GetComponent<HeldObjectContainer>().Health;
            }


            SelectedSlot = 2;
        }



        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (HoldPosition.transform.childCount != 0)
            {
                slot2health = HoldPosition.transform.GetChild(0).gameObject.GetComponent<HeldObjectContainer>().Health;
                Destroy(HoldPosition.transform.GetChild(0).gameObject);
            }
            if (Slot2 != null)
            {
                GameObject SlotObject2 = Instantiate(Slot2.Prefab, HoldPosition);
                SlotObject2.GetComponent<HeldObjectContainer>().Health = slot2health;
                slot2health = SlotObject2.GetComponent<HeldObjectContainer>().Health;
            }


            SelectedSlot = 2;

        }


        void PickUpItem()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                Debug.Log("Raycasted,");
                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    Debug.Log("Raycast Hit, Something.");
                    GameObject ItemTarget = hit.transform.gameObject;
                    Debug.Log(hit.transform.gameObject.name);

                    if (hit.transform.gameObject.GetComponent<HeldObjectContainer>() != null)
                    {
                        if (hit.transform.gameObject.GetComponent<HeldObjectContainer>().IsObtainable == true)
                        {

                            if (Player.GetComponentInParent<PL_Inv_Controller>().SelectedSlot == 1)
                            {
                                slot1health = ItemTarget.GetComponent<HeldObjectContainer>().Health;
                                Slot1 = ItemTarget.GetComponent<HeldObjectContainer>().playerinventoryobject;
                                Destroy(hit.transform.gameObject);
                            }

                            if (Player.GetComponentInParent<PL_Inv_Controller>().SelectedSlot == 2)
                            {
                                slot2health = ItemTarget.GetComponent<HeldObjectContainer>().Health;
                                Slot2 = ItemTarget.GetComponent<HeldObjectContainer>().playerinventoryobject;
                                Destroy(hit.transform.gameObject);
                            }
                        }
                    }

                }
            }
        }




        if (Input.GetKeyDown(KeyCode.Q))
        {
            DropItem();
        }

        //destroys specified slots item
        void DropItem()
        {
            switch (SelectedSlot)
            {
                case 0:
                    print("currently on bare hands, cannot drop them.");
                    break;

                case 1:
                    if (Slot1 != null)
                    {
                        GameObject DroppedItem = Instantiate(Slot1.DroppedPrefab, this.gameObject.transform.position, Quaternion.identity);
                        DroppedItem.GetComponent<HeldObjectContainer>().Health = HoldPosition.transform.GetChild(0).gameObject.GetComponent<HeldObjectContainer>().Health;
                        Destroy(HoldPosition.transform.GetChild(0).gameObject);
                        Slot1 = null;
                    }
                    //if (HoldPosition.transform.childCount != 0)
                    //{
                    //    Destroy(HoldPosition.transform.GetChild(0).gameObject);
                    //    Slot1 = null;
                    //}
                    //if (HeldObjectcontainer.Health < 0) IsOn = false;
                    break;

                case 2:
                    if (Slot2 != null)
                    {
                        GameObject DroppedItem = Instantiate(Slot2.DroppedPrefab, this.gameObject.transform.position, Quaternion.identity);
                        DroppedItem.GetComponent<HeldObjectContainer>().Health = HoldPosition.transform.GetChild(0).gameObject.GetComponent<HeldObjectContainer>().Health;
                        Destroy(HoldPosition.transform.GetChild(0).gameObject);
                        Slot2 = null;
                    }
                    //if (HoldPosition.transform.childCount != 0)
                    //{
                    //    Destroy(HoldPosition.transform.GetChild(0).gameObject);
                    //    Slot2 = null;
                    //}
                    break;
            }
        }


    }
}
