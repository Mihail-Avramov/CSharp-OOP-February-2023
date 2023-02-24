namespace Zoo
{
    public abstract class Animal
    {
        protected Animal(string name)
        {
            Name = name;
        }
        public string Name { get; private set; }
    }
}
