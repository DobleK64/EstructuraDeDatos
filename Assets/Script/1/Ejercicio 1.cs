using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86;

public class Ejercicio1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Stack<int> originalStack = new Stack<int>();
        originalStack.Push(4);
        originalStack.Push(-5);
        originalStack.Push(-10);
        originalStack.Push(88);
        originalStack.Push(2);

        Stack<int> stack1 = new Stack<int>();
        Stack<int> stack2 = new Stack<int>();

        // vaciamos la pila original y le damos todos los valores a la pila 1 para empezar a trabajar
        while (originalStack.Count > 0)
        {
            stack1.Push(originalStack.Pop());
        }

        while (stack1.Count > 0)
        {
            int aux = stack1.Pop();
            while (stack1.Count > 0)
            {
                if (stack1.Peek() < aux)
                {
                    stack2.Push(aux);
                    aux = stack1.Pop();
                }
                else
                {
                    stack2.Push(stack1.Pop());
                }
            }

            // el menor valor es aux
            originalStack.Push(aux);

            // swap de pilas
            Stack<int> auxStack = stack1;
            stack1 = stack2;
            stack2 = auxStack;
        }

        while (originalStack.Count > 0)
        {
            Debug.Log(originalStack.Pop());
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}