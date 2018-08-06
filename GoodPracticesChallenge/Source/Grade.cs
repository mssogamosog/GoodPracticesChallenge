using GoodPracticesChallenge.Source;

namespace GoodPracticesChallenge
{
    public class Grade
    {
        public Grade()
        {
            
        }
        public Grade(double value, Period period, Subject subject)
        {
            Value = value;
            Period = period;
            this.Subject = subject;
        }

        public int Id { get; set; }
        public double Value { get; set; }
        public Period Period { get; set; }
        public Subject Subject { get; set; }
    }
}