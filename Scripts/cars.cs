using UnityEngine;

public class cars : MonoBehaviour
{
    [SerializeField] private Vector3 _direction;
    [SerializeField] private float _speed;
    private Rigidbody _rigidbody;

    void Awake() =>
        _rigidbody = GetComponent<Rigidbody>();

    void Start()
    {
        _speed -= 7f;
        _direction.x = 1;
    }

    

    void Update()
    {
        if (PlayerPrefs.GetInt("IS_Start") == 0) return;
        _rigidbody.MovePosition(transform.position + _direction * Time.deltaTime * _speed);
    }
}
