using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleButton : MonoBehaviour
{
    public GameObject togglesMenu;
    private Button toggleButton;
    // Start is called before the first frame update
    void Start()
    {
        toggleButton = GetComponent<Button>();
        if (toggleButton == null)
        {
            Debug.Log("AHA AHA");
        }
        else
        {
            toggleButton.onClick.AddListener(() => { togglesMenu.gameObject.SetActive(true); });
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
