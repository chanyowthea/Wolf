using UnityEngine;
using System.Collections;
using System.Collections.Generic; 

public enum CreatureType
{
    Wolf, 
    Sheep, 

    Grass, 
    Lily, 
}

public static class CreatureManager
{
    public static Wolf _Wolf; 
    static List<Creature> _list = new List<Creature>(); 

    public static void Init()
    {
        
    }

    public static void Clear()
    {
        
    }

    public static void Create(CreatureType type, Vector3 position)
    {
        if (type == CreatureType.Wolf)
        {
            Creature creature = GameObject.Instantiate(_Wolf); 
            creature._position = position; 
            _list.Add(creature); 
        }
    }

    public static void Destroy()
    {
        
    }
}
