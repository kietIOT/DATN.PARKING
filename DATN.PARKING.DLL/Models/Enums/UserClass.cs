namespace TCIS.TTOS.EDI.DAL.Models.Enums
{
    /// <summary>
    /// Seal type defien the type of Seal wich container belong to:
    /// Line Oper, Custom, Terminal
    /// </summary>
    public sealed class UserClass : StringEnumClass
    {
        /// <summary>
        /// "DKLA"
        /// </summary>
        public static readonly UserClass DieuDoKhuLanh = new UserClass("DKLA");

        /// <summary>
        /// "ADMI"
        /// </summary>
        public static readonly UserClass Admin = new UserClass("ADMI");

        /// <summary>
        /// "DKLA"
        /// </summary>
        public static readonly UserClass DKLA = new UserClass("DKLA");

        /// <summary>
        /// "DVLA"
        /// </summary>
        public static readonly UserClass DVLA = new UserClass("DVLA");

        /// <summary>
        /// "KSLA"
        /// </summary>
        public static readonly UserClass KSLA = new UserClass("KSLA");

        /// <summary>
        /// "MOLA"
        /// </summary>
        public static readonly UserClass MOLA = new UserClass("MOLA");

        /// <summary>
        /// "GND6"
        /// </summary>
        public static readonly UserClass GND6 = new UserClass("GND6");

        /// <summary>
        /// "GNDR"
        /// </summary>
        public static readonly UserClass GNDR = new UserClass("GNDR");

        /// "HQHN"
        /// </summary>
        public static readonly UserClass HQHN = new UserClass("HQHN");

        /// "HQHX"
        /// </summary>
        public static readonly UserClass HQHX = new UserClass("HQHX");

        /// "HQMS"
        /// </summary>
        public static readonly UserClass HQMS = new UserClass("HQMS");

        /// <summary>
        /// "SYSA"
        /// </summary>
        public static readonly UserClass SYSA = new UserClass("SYSA");

        /// <summary>
        /// "PHCT"
        /// </summary>
        public static readonly UserClass PHCT = new UserClass("PHCT");

        /// <summary>
        /// "CASH"
        /// </summary>
        public static readonly UserClass CASH = new UserClass("CASH");

        /// <summary>
        /// "QLTH"
        /// </summary>
        public static readonly UserClass QLTH = new UserClass("QLTH");

        public static readonly UserClass HAHDHELD = new UserClass("HHO");

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type"></param>
        private UserClass(String type)
            : base(type)
        {
        }
    }
}