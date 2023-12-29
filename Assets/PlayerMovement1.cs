using Fusion;
using UnityEngine;

public class PlayerMovement1S : NetworkBehaviour
{
    private CharacterController _controller;

    public float PlayerSpeed = 2f;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    public override void FixedUpdateNetwork()
    {
        // Only move own player and not every other player. Each player controls its own player object.
        if (HasStateAuthority == false)
        {
            return;
        }

        Vector2 move = new Vector2(Input.GetAxis("Horizontal"),0) * Runner.DeltaTime * PlayerSpeed;

        _controller.Move(move);

        if (move != Vector2.zero)
        {
            gameObject.transform.forward = move;
        }
    }
}