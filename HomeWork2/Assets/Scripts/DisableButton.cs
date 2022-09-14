using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DisableButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject buttonsHilights;
    public Button oneButton;
    public GameObject oneButtonHilights;
    public Button twoButton;
    public GameObject twoButtonHilights;
    public GameObject disableButtonHilights;

    public void OnPointerDown(PointerEventData eventData)
    {
        buttonsHilights.gameObject.SetActive(false);
        oneButton.enabled = false;
        oneButtonHilights.gameObject.SetActive(false);
        twoButton.enabled = false;
        twoButtonHilights.gameObject.SetActive(false);
        disableButtonHilights.gameObject.SetActive(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        buttonsHilights.gameObject.SetActive(true);
        disableButtonHilights.gameObject.SetActive(false);
    }
}