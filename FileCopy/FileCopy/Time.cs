using System;
using System.Text;

namespace Acty.Skillup.FileCopy
{
    public class Time
    {
        /// <summary>
        /// Calculate and print days , hours , minutes and seconds
        /// </summary>
        /// <param name="dTotalSeconds">Total Seconds taken</param>
        public string FormatTime(double dTotalSeconds)
        {
            int iTotalSeconds = (int)Math.Ceiling(dTotalSeconds/1000);

            int iDay = (iTotalSeconds / (Constants.HOURS_PER_DAY * Constants.SECONDS_PER_HOUR));
            iTotalSeconds %= (Constants.HOURS_PER_DAY * Constants.SECONDS_PER_HOUR);

            // Converting remaining seconds to hours
            int iHour = iTotalSeconds / Constants.SECONDS_PER_HOUR;
            iTotalSeconds %= Constants.SECONDS_PER_HOUR;

            // Converting remaining seconds to minutes
            int iMinutes = iTotalSeconds / Constants.MINUTES_PER_HOUR;
            iTotalSeconds %= Constants.MINUTES_PER_HOUR;

            // Array for storing values of day , hour , minute and second
            int[] arrTimeStamp = new int[4] { iDay, iHour, iMinutes, iTotalSeconds };

            // Array for storing Singular values of day , hour , minute and second
            string[] arrTimeFormatInSingular = new string[4] { Constants.DAY, Constants.HOUR, Constants.MINUTE, Constants.SECOND };

            // Bool used for stopping preceding values as 0
            bool bPrecidingZero = true;
            StringBuilder objResultString = new StringBuilder();
            string sResult;

            for (int i = 0; i < arrTimeStamp.Length; i++)
            {
                if (arrTimeStamp[i] != 0 || bPrecidingZero == false)
                {
                    bPrecidingZero = false;
                    sResult = AppendSuffix(arrTimeStamp[i], arrTimeFormatInSingular[i]);
                    objResultString.Append(sResult);
                }
            }

            return objResultString.ToString();
        }

        /// <summary>
        /// Append Result to String builder
        /// </summary>
        /// <param name="iTimeStamp">array containing values of day,hr,min and sec</param>
        /// <param name="sTimeFormatInSingular">to use singular form of time stamp</param>
        public string AppendSuffix(int iTimeStamp, string sTimeFormatInSingular)
        {
            if (iTimeStamp > 1)
            {
                return $"{iTimeStamp} {sTimeFormatInSingular}{"s"} ";
            }
            else
            {
                return $"{iTimeStamp} {sTimeFormatInSingular} ";
            }
        }
    }
}
