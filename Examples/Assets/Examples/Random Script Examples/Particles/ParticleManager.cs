using UnityEngine;

public static class ParticleManager : MonoBehaviour
{
    /// <summary>
    /// Spawns a burst particle prefab at the given position
    /// </summary>
    /// <param name="particlePrefab">Particle system to spawn (Gameobject with particle system applied)</param>
    /// <param name="position">Position to spawn the particlePrefab at</param>
    /// <param name="color">Color to set the particlePrefab to</param>
    /// <param name="gradient">Gradient to set the particlePrefab to</param>
    public static void SpawnBurstParticle(GameObject particlePrefab, Vector3 position, Color color = default, Gradient gradient = default)
    {
        GameObject particleInstance = Instantiate(particlePrefab, position, Quaternion.identity);

        if (color != default) SetParticleSystemColor(color);
        else if (gradient != default) SetParticleSystemGradientColor(gradient);

        ps.Play();

        float particleLife = ps.main.duration + ps.main.startLifetime.constantMax
        Destroy(particleInstance, particleLife);
    }

    private void SetParticleSystemColor(GameObject particleSystem, Color color)
    {
        if (!particleInstance.TryGetComponent<ParticleSystem>(out var ps))
        {
            PrintMissingParticleSystemMessage(particleSystem.name)
            Destroy(particleInstance);
            return;
        }

        var main = ps.main;
        main.startColor = color;
    }

    private void SetParticleSystemGradientColor(GameObject particleSystem, Gradient gradient)
    {
        if (!particleInstance.TryGetComponent<ParticleSystem>(out var ps))
        {
            PrintMissingParticleSystemMessage(particleSystem.name);
            Destroy(particleInstance);
            return;
        }

        var main = ps.main;
        main.startColor = gradient;
    }

    private void PrintMissingParticleSystemMessage(string name) {
        Debug.LogWarning("The \"" particleSystem.name + "\" Prefab has no ParticleSystem component!");
    }
}
