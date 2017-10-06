using System;


namespace BookApi.Utils
{
    public static class SystemTime
    {

        #region Dates

        /// <summary>
        /// Fecha Actual
        /// </summary>
        public static Func<DateTime> Now = () => DateTime.Now;
        
        #endregion

        #region Day Methods

        /// <summary>
        /// Dia actual
        /// </summary>
        public static Func<int> Day = () => DateTime.Now.Day;
        

        #endregion

        #region Months Methods

        /// <summary>
        /// Mes actual
        /// </summary>
        public static Func<int> Month = () => DateTime.Now.Month;
       

        #endregion

        #region Year Methods

        /// <summary>
        /// Año actual
        /// </summary>
        public static Func<int> Year = () => DateTime.Now.Year;

       
        #endregion


    }

}