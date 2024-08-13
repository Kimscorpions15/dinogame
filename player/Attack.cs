using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private Animator anim;
    public float timesClicked = 0;
    public float lastTimeClicked = 0;
    private float comboDelay = 0.9f;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        timesClicked = Mathf.Clamp(timesClicked, 0, 3);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastTimeClicked > comboDelay)
        {
            timesClicked = 0;
        }
        if (Input.GetMouseButtonDown(0))
        {
            lastTimeClicked = Time.time;
            timesClicked++;

            if (timesClicked == 1)
            {
                anim.SetTrigger("attack3");
                // Debug.Log("ataque3");
            }
            if (timesClicked == 2)
            {
                anim.SetTrigger("attack4");
                // Debug.Log("ataque4");
            }
            if (timesClicked == 3)
            {
                anim.SetTrigger("attack5");
                // Debug.Log("ataque5");
            }
        }
        if (timesClicked >= 3)
        {
            return;
        }
    }
}
