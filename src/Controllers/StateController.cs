using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State {Idle, Walking, Jumping}

/* Universal rule for all characters */
public class StateController : MonoBehaviour
{
    public State state = State.Idle;
    public State[] possibleStates = {State.Walking, State.Jumping};
    public bool isPlayer = false;

    /*
    * Below is a simple state machine, state machines are a great way to avoid bugs*
    * e.g. "Unwanted Double Jumping" or "Moving While Player is Dead"
    */

    public void Handle(bool isMoving, bool isJumping)
    {
        if (possibleStates != null)
        {
            foreach (State possible in possibleStates)
            {
                if(possible == State.Idle && !isMoving)
                {
                    ToIdle();
                }
                else if (possible == State.Walking && isMoving)
                {
                    ToWalking();
                }
                else if (possible == State.Jumping && isJumping)
                {
                    ToJumping();
                }
            }
        }
    }

    public void ToIdle()
    {
        state = State.Idle;
        possibleStates = new State[] {State.Walking, State.Jumping};
    }

    public void ToWalking()
    {
        state = State.Walking;
        possibleStates = new State[] {State.Idle, State.Jumping};
    }

    public void ToJumping()
    {
        if (isPlayer)
        {
            Move2D controller = gameObject.GetComponent<Move2D>();
            controller.tempAccelleration = controller.jumpAccelleration; // tempAccelleration = positive float (Jumping)
            controller.isGrounded = false;
        }

        state = State.Jumping;
        Debug.Log("Jumping");
        possibleStates = null;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag.Equals("DeathPit") && state != State.Jumping)
        {
            Debug.Log("YOU DIED");
        }
    }
}
