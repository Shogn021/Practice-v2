using Unity.VisualScripting;
using UnityEngine;

public class EnemyManager : CharacterController
{
    public Transform playerTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(playerTransform.position, this.transform.position) <= 4f)
        {
            Initialize();
            FollowPlayer();
        }
        else
        {
            animator.SetBool("Run",false);
        }
    }

    public void Initialize()
    {
        if (playerTransform.position.x < this.transform.position.x)
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    public void FollowPlayer()
    {
        if(Vector2.Distance(playerTransform.position, this.transform.position) >= 1)
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, playerTransform.position, Time.deltaTime * moveSpeed);
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
        }
    }
}
