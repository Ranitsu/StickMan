using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Entities
{
    [System.Serializable]
    public class Level
    {
        public string LevelName { get { return _levelName; } }

        [SerializeField]
        public string _levelName;

        public string LevelDescription { get { return _levelDescription; } }

        [SerializeField]
        public string _levelDescription;

        public string Author { get { return _author; } }

        [SerializeField]
        public string _author;

        public List<LevelPart> LevelParts { get { return _levelParts; } }

        [SerializeField]
        public List<LevelPart> _levelParts;


        public Level(string levelName, string levelAuthor)
        {
            _levelName = levelName;
            _levelDescription = "";
            _author = levelAuthor;
            _levelParts = new List<LevelPart>();
        }

        public Level(string levelName, string levelDescription, string levelAuthor, List<LevelPart> levelParts)
        {
            _levelName = levelName;
            _levelDescription = levelDescription;
            _author = levelAuthor;
            _levelParts = levelParts;
        }

        public void AddPart(LevelPart part)
        {
            _levelParts.Add(part);
        }

        public void RemovePart(LevelPart part)
        {
            _levelParts.Remove(part);
        }
    }
}