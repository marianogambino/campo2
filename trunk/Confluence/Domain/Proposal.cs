using System;
using System.Collections.Generic;
using System.Text;

namespace Confluence.Domain
{
    public class Proposal : DomainObject
    {
        private long id;
        private String description;
        private double amount;
        private Client resource;
        private Client employer;

        public virtual long Id
        {
            set { id = value; }
            get { return id; }
        }
        [DV]
        public virtual String Description
        {
            set { description = value; }
            get { return description; }
        }
        [DV]
        public virtual double Amount
        {
            set { amount = value; }
            get { return amount; }
        }
        [DV(Property="Id")]
        public virtual Client Resource
        {
            set { resource = value; }
            get { return resource; }
        }
        [DV(Property = "Id")]
        public virtual Client Employer
        {
            set { employer = value; }
            get { return employer; }
        }
        public Proposal() { }
        public Proposal(double amount, string desc,Client employer)
        {
            Amount = amount;
            Description = desc;
            Employer = employer;
        }
    }
}
