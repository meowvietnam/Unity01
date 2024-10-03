using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using static UnityEngine.RuleTile.TilingRuleOutput;

public enum AnimState
{
    Idle = 0,
    Run = 1,
    Hurt = 2,

}
public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private float speed;
    private Animator anim;
    public static Player instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("GameObject này đã tồn tại");
            Destroy(gameObject);
        }
        anim = gameObject.GetComponent<Animator>();
    }

    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       

    }
 
    public float GetSpeed()
    {
        return speed;
    }
    public void SetSpeed(float value)
    {
        this.speed = value;
    }
    // Update is called once per frame
    void Update()
    {
        ClampPosPlayer();
        SetView();
        PlayerMove();
    }
    void PlayerMove()
    {
        if (anim.GetInteger("Anim") != (int)AnimState.Hurt)
        {
            transform.position += new Vector3(1, 0, 0) * InputManager.instance.GetHorizontal() * speed * Time.deltaTime;
        }
    }
    void ClampPosPlayer()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x,-8.35f,8f),transform.position.y,transform.position.z);
    }
    void SetView()
    {
        if(anim.GetInteger("Anim") != (int)AnimState.Hurt)
        {
            if (InputManager.instance.GetHorizontal() != 0)
            {
                SetUpAnimation(AnimState.Run);
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x)*InputManager.instance.GetHorizontal(),transform.localScale.y,transform.localScale.z);

            }
            else
            {
                SetUpAnimation(AnimState.Idle);
            }
        }    
         
    }    
    public void SetUpAnimation(AnimState animState)
    {
        anim.SetInteger("Anim", (int)animState);
    }    
    IEnumerator SetAnimHurtCoroutine()
    {
        SetUpAnimation(AnimState.Hurt);
        yield return new WaitForSeconds(1f);
        SetUpAnimation(AnimState.Idle);
    }   
    public void SetAnimHurt()
    {
        StartCoroutine(SetAnimHurtCoroutine());
    }    
}
