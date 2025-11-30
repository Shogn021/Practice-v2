using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float moveSpeed; // 캐릭터의 이동 속도

    public Vector3 moveVector; // 캐릭터의 이동 방향 벡터

    public bool canMove = true; // 캐릭터가 이동할 수 있는지 여부
    

    public Animator animator; // 캐릭터의 애니메이터 컴포넌트

    public void Flip()
    {
        if(moveVector.x < 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = -1f;
            transform.localScale = scale;
        }
        else if(moveVector.x > 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = 1f;
            transform.localScale = scale;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
