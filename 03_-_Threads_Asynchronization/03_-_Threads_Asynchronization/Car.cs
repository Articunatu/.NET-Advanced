
namespace _03___Threads_Asynchronization
{
    public class Car
    {
        public string Name { get; set; }
        
        private double velocity = 120/3.6; ///120 km/h
        public double Velocity { get => velocity; set => velocity = value; }

        private double currentDistance = 0;
        //public bool NoFuel { get; set; }
        //public bool Punctation { get; set; }
        //public bool BirdOnWindow { get; set; }
        public bool MotorMalfuntion { get; set; }
        //public bool hasAccident { get; set; }
        public double CurrentDistance { get => currentDistance; set => currentDistance = value; }

        //public void CheckOccurance(Car car)
        //{

        //}
    }
}
