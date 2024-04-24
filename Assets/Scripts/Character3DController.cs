using StarterAssets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character3DController : MonoBehaviour
{
    [SerializeField]
    float attackRate;

    [SerializeField]
    float attackRange;

    [SerializeField]
    Weapon[] weapons;

    StarterAssetsInputs _input;
    Animator _animator;
    Weapon _currentWeapon;

    CharacterController _characterController;

    int _attackHash;
    bool _attackState;
    float _attackTime;
    int _currentWeaponIndex = 0;


    //[SerializeField]
    //Transform attackPoint; //Utilizado para el dibujo gizmos

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();

        _input = GetComponent<StarterAssetsInputs>();
        _animator = GetComponent<Animator>();

        foreach (var weapon in weapons)
        {
            weapon.SetAnimatorHash(Animator.StringToHash(weapon.GetName()));
        }

        SetWeapon(_currentWeaponIndex);
    }

    private void Update()
    {
        //Me muevo/cambio de arma a la izquierda
        if (_input.switchLeft)
        {
            if (_currentWeaponIndex > 0)
            {
                _currentWeaponIndex--;
                SetWeapon(_currentWeaponIndex);
            }

            _input.switchLeft = false;
        }

        //Me muevo/cambio de arma a la derecha
        if (_input.switchRight)
        {
            if (_currentWeaponIndex < weapons.Length - 1)
            {
                _currentWeaponIndex++;
                SetWeapon(_currentWeaponIndex);
            }

            _input.switchRight = false;
        }


        if (_attackTime > 0.0F)
        {
            _attackTime -= Time.deltaTime;
            _attackTime = Mathf.Clamp(_attackTime, 0.0F, attackRange);
        }


        if (_attackState != _input.attack)
        {
            _attackState = _input.attack;

            if (_attackState && _attackTime == 0.0F)
            {
                _animator.SetTrigger(_attackHash);
                _attackTime = (attackRange / attackRate);
            }
        }

        //Acá se usa el ShootWeapon, debe usar el mismo attackTime
    }

    public void SetWeapon(int current)
    {
        if (_currentWeapon != null)
        {
            _currentWeapon.GetContainer().gameObject.SetActive(false);
        }

        _currentWeapon = weapons[current];
        _currentWeapon.GetContainer().gameObject.SetActive(true);
        _attackHash = _currentWeapon.GetAnimatorHash(); 
    }


    public CharacterController GetCharacterController()
    {
        return _characterController;
    }


    //private void OnDrawGizmos()   Sirve para dibujar en el unity y poder ver mejor algunas cosas
    //{
    //    Gizmos.color = Color.yellow;
    //    Gizmos.DrawSphere(attackPoint.position, 0.50F);
    //}

}
