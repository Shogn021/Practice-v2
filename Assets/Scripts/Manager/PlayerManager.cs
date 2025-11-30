using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : CharacterController
{
    #region Singleton
    public static PlayerManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    public GameObject escTab;

    [SerializeField]
    Vector2 inputVector;

    public float runSpeed;
    private float applyRunSpeed;

    public bool isRun;
    public bool isEscTabActivated;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    #region Input System
    void OnMove(InputValue value)
    {
        inputVector = value.Get<Vector2>();
        moveVector = new Vector3(inputVector.x, inputVector.y, 0);
    }

    void OnRun(InputValue value)
    {
        isRun = value.isPressed;
        if (isRun)
        {
            applyRunSpeed = runSpeed;
        }
        else
        {
            applyRunSpeed = 0f;
        }
    }

    void OnEsc(InputValue value)
    {
        isEscTabActivated = value.isPressed;

        if (isEscTabActivated)
        {
            escTab.SetActive(true);
            canMove = false;
        }
    }

    #endregion Input System


    // Update is called once per frame
    void Update()
    {
        if (!canMove)
        {
            return;
        }

        if (CheckCollision()) // 충돌 감지
        {
            return;
        }

        
        bool isWalking = (inputVector != Vector2.zero);
        animator.SetBool("Walking", isWalking);
        animator.SetBool("Running", isRun);

        base.Flip();

        if (isWalking)
        {
            transform.position += moveVector * (moveSpeed + applyRunSpeed) * Time.deltaTime;
        }

    }
}
