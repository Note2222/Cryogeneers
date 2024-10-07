using UnityEngine;

public class Obj_Flashlight : MonoBehaviour
{
    public float MaxBatteryLife;
    public bool IsOn = false;
    public GameObject LightSource;
    public HeldObjectContainer HeldObjectcontainer;

    private void Start()
    {
        HeldObjectcontainer = GetComponent<HeldObjectContainer>();
    }

    private void Update()
    {
        if (HeldObjectcontainer.Health < 0) IsOn = false;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            IsOn = !IsOn;
        }


        if (IsOn == true)
        {
            HeldObjectcontainer.Health -= Time.deltaTime;
            LightSource.SetActive(true);

        }


        if (IsOn == false)
        {
            LightSource.SetActive(false);

        }
    }
}
