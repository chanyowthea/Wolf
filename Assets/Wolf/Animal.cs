using UnityEngine;
using System.Collections;

public enum EAnimaStatus
{
    Patrol, 
    Chase, 
    Attack, 
}

public class Animal : Creature
{
    #region Main

    protected override void Init()
    {
        base.Init(); 
        MoveInit(); 
    }

    void Update()
    {

    }

    public void Set(Color color)
    {
        GetComponent<Renderer>().material.color = color; 
    }
    #endregion



    #region Attack 

    public void Attack(Creature victim)
    {
        victim.Hurt(); 
    }

    #endregion



    #region Move
    [Header("Animal")]
    [SerializeField] protected float moveSpeed = 0.2f; 
    [SerializeField] protected int visualField; 
    [SerializeField] protected int huntingField; 
    [SerializeField] protected float haltDistance; 
    [SerializeField] protected float changeDirectionTime = 3f; 

    IEnumerator moveUpdate; 
    Vector3 moveDestination; 


    void MoveInit()
    {
        moveUpdate = MoveUpdate(); 
    }

    public virtual void Move(Vector3 destination)
    {
        destination.y += transform.GetComponent<Renderer>().bounds.center.y; 
        moveDestination = destination; 
        StopCoroutine(moveUpdate); 
        StartCoroutine(moveUpdate); 
    }

    public virtual void Stand()
    {
        StopCoroutine(moveUpdate); 
    }

    IEnumerator MoveUpdate()
    {
        while (true)
        {
            yield return null; 
            transform.position += (moveDestination - transform.position).normalized * Time.deltaTime * moveSpeed; 
            transform.LookAt(moveDestination); 
            if(Mathf.Abs(Vector3.Distance(transform.position, moveDestination)) < haltDistance)
            {
                StopCoroutine(moveUpdate); 
            }
        }
    }
    #endregion

}
