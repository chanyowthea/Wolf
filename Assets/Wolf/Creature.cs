using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class Creature : MonoBehaviour
{
    [Header("Creature")]
    [SerializeField] protected int curHP = 1; 
    [SerializeField] protected int fullHP = 1; 
    [SerializeField] protected int defence; 
    [SerializeField] protected int attack; 
    [SerializeField] protected int attackSpeed; 
    [SerializeField] public Text _displayName; 

    public Vector3 position
    {
        get
        { 
            return transform.position; 
        }
        set
        { 
            transform.position = value; 
        }
    }

    protected int _id; 

    protected virtual void Init()
    {
        curHP = fullHP; 
    }

    public void Set(int id, string name)
    {
        _id = id; 
        _displayName.text = name; 
    }

    public virtual void Hurt(int value = 1)
    {
        curHP -= value; 
        if (curHP <= 0)
        {
            Die(); 
        }
    }

    public virtual void Heal(int value = 1)
    {
        curHP += value; 
        if (curHP > fullHP)
        {
            curHP = fullHP; 
        }
    }

    public virtual void Die()
    {
        GameObject.Destroy(gameObject); 
    }
}
