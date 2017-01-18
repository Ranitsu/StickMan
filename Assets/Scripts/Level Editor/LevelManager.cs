using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Entities;

public class LevelManager : MonoBehaviour
{

    public Level CurrentLevel;

    void Start()
    {
        CurrentLevel = new Level("Random Name", "Luke Parker");
    }

    public void AddPart(GameObject part, Vector2 location, bool isSpawnPart)
    {
        RemovePart(location);

        var newPart = PlaceObject(part, location);

        CurrentLevel.AddPart(newPart);
    }

    public void RemovePart(Vector2 location)
    {
        var count = 0;
        LevelPart partToRemove = null;
        foreach (var part in CurrentLevel.LevelParts)
        {

            if (part.PartLocation == location)
            {
                Debug.Log("Part Location: " + part.PartLocation + ", location:" + location);
                RemoveObject(part.PartTag);
                partToRemove = part;
                continue;
            }
            count++;
        }
        if (partToRemove != null)
            CurrentLevel.RemovePart(partToRemove);
    }

    private LevelPart PlaceObject(GameObject part, Vector2 location)
    {
        var newTag = GenerateGuid();
        GameObject _levelPartClone = GameObject.Instantiate(part, location + (Vector2)part.transform.position - new Vector2(0, 0.5f), part.transform.rotation) as GameObject;
        _levelPartClone.name = newTag;

        return new LevelPart(_levelPartClone, location, _levelPartClone.name, false);
    }

    private void RemoveObject(string partTag)
    {
        var partToRemove = GameObject.Find(partTag);
        Destroy(partToRemove);
    }

    private string GenerateGuid()
    {
        return System.Guid.NewGuid().ToString();
    }

    public Transform RotateLeft(Transform rotateThing)
    {
        rotateThing.Rotate(0.0f, -90.0f, 0.0f);
        return rotateThing;
    }

    public Transform RotateRight(Transform rotateThing)
    {
        rotateThing.Rotate(0.0f, 90.0f, 0.0f);
        return rotateThing;
    }
}