using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CarSelection : MonoBehaviour
{
    public GameObject[] cars;
    public Button Next;
    public Button Prev;
    public int selectCar;

    public void Start()
    {
        selectCar = PlayerPrefs.GetInt("car Index");
        for (int i = 0; i < cars.Length; i++)
        {
            cars[i].SetActive(false);
            cars[selectCar].SetActive(true);
        }
    }

    public void Update()
    {
        if (selectCar >= 2)
        {
            Next.interactable = false;
        }
        else 
        {
            Next.interactable= true;
        }

        if (selectCar <= 0)
        {
            Prev.interactable = false;
        }
        else
        {
            Prev.interactable = true;
        }          

    }
    public void NextBut()
    {
        selectCar++;
        for (int i = 0; i < cars.Length; i++)
        {
            cars[(i)].SetActive(false);
            cars[(selectCar)].SetActive(true);
        }
        PlayerPrefs.SetInt("carIndex", selectCar);
        PlayerPrefs.Save();
    }
    public void PrevBut()
    {
        selectCar--;
        for (int i = 0; i < cars.Length; i++)
        {
            cars[(i)].SetActive(false);
            cars[(selectCar)].SetActive(true);
        }
        PlayerPrefs.SetInt("carIndex", selectCar);
        PlayerPrefs.Save();
    }

    public void Confirm()
    {
        PlayerPrefs.SetInt("carIndex", selectCar); 
        PlayerPrefs.Save();
        SceneManager.LoadSceneAsync("Level 2", LoadSceneMode.Single);

    }
    private void UpdateCarSelection() { for (int i = 0; i < cars.Length; i++) { cars[i].SetActive(i == selectCar); } }

}
