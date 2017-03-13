using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    System.Random _random = new System.Random(); 

    void Start()
    {
        Init(); 
    }

    void Init()
    {
        CreatureManager.Init(); 
        CreatureManager._Wolf = GameData.instance._Wolf; 
        CreatureManager._Sheep = GameData.instance._Sheep; 
        CreatureManager.Create(ECreatureSpecies.Wolf, new Vector3(Random.value * 25f, 0.5f, Random.value * 25f)); 
        CreatureManager.Create(ECreatureSpecies.Sheep, new Vector3(Random.value * 25f, 0.5f, Random.value * 25f)); 
    }
	
    void Update()
    {
        Move(); 
        View(); 
    }

    void Move()
    {
        RaycastHit hit = new RaycastHit(); 
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 

        if (Input.GetButtonDown("Fire2") && Physics.Raycast(ray, out hit, 100f, LayerMask.GetMask("Floor")))
        {
            Animal animal = CreatureManager._curSelected as Animal; 
            if (animal != null)
            {
                animal.Move(hit.point); 
            }
            Debug.Log("Move to: " + hit.point); 
        }

        if (Input.GetButtonDown("Fire1") && Physics.Raycast(ray, out hit, 100f, LayerMask.GetMask("Player")))
        {
            CreatureManager._curSelected = hit.transform.GetComponent<Creature>(); 
            Debug.Log("Choose: " + hit.point); 
        }

    }

    void View()
    {
        float wheel = Input.GetAxis("Mouse ScrollWheel"); 
        if (wheel != 0)
        {
            Debug.Log("wheel: " + wheel); 
            int field = (int)(Camera.main.fieldOfView + -wheel * 10); 
            if (field > 0 && field < 180)
            {
                Camera.main.fieldOfView = field; 
            }
        }

        float x = 0; 
        if (Input.GetKey(KeyCode.Q))
        {
            x = -1;
        }
        if (Input.GetKey(KeyCode.E))
        {
            x = 1; 
        }
        if (x != 0)
        {
            Camera.main.transform.eulerAngles += new Vector3(0, x, 0); 
        }

        float h = Input.GetAxis("Horizontal"); 
        float v = Input.GetAxis("Vertical"); 
        Camera.main.transform.position += new Vector3(h, 0, v); 
    }
}
