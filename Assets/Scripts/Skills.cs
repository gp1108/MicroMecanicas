using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Skills : MonoBehaviour
{
    private static Skills _Reference;
    public static Skills giveMeReference
    {
        get
        {
            if (_Reference == null)
            {
                _Reference = FindObjectOfType<Skills>();
                if (_Reference == null)
                {
                    GameObject go = new GameObject("skillManager");
                    _Reference = go.AddComponent<Skills>();
                }
            }
            return _Reference;
        }
    }
    public enum SkillName
    {
        moreHealthTurrets,
        moreDamageTurrets,
        moreHealthWalls,
        unlockSniperTurret,
        unlockMachinegunTurret,

        unlockMines,
        oneMoreMine,
        fasterResearch,
        fastMine,
        slowMine,
        unlockGems,

        moreHealthMainStructure,
        structureRecoverHealth,
        discountTurrets

    }

    

    // Define el costo de cada habilidad
    public Dictionary<SkillName, int> skillCost = new Dictionary<SkillName, int>
    {
        { SkillName.moreHealthTurrets, 1 },
        { SkillName.moreDamageTurrets, 1 },
        { SkillName.moreHealthWalls, 1000 },
        { SkillName.unlockSniperTurret,2 },
        { SkillName.unlockMachinegunTurret,2},

        { SkillName.unlockMines,2},
        { SkillName.oneMoreMine,2},
        { SkillName.fasterResearch,2},
        { SkillName.fastMine,2},
        { SkillName.slowMine,2},
        { SkillName.unlockGems,2},

        { SkillName.moreHealthMainStructure,2},
        { SkillName.structureRecoverHealth,2},
        { SkillName.discountTurrets,2}
    };

    //Define si ha sido desbloqueado o no 
    public Dictionary<SkillName, bool> isSkillUnlocked = new Dictionary<SkillName, bool>
    {
        { SkillName.moreHealthTurrets, false },
        { SkillName.moreDamageTurrets, false },
        { SkillName.moreHealthWalls, false },
        { SkillName.unlockSniperTurret,false },
        { SkillName.unlockMachinegunTurret,false},

        { SkillName.unlockMines,false},
        { SkillName.oneMoreMine,false},
        { SkillName.fasterResearch,false},
        { SkillName.fastMine,false},
        { SkillName.slowMine,false},
        { SkillName.unlockGems,false},

        { SkillName.moreHealthMainStructure,false},
        { SkillName.structureRecoverHealth,false},
        { SkillName.discountTurrets,false}
    };

    private void Start()
    {
        unlockSkill(SkillName.moreHealthTurrets);
        unlockSkill(SkillName.moreDamageTurrets);
        unlockSkill(SkillName.moreHealthWalls);
    }

    public void unlockSkill(SkillName skill)
    {
        if (skillCost[skill] <= gameManager.giveMeReference.researchPoints)
        {
            gameManager.giveMeReference.researchPoints -= skillCost[skill];
            isSkillUnlocked[skill] = true;
            DoSkill(skill);
            UpdateSkillUI();
            Debug.Log(skill + " Desbloqueada");
        }
        else
        {
            Debug.Log(skill + " No tienes suficientes puntos");
            //ejecutar aqui la logica que le diga al jugador que no tiene suficientes puntos
        }

        
    }
    
    public void UpdateSkillUI()
    {
        foreach (KeyValuePair<SkillName, int> kvp in skillCost)
        {
            SkillName clave = kvp.Key;
            int valor = kvp.Value;

            if(kvp.Value > gameManager.giveMeReference.researchPoints && isSkillUnlocked[kvp.Key] == false)
            {
                //Cambiar aqui los botones a no interactuables y de color rojo
            }
            else if(kvp.Value <= gameManager.giveMeReference.researchPoints && isSkillUnlocked[kvp.Key] == false)
            {
                //Poner aqui la logica de los botones que si puede comprar pero no ha desbloqueado todavia
            }
            else if(isSkillUnlocked[kvp.Key] == true)
            {
                //Aqui cambiar el color y que sea interactuable a los botones que si ha desbloqueado ya
            }

            
        }
    }

    public void DoSkill(SkillName skill)
    {
        switch(skill)
        {
            case SkillName.moreHealthTurrets:
                Debug.Log("Hola");
                break;
            case SkillName.moreDamageTurrets:

                break;
            case SkillName.moreHealthWalls:

                break;
            case SkillName.unlockSniperTurret:

                break;
            case SkillName.unlockMachinegunTurret:

                break;

            case SkillName.unlockMines:

                break;
            case SkillName.oneMoreMine:

                break;
            case SkillName.fasterResearch:

                break;
            case SkillName.fastMine:

                break;
            case SkillName.slowMine:

                break;
            case SkillName.unlockGems:

                break;

            case SkillName.moreHealthMainStructure:

                break;
            case SkillName.structureRecoverHealth:

                break;
            case SkillName.discountTurrets:

                break;
              
        }

        

    }
}
