using UnityEngine;
using System.Collections;

public class GameData : MonoBehaviour
{
    static GameData _instance; 
    public static GameData instance
    {
        get
        {
            return _instance; 
        }
    }

    [SerializeField] public Wolf _Wolf; 
    [SerializeField] public Sheep _Sheep; 

    void Awake()
    {
        _instance = this; 
    }
}
