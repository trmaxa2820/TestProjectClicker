using UnityEngine;

[RequireComponent(typeof(PlayerScore))]
public class Player : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private PlayerAttack _playerAttack;

    public string Name => _name;

    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            _playerAttack.Attack(Input.GetTouch(0).position);
        }

        if (Input.GetMouseButtonDown(0))
        {
            _playerAttack.Attack(Input.mousePosition);
        }
    }

    public void SetPlayerName(string playerName)
    {
        _name = playerName;
    }
    
    public void SetAttackPlayer(PlayerAttack playerAttack)
    {
        _playerAttack = playerAttack;
    }
}