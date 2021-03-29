using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float movementSpeed = 3.0f;
    Vector2 movement = new Vector2();

    string animationState = "AnimationState";
    Rigidbody2D rb2D;
    Animator animator;

    enum CharState
    {
        walkEast = 1,
        walkSouth = 2,
        walkWest = 3,
        walkNorth = 4,
        idleSouth = 5
    }

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        UpdateState();
    }

    void FixedUpdate()
    {
        MoveCharacter();
    }

    private void MoveCharacter()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement.Normalize();
        rb2D.velocity = movement * movementSpeed;
    }

    private void UpdateState()
    {
        if (movement.x > 0)
        {
            animator.SetInteger(animationState, (int)CharState.walkEast);
        }
        else if (movement.x < 0)
        {
            animator.SetInteger(animationState, (int)CharState.walkWest);
        }
        else if (movement.y > 0)
        {
            animator.SetInteger(animationState, (int)CharState.walkNorth);
        }
        else if (movement.y < 0)
        {
            animator.SetInteger(animationState, (int)CharState.walkSouth);
        }
        else
        {
            animator.SetInteger(animationState, (int)CharState.idleSouth);
        }
    }

    private void test()
    {
        int number = 6;
        if (number < 10) {
            print("number는 10보다 작다");
            if (number < 9) {
                print("number는 9보다 작다");
                if (number < 8) {
                    print("number는 8보다 작다");
                    if (number < 7){
                        print("number는 7보다 작다");
                    } else {
                        print("number는 7보다 크거나 같다");
                    }
                } else {
                    print("number는 8보다 크거나 같다");
                }
            } else {
                print("number는 9보다 크거나 같다");
            }
        } else {
            print("number는 10보다 크거나 같다");
        }
    }
}
