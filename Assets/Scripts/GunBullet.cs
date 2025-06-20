using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyBullet", 2.5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(DestroyOnContact());
    }

    IEnumerator DestroyOnContact()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(this.gameObject);
    }

    // this function destroys the bullet
    void DestroyBullet()
    {
        Destroy(this.gameObject); //destroys the bullet (object where the script is attached)
    }
}
