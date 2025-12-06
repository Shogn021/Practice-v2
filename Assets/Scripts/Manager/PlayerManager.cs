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
    public GameObject inventoryTab;
    public GameObject statusTab;

    [SerializeField]
    Vector2 inputVector;

    public float runSpeed;
    private float applyRunSpeed;

    public bool isWalking;
    public bool isRun;
    public bool isEscTabActivated = false;
    public bool isInventoryTabActivated = false;


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

    void OnInventory(InputValue value)
    {
        isInventoryTabActivated = !isInventoryTabActivated;
        if (isInventoryTabActivated)
        {
            inventoryTab.SetActive(true);
            statusTab.SetActive(true);
            canMove = false;
        }
        else
        {
            inventoryTab.SetActive(false);
            statusTab.SetActive(false);
            canMove = true;
        }
    }


    #endregion Input System


    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            isWalking = (inputVector != Vector2.zero);

            if (CheckCollision()) // 충돌 감지
            {
                return;
            }

            animator.SetBool("Walking", isWalking);
            animator.SetBool("Running", isRun);


            base.Flip();


            transform.position += moveVector * (moveSpeed + applyRunSpeed) * Time.deltaTime;
        }
        else
        {
            animator.SetBool("Walking", false);
        }

    }
}
