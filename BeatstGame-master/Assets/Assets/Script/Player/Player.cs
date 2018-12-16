using System.Collections;
using UnityEngine;


public class Player : MonoBehaviour
{
    private Rigidbody2D _rigid;
    [SerializeField]
    private float _jumpforce;
    private bool _resetJump = false;
    [SerializeField]
    private float _speed;
    [SerializeField]
    public float _health;
    private bool _grounded = false;
    public PlayerAnimation _playerAnim;
    private SpriteRenderer _playerSprite;
    private SpriteRenderer _swordArcSprite;
    // Use this for initialization
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _playerAnim = GetComponent<PlayerAnimation>();
        _playerSprite = GetComponentInChildren<SpriteRenderer>();
        _swordArcSprite = transform.GetChild(1).GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
       
        Movement();

        if (Input.GetMouseButtonDown(0))
        {
            _playerAnim.Attack();
            
        }

    }
    void Movement()
    {
        float move = Input.GetAxisRaw("Horizontal");
        _grounded = IsGrounded();
        if (move > 0)
        {
            Flip(true);
        }
        else if (move < 0)
        {
            Flip(false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded() == true)
        {
            _rigid.velocity = new Vector2(_rigid.velocity.x, _jumpforce);
            StartCoroutine(ResetJumpRoutine());
            _playerAnim.Jump(true);
        }

        _rigid.velocity = new Vector2(move * _speed, _rigid.velocity.y);
        _playerAnim.Move(move);
    }
        bool IsGrounded()
        {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 1f, 1 << 8);
            Debug.DrawRay(transform.position, Vector2.down, Color.green);
            if (hitInfo.collider != null)
            {
                if (_resetJump == false)
                {
                    _playerAnim.Jump(false);
                    return true;
                }
                
            }
            return false;
        }
    // thu hien kiem tra va cham giua player va cac doi tuong khac
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            print(gameObject.name + " OnCollisionEnter2D voi " + collision.gameObject.name);
            _playerAnim.Hit();
            _health -= 0;
            if(_health <= 0)
            {
                Destroy(this.gameObject);
                Application.LoadLevel("GameOver");
            }
        }
    }


    void Flip(bool faceRight)
    {
        if (faceRight == true)
        {
            _playerSprite.flipX = false;
            _swordArcSprite.flipX = false;
            _swordArcSprite.flipY = false;
            Vector3 newPos = _swordArcSprite.transform.localPosition;
            newPos.x = 1.01f;
            _swordArcSprite.transform.localPosition = newPos;
        }
        else if (faceRight == false)
        {
            _playerSprite.flipX = true;
            _swordArcSprite.flipX = true;
            _swordArcSprite.flipY = true;
            Vector3 newPos = _swordArcSprite.transform.localPosition;
            newPos.x = -1.01f;
            _swordArcSprite.transform.localPosition = newPos;
        }
    } 
    IEnumerator ResetJumpRoutine()
    {
        _resetJump = true;
        yield return new WaitForSeconds(0.6f);
        _resetJump = false;
    }
   
}