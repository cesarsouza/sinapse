using System;
using System.Collections.Generic;
using System.Text;

using AForge.Mathematics;

namespace Sinapse.Core.Filters
{
    public class ThresholdSeparation : IFilter
    {

        #region IFilter Members

        public object Input
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public object Output
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public void Apply()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public string Name
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public string Description
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public System.Windows.Forms.Control Control
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        #endregion
    }
}
