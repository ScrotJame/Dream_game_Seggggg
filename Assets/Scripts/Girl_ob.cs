using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Girl_ob : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] Transform Boy;
    [SerializeField] float argoRange; // thanh tam nhin
    [SerializeField] float moveSpeed;
    [SerializeField] Transform CastPoint;
    bool isFacingLeft;
    bool isArgo;
    bool isSearching;
    [SerializeField] LayerMask layer;

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Boy"))
        {
            Debug.Log("Win");
        }
    }
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void Update()
    {
        if(SeeMan(argoRange))
        {
            if (isArgo)
            {
                if (!isSearching)
                {
                    isSearching = true;
                    Invoke("StandEnemy", 0);
                }
            }
            
        }
        else
        {

            isArgo = true;
            MoveEnemy();
        }
    }

   
    bool SeeMan(float distance)
    {
        bool val = false;
        float castDist = distance;
        if (isFacingLeft)
        {
            castDist = distance;
        }
        Vector2 enPos = CastPoint.position + Vector3.right * castDist;


        RaycastHit2D hit = Physics2D.Linecast(CastPoint.position, enPos, 1 << LayerMask.NameToLayer("Action"));
        if (hit.collider != null)
        {
            //if Ob1 see Tag go to this
            if (hit.collider.gameObject.CompareTag("Boy"))
            {
                //Go to enemy
                val = false;
            }
            //else stop move
            else
            {
                val = true;
            }
            Debug.Log("Thay vat can");
            Debug.DrawLine(CastPoint.position, hit.point, Color.blue);
        }
        else
        {
            Debug.Log("Khong con vat can");
            Debug.DrawLine(CastPoint.position, enPos, Color.red);
        }
        return val;
    }
    public void MoveEnemy()
    {
        if(transform.position.x < Boy.position.x)
        {
            rb.velocity = new Vector2(moveSpeed, 0);
            transform.localScale = new Vector2(1,1);
            isFacingLeft = false;
        }
        else
        {
            rb.velocity = new Vector2(-moveSpeed, 0);
            transform.localScale = new Vector2(-1, 1);
            isFacingLeft = true;
        }
    }
    public void StandEnemy()
    {
        isArgo = false;
        isSearching = false;
        rb.velocity = new Vector2(0, 0);
    }

    
}
