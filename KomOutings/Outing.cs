using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomOutings
{
    public enum EventType {Golf, Bowling, AmusementPark, Concert }
    public class Outing
    {

        public EventType EventType { get; set; }
        public int NumberOfPeople { get; set; }
        public DateTime Date { get; set; }
        public double TotalCostForEvent { get; set; }
        public double TotalCostPerPerson
        {
            get => TotalCostForEvent / NumberOfPeople;
        }
        public Outing()
        {

        }
        public Outing(EventType eventType, int numberOfPeople, DateTime date, double totalCostForEvent)
        {
            EventType = eventType;
            NumberOfPeople = numberOfPeople;
            Date = date;
            TotalCostForEvent = totalCostForEvent;
        }
    }
}
