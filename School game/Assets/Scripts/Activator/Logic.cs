namespace Activator
{
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
        private void Update()
        {
            if (opperator == Opperator.and)
                _on = A && B;
            else if (opperator == Opperator.or)
                _on = A || B;
            else if (opperator == Opperator.xor)
                _on = A ^ B;
            else if (opperator == Opperator.not)
                _on = !A;
            else if (opperator == Opperator.xnor)
                _on = (bool)A == (bool)B;
        }
    }
}