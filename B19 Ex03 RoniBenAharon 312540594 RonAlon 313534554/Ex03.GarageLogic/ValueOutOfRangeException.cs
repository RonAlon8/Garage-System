namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ValueOutOfRangeException : Exception
    {
        private readonly float r_MaxValue;
        private readonly float r_MinValue;
        
        public ValueOutOfRangeException(float i_MaxValue, float i_MinValue, string i_Msg) : base(i_Msg)
        {
            r_MaxValue = i_MaxValue;
            r_MinValue = i_MinValue;
        }

        internal float MaxValue
        {
            get
            {
                return r_MaxValue;
            }
        }

        internal float MinValue
        {
            get
            {
                return r_MinValue;
            }
        }
    }
}
