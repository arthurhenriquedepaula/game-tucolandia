using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class zombieRadar : MonoBehaviour
{
    private Transform target; //drag and stop player object in the inspector
    public float _range;
    public float speed;
    public float rotationSpeed;
    private Animator zombieAnim;
    void Start()
    {
        zombieAnim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Personagem")
        {
            Debug.Log("Enter");
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Personagem")
        {
            zombieAnim.SetBool("runZombie", true);
            target = collision.gameObject.transform;
            transform.rotation = Quaternion.Slerp(transform.rotation,
            Quaternion.LookRotation(
            target.position - transform.position),
            rotationSpeed * Time.deltaTime);
            float dist = Vector3.Distance(target.position, transform.position);
            if (dist <= _range)
            {
                transform.position = Vector3.MoveTowards(transform.position,
                target.transform.position, speed);
            }
            Debug.Log("Stay");
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Personagem")
        {
            zombieAnim.SetBool("runZombie", false);
            zombieAnim.SetBool("idleZombie", true);
            transform.position = Vector3.MoveTowards(transform.position,
            target.transform.position, 0);
            Debug.Log("Exit");
        }
    }
}
