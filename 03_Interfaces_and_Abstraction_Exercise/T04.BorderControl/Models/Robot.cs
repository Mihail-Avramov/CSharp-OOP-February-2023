using BorderControl.Models.Interfaces;

namespace BorderControl.Models
{
    public class Robot : IIdentifiable
    {
        public Robot(string model, string id)
        {
            Id = id;
            Model = model;
        }   

        public string Id { get; private set; }
        public string Model { get; private set; }

    }
}
