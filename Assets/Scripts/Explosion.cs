using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private Vector3 _explosionForce;
    [SerializeField] private ParticleSystem _effect;

    public void Explode(Rigidbody cube)
    {
        cube.velocity = _explosionForce;
        Instantiate(_effect, cube.transform.position, cube.transform.rotation);
    }
}