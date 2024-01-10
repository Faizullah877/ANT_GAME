namespace LangtonsAnt
{
    public class Game
    {
        public int GenerationN { get; set; } = 0;
        public byte[,] Field { get; set; }
        public Ant[] Ants { get; set; }
        public int Size
        {
            get => Field.GetLength(0);
        }

        public Game(int size = 64)
        {
            Field = new byte[size, size];
            Ants = new Ant[] {
                new Ant(i: size/2, j: size / 2 , direction: AntDirection.Up)
            };
        }
        private byte[,] CalcNextGeneration()
        {
            var newField = (byte[,])Field.Clone();

            for (int index = Ants.Length - 1; index >= 0; index--)
            {
                var ant = Ants[index];

                // Check if the ant is still within the field
                if (ant.I < 0 || ant.J < 0 || ant.J >= Size || ant.I >= Size)
                {
                    // TODO later you will act on ants going out of the field, 
                    //      now you just exclude them from processing
                    continue;
                }

                byte v = newField[ant.I, ant.J];
                int i = ant.I;
                int j = ant.J;
                byte newVal = ant.Act(v);
                newField[i, j] = newVal;
            }

            return newField;
        }
        public void NextGeneration()
        {
            Field = CalcNextGeneration();
            GenerationN++;
        }
    }
}