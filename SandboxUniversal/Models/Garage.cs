using SandboxUniversal.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandboxUniversal.Models
{
    public class Garage : EntityBase
    {
        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        #endregion

        #region Attributs
        private String name;
        private Double sold;
        private int nbPlace;
        #endregion

        #region Properties
        public String Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public Double Sold
        {
            get { return sold; }
            set
            {
                sold = value;
                OnPropertyChanged("Sold");
            }
        }

        public int NbPlace
        {
            get { return nbPlace; }
            set
            {
                nbPlace = value;
                OnPropertyChanged("NbPlace");
            }
        }
        #endregion

        #region Constructors
        public Garage()
        {

        }

        public Garage(string name, double sold, int nbPlace)
        {
            this.name = name;
            this.sold = sold;
            this.nbPlace = nbPlace;
        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        #endregion

        #region Events
        #endregion

        public override string ToString()
        {
            return this.name + " " + this.nbPlace + " " + this.Sold;
        }
    }
}
