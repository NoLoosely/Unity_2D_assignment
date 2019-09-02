using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script for controlling the Player - attached on Player object
/// For handling the movement-attacking and animations
/// </summary>
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb2D;
    private Vector2 _movementDirection = Vector2.zero;
    public float walkSpeed = 3f;
    public float runSpeed = 5f;
    public bool _isRunning = false;

    private Animator _anim;
    private float _inputX = 0f;
    private float _inputY = 0f;
    public bool isMoving = false;

    private float _lastMoveX = 0f;
    private float _lastMoveY = 0f;
    public bool _isAttacking = false;

    private EquipSlotController _equipmentController;
    public AudioSource swordSound;

    private float _attackRate = 1f, _lastAttack = 0f;

    void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _equipmentController = FindObjectOfType<EquipSlotController>();
    }

    void FixedUpdate()
    {
        if (!_isAttacking)
            Move();

        if(_equipmentController.SwordCollected)
            Attack();

        MoveAnimations();
    }


    void Move()
    {
        _inputX = Input.GetAxis("Horizontal");
        _inputY = Input.GetAxis("Vertical");

        _movementDirection = new Vector2(_inputX, _inputY);
        float movementSpeed = Mathf.Clamp(_movementDirection.magnitude, -1f, 1f);
        _movementDirection.Normalize();

        if(Input.GetKey(KeyCode.LeftShift) && _equipmentController.TotalStamina >= 28)
        {
            _rb2D.velocity = _movementDirection * movementSpeed * runSpeed;
            _isRunning = true;
        }
        else
        {
            _rb2D.velocity = _movementDirection * movementSpeed * walkSpeed;
            _isRunning = false;
        }

        isMoving = _rb2D.velocity.magnitude > 0.1f ? true : false;

        if (_rb2D.velocity.magnitude > 0.1f)
        {
            _lastMoveX = _movementDirection.x;
            _lastMoveY = _movementDirection.y;
        }


    }




    void MoveAnimations()
    {
        _anim.SetFloat("Horizontal", _inputX);
        _anim.SetFloat("Vertical", _inputY);
        _anim.SetBool("IsMoving", isMoving);
        _anim.SetFloat("LastMoveX", _lastMoveX);
        _anim.SetFloat("LastMoveY", _lastMoveY);
        _anim.SetBool("IsRunning", _isRunning);
    }


    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(Time.time > _lastAttack + _attackRate)
            {
                AttackAnimations();
                _lastAttack = Time.time;
            }
        }

        AnimatorStateInfo stateInfo = _anim.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.IsName("playerAttackRight") || stateInfo.IsName("playerAttackLeft"))
        {
            if (stateInfo.normalizedTime > 0.9f)
                _isAttacking = false;
        }
    }

    void AttackAnimations()
    {
       _rb2D.velocity = Vector2.zero;
        isMoving = false;
        _isAttacking = true;

        if(_lastMoveX < 0f)
            _anim.SetTrigger("AttackLeft");
        else
            _anim.SetTrigger("AttackRight");
    }


    void SwordSound()
    {
        swordSound.Play();
    }


} // class end
