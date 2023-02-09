using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootsteps : MonoBehaviour {

    private enum CURRENT_TERRAIN { GROUND };

    [SerializeField]
    private CURRENT_TERRAIN currentTerrain;

    private FMOD.Studio.EventInstance foosteps;

    private void Update()
    {
        DetermineTerrain();
    }

    private void DetermineTerrain()
    {
        RaycastHit[] hit;

        hit = Physics.RaycastAll(transform.position, Vector3.down, 10.0f);

        foreach (RaycastHit rayhit in hit)
        {
            if (rayhit.transform.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                currentTerrain = CURRENT_TERRAIN.GROUND;
                break;
            }
        }
    }

    public void SelectAndPlayFootstep()
    {     
        switch (currentTerrain)
        {
            case CURRENT_TERRAIN.GROUND:
                PlayFootstep(0);
                break;
            
            default:
                PlayFootstep(0);
                break;
        }
    }

    private void PlayFootstep(int terrain)
    {
        foosteps = FMODUnity.RuntimeManager.CreateInstance("event:/PlayerFunction/PlayerFootsteps/Footsteps");
        foosteps.setParameterByName("Terrain", terrain);
        foosteps.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        foosteps.start();
        foosteps.release();
    }
}