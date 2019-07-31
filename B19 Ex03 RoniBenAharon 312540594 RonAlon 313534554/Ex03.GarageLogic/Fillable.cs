namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Fillable
    {
        private readonly float r_MaxCapacity;
        private float m_CurrentCapacity;

        public Fillable(float i_MaxCapacity)
        {
            r_MaxCapacity = i_MaxCapacity;
        }

        internal float CurrentCapacity
        {
            get
            {
                return m_CurrentCapacity;
            }

            set
            {
                m_CurrentCapacity = value;
            }
        }

        internal float MaxCapacity
        {
            get
            {
                return r_MaxCapacity;
            }
        }

        internal void SetCurrentValues(string i_CurrentCapacity)
        {
            float currentCapacity, minValueInRange = 0;
            bool isValid;
            string exceptionMsg;

            isValid = float.TryParse(i_CurrentCapacity, out currentCapacity);
            if (isValid)
            {
                if (currentCapacity <= r_MaxCapacity && currentCapacity > minValueInRange)
                {
                    m_CurrentCapacity = currentCapacity;
                }
                else
                {
                    exceptionMsg = string.Format(
@"The value you wished to set is out of range.
Please enter a value between {0} to {1}",
minValueInRange,
r_MaxCapacity);

                    throw new ValueOutOfRangeException(r_MaxCapacity, minValueInRange, exceptionMsg);
                }
            }
            else
            {
                throw new FormatException("Invalid input to fill.");
            }
        }

        internal void Fill(float i_AmountToFill)
        {
            if (i_AmountToFill < 0 || m_CurrentCapacity + i_AmountToFill > r_MaxCapacity)
            {
                float minValueToFill = 0;
                float maxValueToFill = GetMaxValueToFill();
                string exceptionMsg = string.Format(
@"The value you wished to fill is out of range.
Please enter a value between {0} to {1}.", 
minValueToFill,
maxValueToFill);

                throw new ValueOutOfRangeException(maxValueToFill, minValueToFill, exceptionMsg);
            }
            else
            {
                m_CurrentCapacity += i_AmountToFill;
            }
        }

        protected virtual float GetMaxValueToFill()
        {
            return r_MaxCapacity - m_CurrentCapacity;
        }
    }
}
