using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class Logic : Activator
{
    public Activator A;
    public Activator B;
    public enum Opperator
    {
        and,
        or,
        not,
        xor,
        xnor
    };
    public Opperator opperator = new Opperator();
    public static implicit operator bool(Logic logic)
    {
        if (logic.opperator == Opperator.and)
            return logic.A && logic.B;
        else if (logic.opperator == Opperator.or)
            return logic.A || logic.B;
        else if (logic.opperator == Opperator.xor)
            return logic.A ^ logic. B;
        else if (logic.opperator == Opperator.not)
            return !logic.A;
        else if (logic.opperator == Opperator.xnor)
            return (bool)logic.A == (bool)logic.B;
        return logic.A;
    }
}
