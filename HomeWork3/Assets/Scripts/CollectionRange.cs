using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionRange : MonoBehaviour
{
    private GameObject[] collectionList;
    private int index;
    Vector3 mPrevPosition = Vector3.zero;
    Vector3 mPosDelta = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        collectionList = new GameObject[transform.childCount];
        for (int i = 0; i < collectionList.Length; i++)
        {
            collectionList[i] = transform.GetChild(i).gameObject;
        }
        foreach (GameObject go in collectionList)
        {
            go.SetActive(false);
        }
        if (collectionList[0])
        {
            collectionList[0].SetActive(true);
        }     

    }
    public void SetColorRed()
    {
        var sparrowColor = collectionList[index].GetComponent<Renderer>();

        sparrowColor.material.SetColor("_Color", Color.red);
    }
    public void SetColorGreen()
    {
        var sparrowColor = collectionList[index].GetComponent<Renderer>();

        sparrowColor.material.SetColor("_Color", Color.green);
    }
    public void SetColorYellow()
    {
        var sparrowColor = collectionList[index].GetComponent<Renderer>();

        sparrowColor.material.SetColor("_Color", Color.yellow);
    }
    public void SetColorBlue()
    {
        var sparrowColor = collectionList[index].GetComponent<Renderer>();

        sparrowColor.material.SetColor("_Color", Color.blue);
    }
    public void ButtonNext()
    {
        collectionList[index].SetActive(false);
        index++;
        if (index > collectionList.Length - 1)
        {
            index = 0;
        }
        collectionList[index].SetActive(true);
    }
    public void ButtonPrevious()
    {
        collectionList[index].SetActive(false);
        index--;
        if (index < 0) 
        {
            index = collectionList.Length - 1;
        }
        collectionList[index].SetActive(true);
    }
    //public void Update()
    //{
    //    if (Input.GetMouseButton(0))
    //    {
    //        mPosDelta = Input.mousePosition - mPrevPosition;
    //        if (Vector3.Dot(transform.up, Vector3.up) >= 0)
    //        {
    //            transform.Rotate(transform.up, -Vector3.Dot(mPosDelta, Camera.main.transform.right), Space.World);
    //        }
    //        else
    //        {
    //            transform.Rotate(transform.up, -Vector3.Dot(mPosDelta, Camera.main.transform.right), Space.World);
    //        }
    //        transform.Rotate(Camera.main.transform.right, Vector3.Dot(mPosDelta, Camera.main.transform.up), Space.World);
    //    }
    //    mPrevPosition = Input.mousePosition;
    //}
}
