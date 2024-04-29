namespace EndLevel
{
    public class GotoLevel : LevelComplete
    {
        public int level;
        protected override void Start()
        {
            NextLevel = level;
        }
    }
}
