using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PartList : MonoBehaviour
{
    public List<GameObject> Parts = new List<GameObject>();
    public GameObject SelectedPart;

    private int _selectedPartNumber = 0;

    void Start()
    {
        SelectedPart = Parts[_selectedPartNumber];
    }

    public void SelectNextPart()
    {
        _selectedPartNumber++;
        if(_selectedPartNumber >= Parts.Count)
        {
            _selectedPartNumber = 0;
        }
        SelectedPart = Parts[_selectedPartNumber];
    }
}
