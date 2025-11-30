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

    public bool CheckCollision()
    {
        Vector2 start = this.transform.position;
        Vector2 end = start + new Vector2(moveVector.x, moveVector.y) * 0.2f;

        RaycastHit2D hit = Physics2D.Linecast(start, end, LayerMask.GetMask("Wall"));

        if (hit.collider != null)
            return true; // 충돌이 발생함
        else
            return false; // 충돌이 없음
    }

}
