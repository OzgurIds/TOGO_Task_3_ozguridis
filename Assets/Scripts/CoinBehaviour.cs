using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviour : MonoBehaviour
{

//Just for coin spin
    void Awake()
    {
        if (gameObject.tag == "Coin")
        {
            StartCoroutine(Shift());
        }
    }
    void Update()
    {
        transform.Rotate(0f, 0.5f, 0f);
    }

    public IEnumerator Shift()
    {//TODO: InvokeRepeating
        while (enabled)
        {
            float x = Random.Range(-6.7f, 6.5f);
            transform.position = new Vector3(x, transform.position.y, transform.position.z);
            yield return new WaitForSeconds(2f);
        }
    }


}
