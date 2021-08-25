using UnityEngine;

[RequireComponent(typeof(PlayerScore))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private string _name;
    [SerializeField] private ParticleSystem _hitParticle;

    public string Name => _name;

    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

            if (Physics.Raycast(ray, out RaycastHit hit, 300f))
            {
                if (hit.collider.TryGetComponent<Enemy>(out Enemy enemy))
                {
                    _hitParticle.gameObject.transform.position = hit.point;
                    _hitParticle.Play();
                    enemy.TakeDamage(_damage);
                }
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, 300f))
            {
                if (hit.collider.TryGetComponent<Enemy>(out Enemy enemy))
                {
                    _hitParticle.gameObject.transform.position = hit.point;
                    _hitParticle.Play();
                    enemy.TakeDamage(_damage);
                }
            }
        }
    }

    public void SetPlayerName(string playerName)
    {
        _name = playerName;
    }
    
}