using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OneButton : MonoBehaviour
{
    public GameObject oneButtonHilights;
    public GameObject buttonsHilights;
    public GameObject twoButtonHilights;
    private Button oneButton;
    // Start is called before the first frame update
    void Start()
    {
        oneButton = GetComponent<Button>();
        //oneButtonHilights = GetComponent<GameObject>(); яопняхрэ с опеондюбюрекъ!
        if (oneButton == null)
        {
            Debug.Log("AHA AHA");
        }
        else
        {
            oneButton.onClick.AddListener(() => { 
            oneButtonHilights.gameObject.SetActive(true); 
            buttonsHilights.gameObject.SetActive(false); 
            twoButtonHilights.gameObject.SetActive(false);});
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
