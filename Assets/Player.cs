using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private float speed;
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
        PlayerMove();
    }
    void PlayerMove()
    {
        transform.position += new Vector3(1, 0, 0) * InputManager.instance.GetHorizontal() * speed * Time.deltaTime;
    }
    void ClampPosPlayer()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x,-8.35f,8f),transform.position.y,transform.position.z);
    }
}
