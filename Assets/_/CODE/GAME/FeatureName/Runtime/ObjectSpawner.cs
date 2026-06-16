using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    #region Publics

    [Header("Configuration du Spawn")]
    public GameObject m_objectToSpawn;
    public Transform m_spawnPoint;

    [Header("Rythme")]
    [SerializeField] private float m_spawnInterval = 1.0f; // Temps en secondes entre chaque spawn

    #endregion


    #region Private and Protected

    private float m_timer = 0.0f;

    #endregion


    #region Unity API

    private void Update()
    {
        HandleSpawnTimer();
    }

    #endregion


    #region Main API

    private void HandleSpawnTimer()
    {
        // Sécurité
        if (m_objectToSpawn == null || m_spawnPoint == null) return;

        // On accumule le temps écoulé depuis la dernière frame.
        // Time.deltaTime est impacté par Time.timeScale ! 
        // Si le jeu va à 2x, le timer augmente deux fois plus vite.
        m_timer += Time.deltaTime;

        // Dès que le timer atteint ou dépasse l'intervalle requis
        if (m_timer >= m_spawnInterval)
        {
            BirthObject();

            // On reset le timer en soustrayant l'intervalle pour rester super précis
            m_timer -= m_spawnInterval;
        }
    }

    private void BirthObject()
    {
        Instantiate(m_objectToSpawn, m_spawnPoint.position, m_spawnPoint.rotation);
    }

    #endregion
}