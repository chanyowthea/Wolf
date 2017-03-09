using UnityEngine;
using System.Collections;

public class Creature : MonoBehaviour
{
    [Header("Creature")]
    [SerializeField] protected int curHP = 1; 
    [SerializeField] protected int fullHP = 1; 
    [SerializeField] protected int defence; 
    [SerializeField] protected int attack; 
    [SerializeField] protected int attackSpeed; 
    [SerializeField] public Vector3 _position; 

    protected int _id; 

    protected virtual void Init()
    {
        curHP = fullHP; 
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
