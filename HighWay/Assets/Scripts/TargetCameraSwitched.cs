using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCameraSwitched : MonoBehaviour
{

    public GameObject[] cars; 
    private CinemachineVirtualCamera virtualCamera; 
    private void Start() { virtualCamera = GetComponent<CinemachineVirtualCamera>(); 
        int selectCar = PlayerPrefs.GetInt("carIndex", 0); 
        GameObject selectedCar = cars[selectCar]; virtualCamera.Follow = selectedCar.transform;  
        virtualCamera.LookAt = selectedCar.transform;}
}


