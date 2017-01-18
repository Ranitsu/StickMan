using UnityEngine;
using System.Collections;

public class LE_input : MonoBehaviour
{

    private Vector2 _cursorPosition = new Vector3(0.5f, 0.5f);
    private Vector2 _placementPosition = new Vector3(0.5f, 0.5f);

    private bool _moved = false;
    public PartList _partList;
    public LevelManager _levelManager;

    public GameObject Cursor;

   
    void Start ()
    {
        _partList = GetComponent<PartList>();
        _levelManager = GetComponent<LevelManager>();
    }
	
	void Update ()
    {
        InputCheck();
        if (Input.GetButtonUp("Jump"))
        {
            _levelManager.AddPart(_partList.SelectedPart, _placementPosition, false);
        }
        if (Input.GetButtonUp("Fire3"))
        {
            _levelManager.RemovePart(_placementPosition);
        }
    }

    void InputCheck()
    {
        if(!_moved)
        {
            if(Input.GetAxis("Horizontal") > 0)
            {
                _cursorPosition = new Vector2(_cursorPosition.x + 1.0f, _cursorPosition.y);
                _placementPosition = new Vector2(_placementPosition.x + 1.0f, _cursorPosition.y);
                _moved = true;                 
            }
            else if(Input.GetAxis("Horizontal") < 0)
            {
                _cursorPosition = new Vector2(_cursorPosition.x - 1.0f, _cursorPosition.y);
                _placementPosition = new Vector2(_placementPosition.x - 1.0f, _placementPosition.y);
                _moved = true;
            }
            if (Input.GetAxis("Vertical") > 0)
            {
                _cursorPosition = new Vector2(_cursorPosition.x, _cursorPosition.y + 1.0f);
                _placementPosition = new Vector2(_placementPosition.x, _placementPosition.y + 1.0f);
                _moved = true;
            }
            else if (Input.GetAxis("Vertical") < 0)
            {
                _cursorPosition = new Vector2(_cursorPosition.x, _cursorPosition.y - 1.0f);
                _placementPosition = new Vector2(_placementPosition.x, _placementPosition.y - 1.0f);
                _moved = true;
            }
            Cursor.transform.position = _cursorPosition;
        }
        if(Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            _moved = false;
        }
        if (Input.GetButtonUp("Fire1"))
        {
            _partList.SelectNextPart();
        }
    }
}
