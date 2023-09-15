using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnims : MonoBehaviour
{
    private Animator anim;

    IEnumerator Start()
    {
        anim = GetComponent<Animator>();

        while (true)
        {
            yield return new WaitForSeconds(8);

            anim.SetInteger("MenuIndexAnim", Random.Range(0, 3));
            anim.SetTrigger("MenuActive");
        }
    }



}
