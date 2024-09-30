using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private int horizontal;
    public static InputManager instance;
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

    // Update is called once per frame
    void Update()
    {
        CheckInput();
    }
    public int GetHorizontal()
    {
        return horizontal;
    }    
    void CheckInput()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            horizontal = -1;
        }   
        if(Input.GetKey(KeyCode.RightArrow))
        {
            horizontal = 1;

        }
        if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
        {
            horizontal = 0;
        }
        


    }    

}
