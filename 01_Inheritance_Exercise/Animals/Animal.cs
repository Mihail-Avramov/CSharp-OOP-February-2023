using System;
using System.Text;

namespace Animals
{
    public abstract class Animal
    {
		private string name;
		private int age;
		private string gender;

        public Animal(string name, int age, string gender)
        {
            Name = name;
			Age = age;
			Gender = gender;
        }

		public string Gender
		{
            get => gender;
            private init
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid input!");
                }
                
                gender = value;
            }
		}	


		public int Age
		{
            get => age;
            private init
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid input!");
                }

                age = value;
            }
		}


		public string Name
		{
            get => name;
            private init
            {
                if (string.IsNullOrEmpty(value))
                {
					throw new ArgumentException("Invalid input!");
                }

                name = value;
            }
		}

        public abstract string ProduceSound();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(this.GetType().Name);
            sb.AppendLine($"{Name} {Age} {Gender}");
            sb.AppendLine(ProduceSound());

            return sb.ToString().Trim();
        }
    }
}
