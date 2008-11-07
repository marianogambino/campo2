using System;
using System.Collections.Generic;
using System.Text;

namespace Confluence.Domain
{
    public class Offer : DomainObject
    {
        #region properties
        private long id;
        
        private Client bidder;
        private double amount;
        private DateTime release_date;
        private Offer counter_offer;
        private Project project;

        public virtual long Id
        {
            set { id = value; }
            get { return id; }
        }
        [DV(Property = "Id")]
        public virtual Client Bidder
        {
            set { bidder = value; }
            get { return bidder; }
        }
        [DV]
        public virtual double Amount
        {
            set { amount = value; }
            get { return amount; }
        }
        [DV]
        public virtual DateTime ReleaseDate
        {
            set { release_date = value; }
            get { return release_date; }
        }
        [DV(Property = "Id")]
        public virtual Offer CounterOffer
        {
            set { counter_offer = value; }
            get { return counter_offer; }
        }
        public virtual Project Project
        {
            set { project = value; }
            get { return project; }
        }
        #endregion

        public Offer() { }
        public Offer(Double amount, DateTime release_date)
        {
            Amount = amount;
            ReleaseDate = release_date;
        }
        public virtual void Won()
        {
            Project.AcceptedBy(Bidder);
        }
    }
}
