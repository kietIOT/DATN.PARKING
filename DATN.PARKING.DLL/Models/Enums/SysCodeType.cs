namespace TCIS.TTOS.EDI.DAL.Models.Enums
{
    /// <summary>
    /// The class includes all Sys Code constant defined in project 
    /// </summary>
    public sealed class SysCodeType : StringEnumClass
    {

        #region SYS_CODES
        /// <summary>
        /// Phương án cần đếm số lượng đăng ký eBooking
        /// </summary>
        public static readonly SysCodeType EBookingC10A = new SysCodeType("EBOOKINGC10A");

        /// <summary>
        /// Cấu hình mã chỉ định stop cont
        /// </summary>
        public static readonly SysCodeType AgentStop = new SysCodeType("STOPAGENTEDO");

        /// <summary>
        /// Hãng tàu áp dụng 100% eBooking
        /// </summary>
        public static readonly SysCodeType LINEREBOOKING = new SysCodeType("LINEREBK");

        /// <summary>
        /// "TEMPUNITS". System code for reefer temperature unit (C/F/...)
        /// </summary>
        public static readonly SysCodeType TempUnits = new SysCodeType("TEMPUNITS");

        /// <summary>
        /// "VENTUNIT". VENTUNIT
        /// </summary>
        public static readonly SysCodeType VentUnit = new SysCodeType("VENTUNIT");

        public static readonly SysCodeType LINEREDO = new SysCodeType("LINEREDO");
        public static readonly SysCodeType LINEREDO_F = new SysCodeType("LINEREDO_F");
        public static readonly SysCodeType EdoSecureConfig = new SysCodeType("EDO_SECURE");
        public static readonly SysCodeType EDO = new SysCodeType("EDO");
        public static readonly SysCodeType CtrlErrorDescWithHostInfo = new SysCodeType("INCLUDE_HOST");
        /// Phương án cần đếm số lượng đăng ký eBooking
        /// </summary>
        public static readonly SysCodeType ExecuteMoveHistEdoJob = new SysCodeType("EXE_HIST_JOB");

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="code"></param>
        private SysCodeType(String code)
            : base(code)
        {

        }

        #endregion
    }
}


