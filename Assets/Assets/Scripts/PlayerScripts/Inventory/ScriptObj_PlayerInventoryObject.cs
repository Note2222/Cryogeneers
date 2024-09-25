using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
public class ScriptObj_PlayerInventoryObject : ScriptableObject
{
    public GameObject Prefab;
    public GameObject DroppedPrefab;
}