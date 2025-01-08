using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Reflection.Emit;

public class Load_Car : MonoBehaviour
{
    public GameObject[] CarPrefabs;
    public Transform spawnPoint;
    

    private void Start()
    {
        int selectCar = PlayerPrefs.GetInt("carIndex", 0);
        GameObject prefab = CarPrefabs[selectCar];
        prefab.SetActive(true);
        //GameObject clone = Instantiate(prefab, spawnPoint.position, Quaternion.identity);

    }
}