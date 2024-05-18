using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator anim;

    public void Move(bool isMoving)
    {
        anim.SetBool("Moving", isMoving);
    }

    public void Jump(bool jumping) {
        anim.SetBool("Jumping", jumping);
    }

    public void Attack() {
        anim.SetTrigger("Attack");
    }
}
