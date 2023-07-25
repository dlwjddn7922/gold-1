using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Speed;
    float h;
    float v;
    bool isHorizontal;
    Rigidbody2D rigid;
    Animator anim;
    Vector3 dirVec;
    GameObject scanObj;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        bool hDown = Input.GetButtonDown("Horizontal");
        bool vDown = Input.GetButtonDown("Vertical");
        bool hUp = Input.GetButtonUp("Horizontal");
        bool vUp = Input.GetButtonUp("Vertical");

        if (hDown)
            isHorizontal = true;
        else if (vDown)
            isHorizontal = false;
        else if (hUp || vUp)
            isHorizontal = h != 0;
        //animation
        if(anim.GetInteger("hAxisRaw") != h)
        {
            anim.SetBool("isChange",true);
            anim.SetInteger("hAxisRaw", (int)h);
        }
        else if(anim.GetInteger("vAxisRaw") != v)
        {
            anim.SetBool("isChange", true);
            anim.SetInteger("vAxisRaw", (int)v);
        }
        else
        {
            anim.SetBool("isChange", false);
        }

        //Direction
        if (vDown && v == 1)
            dirVec = Vector3.up;
        if (vDown && v == -1)
            dirVec = Vector3.down;
        if (hDown && h == -1)
            dirVec = Vector3.left;
        if (hDown && h == 1)
            dirVec = Vector3.right;

        //Scan Object
        if(Input.GetButtonDown("Jump") && scanObj != null)
        {
            Debug.Log("This is :" + scanObj.name);
        }



    }
    private void FixedUpdate()
    {
        Vector2 moveVec = isHorizontal ? new Vector2(h, 0) : new Vector2(0, v);
        rigid.velocity = moveVec * Speed;

        //Ray
        Debug.DrawRay(rigid.position, dirVec * 0.7f,new Color(0,1,0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 0.7f, LayerMask.GetMask("Object"));

        if(rayHit.collider != null)
        {
            scanObj = rayHit.collider.gameObject;
        }
        else
        {
            scanObj = null;
        }
    }
}
