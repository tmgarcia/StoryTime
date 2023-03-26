using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    // this [SerializeField] attribute makes it so this "m_doRandomAnimButton" field is exposed for hookup in the inspector
    // so when you click the gameobject with this script on it in the hierarchy, the "Inspector" window shows the Main script instance as having a "DoRandomAnimButton" slot
    // that the UI button gameobject can be dragged into
    [SerializeField]
    private Button m_doRandomAnimButton;

    [SerializeField]
    private Character m_characterPrefab;

    [SerializeField]
    private GameObject m_leftCharacterSpawnLocation;

    [SerializeField]
    private GameObject m_rightCharacterSpawnLocation;

    private List<RandomAction> m_potentialRandomActions;

    // Start is called before the first frame update
    void Start()
    {
        m_doRandomAnimButton.onClick.AddListener(OnDoRandomAnimClicked);

        m_potentialRandomActions = new List<RandomAction>();
        m_potentialRandomActions.Add(new SpawnCharacterAction(m_characterPrefab, m_leftCharacterSpawnLocation.transform.position));
        m_potentialRandomActions.Add(new SpawnCharacterAction(m_characterPrefab, m_rightCharacterSpawnLocation.transform.position));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDoRandomAnimClicked()
    {

    }
}