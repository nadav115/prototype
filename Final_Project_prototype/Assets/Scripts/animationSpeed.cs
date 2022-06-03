using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationSpeed : MonoBehaviour
{
    private Animator anim;
    public float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
