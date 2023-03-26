using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Base class for randomly performed actions
public abstract class RandomAction
{
    // IDK, whatever data things needs to be for... probability
    public float ProbabilityHeuristic { get; set; }

    // This is for checking if the action is even possible based on current state, regardless of probability shenanigans
    public abstract bool CanDoAction();
    public abstract void DoAction();// TODO: Actually this should be a coroutine
}


// Random action for spawning a character in a spot
public class SpawnCharacterAction : RandomAction
{
    private Character m_characterPrefab;
    private Vector3 m_spawnLocation;

    public Character InstantiatedCharacter
    {
        get;
        private set;
    }

    // Assumes you only want to spawn a character at a specific spot once
    // If you want to spawn them more than once I guess you'd need to track if the spawned character is still standing there, or if they've moved & made space for new spawn
    private bool m_hasSpawnedCharacterAtThisLocation;

    public SpawnCharacterAction(Character characterPrefab, Vector3 spawnLocation)
    {
        m_characterPrefab = characterPrefab;
        m_spawnLocation = spawnLocation;
    }

    public override bool CanDoAction()
    {
        return !m_hasSpawnedCharacterAtThisLocation;
    }

    public override void DoAction()
    {
        InstantiatedCharacter = MonobehaviourHelper.Instance.InstantiatePrefab(m_characterPrefab.gameObject, m_spawnLocation, Quaternion.identity).GetComponent<Character>();
        m_hasSpawnedCharacterAtThisLocation = true;
    }
}


// Base class for actions that a character can do
public abstract class CharacterAction : RandomAction
{
    protected Character m_characterInstance;
    public CharacterAction(Character characterInstance)
    {
        m_characterInstance = characterInstance;
    }
}

// Example of triggering character animation
public class CharacterFlailAction : CharacterAction
{
    public CharacterFlailAction(Character characterInstance): base(characterInstance)
    {
    }

    public override bool CanDoAction()
    {
        return true;
    }

    public override void DoAction()
    {
        m_characterInstance.Animator.SetTrigger("Flail");
    }
}

public class CharacterMoveAction : CharacterAction
{
    public CharacterMoveAction(Character characterInstance) : base(characterInstance)
    {
    }

    public override bool CanDoAction()
    {
        return true;
    }

    public override void DoAction()
    {
        
    }
}