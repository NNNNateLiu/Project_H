using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_RandomAni : StateMachineBehaviour
{
    public string m_parametersName = "NPC7_state";
    public int[] m_stateIDArray = { 0, 1, 2, 3 };

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (m_stateIDArray.Length <= 0)
        {
            animator.SetInteger(m_parametersName, 0);
        }
        else
        {
            int index = Random.Range(1, m_stateIDArray.Length);
            //Debug.Log(m_parametersName + "-->" + m_stateIDArray[index]);
            animator.SetInteger(m_parametersName, m_stateIDArray[index]);
        }
    }
}
