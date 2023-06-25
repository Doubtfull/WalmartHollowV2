using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Talentless
{
    public class WallInteracter : MonoBehaviour
    {
        public bool WallJumping {  get; private set; }
        
        [Header("Wall Slide")]
        [SerializeField][Range(0.1f, 5f)] private float wallSlideMaxSpeed = 2f;
        [Header("Wall Jump")]
        [SerializeField] private Vector2 wallJumpClimb = new Vector2(4f, 12f);
        [SerializeField] private Vector2 wallJumpBounce = new Vector2(14f, 10f);

        private Ground collisionDataRetriever;
        private Rigidbody2D rb;
        [SerializeField] private InputController input = null;


        private Vector2 velocity;
        private bool onWall, onGround, desiredJump;
        private float wallDirectionX;
        
        // Start is called before the first frame update
        void Start()
        {
            collisionDataRetriever = GetComponent<Ground>();
            rb = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            if (onWall && !onGround)
            {
                desiredJump |= input.RetrieveJumpInput();
            }
        }

        private void FixedUpdate()
        {
            velocity = rb.velocity;
            onWall = collisionDataRetriever.OnWall;
            onGround = collisionDataRetriever.onGround;
            wallDirectionX = collisionDataRetriever.ContactNormal.x;

            #region Wall Slide
            if (onWall)
            {
                if (velocity.y < -wallSlideMaxSpeed)
                {
                    velocity.y = -wallSlideMaxSpeed;
                }
            }
            #endregion

            #region WallJump
            
            if ((onWall && velocity.x == 0) || onGround)
            {
                WallJumping = false;
            }
            
            if (desiredJump)
            {
                if (-wallDirectionX == input.RetrieveMoveInput())
                {
                    velocity = new Vector2(wallJumpClimb.x * wallDirectionX, wallJumpClimb.y);
                    WallJumping = true;
                    desiredJump = false;
                }
                else if (input.RetrieveMoveInput() == 0)
                {
                    velocity = new Vector2(wallJumpBounce.x * wallDirectionX, wallJumpBounce.y);
                    WallJumping = true;
                    desiredJump = false;
                }
            }
            #endregion

            rb.velocity = velocity;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            collisionDataRetriever.EvaluateCollision(collision);
            if(collisionDataRetriever.OnWall && !collisionDataRetriever.onGround && WallJumping)
            {
                rb.velocity = Vector2.zero;
            }
        }
    }
}

