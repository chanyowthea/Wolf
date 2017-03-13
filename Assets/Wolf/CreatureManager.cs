using UnityEngine;
using System.Collections;
using System.Collections.Generic; 

public enum ECreatureSpecies
{
    Wolf, 
    Sheep, 

    Grass, 
    Lily, 
}

public static class CreatureManager
{
    public static Wolf _Wolf; 
    public static Sheep _Sheep; 
    public static Creature _curSelected; 
    static List<Creature> _list = new List<Creature>(); 

    public static void Init()
    {
        
    }

    public static void Clear()
    {
        
    }

    public static void Create(ECreatureSpecies type, Vector3 position)
    { 
        Creature creature = null; 
        if (type == ECreatureSpecies.Wolf)
        {
            creature = GameObject.Instantiate(_Wolf); 
        }
        else if (type == ECreatureSpecies.Sheep)
        {
            creature = GameObject.Instantiate(_Sheep); 
        }
        if (creature == null)
        {
            return; 
        }

        creature.position = position; 
        _list.Add(creature); 
        int index = _list.Count - 1; 
        creature.Set(index, type + " " + index); 
    }

    public static void Destroy()
    {
        
    }
}
