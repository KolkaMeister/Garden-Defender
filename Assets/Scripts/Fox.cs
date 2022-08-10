using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject ColObject = collision.gameObject;
        if (ColObject.GetComponent<GraveStone>())
        {
            GetComponent<Animator>().SetTrigger("jumpTrigger");
        }

            else if (ColObject.GetComponent<Defender>())
        {
            Defender target = ColObject.GetComponent<Defender>();
            GetComponent<Attaker>().Attack(target);
        }

    }
}
