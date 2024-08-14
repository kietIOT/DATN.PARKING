namespace DATN.PARKING.DLL.Models.Enums
{
    /// <summary>
    /// The class includes all comment code constant defined in project 
    /// </summary>
    public sealed class AuditActionCode : StringEnumClass
    {
        #region Audit data action code

        /// <summary>
        /// "INSERT". 
        /// </summary>
        public static readonly AuditActionCode Insert = new AuditActionCode("INSERT");

        /// <summary>
        /// "UPDATE".
        /// </summary>
        public static readonly AuditActionCode Update = new AuditActionCode("UPDATE");

        /// <summary>
        /// "DELETE".
        /// </summary>
        public static readonly AuditActionCode Delete = new AuditActionCode("DELETE");

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="code"></param>
        private AuditActionCode(String code)
            : base(code)
        {
        }

        #endregion
    }
}