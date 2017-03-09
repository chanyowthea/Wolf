using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        Init(); 
    }

    void Init()
    {
        CreatureManager.Init(); 
        CreatureManager._Wolf = GameData.instance._Wolf; 
        CreatureManager.Create(CreatureType.Wolf, Vector3.zero); 
    }
	
    void Update()
    {
	
    }
}
