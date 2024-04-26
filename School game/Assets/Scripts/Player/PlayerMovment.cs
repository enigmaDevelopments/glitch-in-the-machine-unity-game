using player;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
    public class PlayerMovment : MonoBehaviour
    {
        public Rigidbody2D rb;
        public Transform groundCheck;
        public Transform groundCheck2;
        public Transform buttonCheck;
        public Transform buttonCheck2;
        public LayerMask groundLayer;
        public LayerMask buttonLayer;
        private float horizantal;
        public float speed = 8f;
        public float jump = 16f;
        public float coyoteTime = .1f;
        private static bool _facingRight = true;
        private bool notJumped = false;
        private float timeFromGround = 100f;
        private Checker check;

        public static bool FacingRight
        {
            get
            {
                return _facingRight;
            }
        }
        private void Start()
        {
            check = gameObject.GetComponent<Checker>();
        }
        void Update()
        {
            horizantal = Input.GetAxisRaw("Horizontal") * speed;
            _facingRight = horizantal == 0f ? _facingRight : horizantal > 0f;
            #region kyote timer
            if (check.checkArea())
            {
                notJumped = true;
                timeFromGround = 0;
            }
            else
                timeFromGround += Time.deltaTime;
            #endregion
            #region jump
            if (Input.GetButtonDown("Jump") && Grounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jump);
                notJumped = false;
            }
            if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * .5f);
            }
            #endregion
            #region reset
            if (Input.GetButtonDown("Restart"))
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            #endregion
            #region buttonPressed
            if (Input.GetButtonDown("use"))
            {
                foreach (GameObject button in check.checkAreaAll(2, 1)) 
                    button.GetComponent<ButtonActivator>().press();
            }
            #endregion
            Flip(gameObject);
        }

        void FixedUpdate()
        {
                rb.velocity = new Vector2(horizantal, rb.velocity.y);
        }

        #region find groundedness
        public bool Grounded()
        {
            return notJumped && timeFromGround <= coyoteTime;
        }
        public static GameObject[] checkAreaAll(Transform check, Transform check2, LayerMask layers,GameObject self)
        {
            return (from col in Physics2D.OverlapAreaAll(check.position, check2.position, layers) where col.gameObject != self select col.gameObject).ToArray();
        }
        #endregion
        public static void Flip(GameObject gameObject)
        {
            Vector3 localScale = gameObject.transform.localScale;
            Vector3 lossyScale = gameObject.transform.lossyScale;
            int parentScale = gameObject.GetComponent<ParentPlayerToMovable>().ParentScaleDir;
            localScale.x = Mathf.Abs(localScale.x) * (_facingRight? 1f:-1f) * parentScale;
            gameObject.transform.localScale = localScale;
        }
    }
}
//code built off of code from https://youtu.be/K1xZ-rycYY8?si=75u7qfzw8e_qC1ck