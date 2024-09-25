using UnityEngine;

public class PL_Inv_Controller : MonoBehaviour
{

    public ScriptObj_PlayerInventoryObject Slot0;
    public ScriptObj_PlayerInventoryObject Slot1;
    public ScriptObj_PlayerInventoryObject Slot2;

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
                Destroy(HoldPosition.transform.GetChild(0).gameObject);
            }
            if (Slot1 != null)
                Instantiate(Slot1.Prefab, HoldPosition);
            SelectedSlot = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if(HoldPosition.transform.childCount != 0)
            {
                Destroy(HoldPosition.transform.GetChild(0).gameObject);
            }
            if (Slot2 != null)
                Instantiate(Slot2.Prefab, HoldPosition);
            SelectedSlot = 2;
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
                        Instantiate(Slot1.DroppedPrefab, this.gameObject.transform.position, Quaternion.identity);
                    }
                    if (HoldPosition.transform.childCount != 0)
                    {
                        Destroy(HoldPosition.transform.GetChild(0).gameObject);
                    }

                    Slot1 = null;


                    break;

                case 2:
                    if (Slot1 != null)
                    {
                        Instantiate(Slot2.DroppedPrefab, this.gameObject.transform.position, Quaternion.identity);
                    }
                    if (HoldPosition.transform.childCount != 0)
                    {
                        Destroy(HoldPosition.transform.GetChild(0).gameObject);
                    }

                    Slot2 = null;
                    break;
            }
        }

    }
}
