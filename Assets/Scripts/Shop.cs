using System;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject keyImage;
    [SerializeField] private GameObject shopUI;
    private bool canBuy = false;
    private bool isOpen = false;

    private void Start()
    {
        keyImage.SetActive(false);
        shopUI.SetActive(false);
    }

    private void Update()
    {
        if (!canBuy) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isOpen)
            {
                CloseShop();
            }
            else
            {
                OpenShop();
            }
        }
    }

    private void OpenShop()
    {
        shopUI.SetActive(true);
        isOpen = true;
        keyImage.SetActive(false);

        Time.timeScale = 0f;
    }

    private void CloseShop()
    {
        shopUI.SetActive(false);
        isOpen = false;

        if (canBuy)
            keyImage.SetActive(true);

        Time.timeScale = 1f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        keyImage.SetActive(true);
        canBuy = true;
        
        if (!isOpen)
            keyImage.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        keyImage.SetActive(false);
        canBuy = false;
        
        if (isOpen)
            CloseShop();
    }
}
