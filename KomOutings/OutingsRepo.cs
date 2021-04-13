using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomOutings
{
    public class OutingsRepo
    {
        private List<Outing> _outings = new List<Outing>();
    //CREATE
    public bool AddOuting(Outing outing)
        {
            int startingCount = _outings.Count;
            _outings.Add(outing);
            bool wasAdded=_outings.Count > startingCount;
            return wasAdded;
        }

        //READ
        public List<Outing> GetAllOutings()
        {
            return _outings;
        }

        public List<Outing> GetOutingByType(EventType eventType)
        {
            List<Outing> outingList = new List<Outing>();
            foreach (Outing outing in _outings)
            {
                if (outing.EventType == eventType)
                {
                    outingList.Add(outing);
                }
            }
            return outingList;
        }
        //CALCULATIONS
        public double TotalCost()
        {
            double totalCost = 0.00;
            foreach (Outing outing in _outings)
            {
                totalCost += outing.TotalCostForEvent;
            }
            return totalCost;
        }

        public double TotalCostForEventType(EventType eventType)
        {
            double totalCost = 0.00;
            foreach (Outing outing in _outings)
            {
                if (outing.EventType == eventType)
                {
                    totalCost += outing.TotalCostForEvent;
                }
            }
            return totalCost;
        }
    }
}
