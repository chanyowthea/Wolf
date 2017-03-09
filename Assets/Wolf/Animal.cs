using UnityEngine;
using System.Collections;

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
    #endregion



    #region Attack 

    public void Attack(Creature victim)
    {
        victim.Hurt(); 
    }

    #endregion



    #region Move
    [Header("Animal")]
    [SerializeField] protected int moveSpeed; 
    [SerializeField] protected int visualField; 
    [SerializeField] protected int huntingField; 

    IEnumerator moveUpdate; 
    Vector3 moveDestination; 

    void MoveInit()
    {
        moveUpdate = MoveUpdate(); 
    }

    public virtual void Move(Vector3 destination)
    {
        moveDestination = destination; 
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
        }
        yield return null; 
    }
    #endregion

}
