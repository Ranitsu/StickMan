using UnityEngine;
using System.Collections;

namespace Entities
{
    public class LevelPart
    {
        public GameObject PartObject { get { return _partObject; } }
        private GameObject _partObject;
        public Vector2 PartLocation { get { return _partLocation; } }
        private Vector2 _partLocation;
        public string PartTag { get { return _partTag; } }
        private string _partTag;
        public bool IsSpawnPart { get { return _isSpawnPart; } }
        private bool _isSpawnPart;

        public LevelPart(GameObject part, Vector2 location, string partTag, bool isSpawnPart)
        {
            _partObject = part;
            _partLocation = location;
            _partTag = partTag;
            _isSpawnPart = isSpawnPart;
        }
    }
}
