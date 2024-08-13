namespace TCIS.TTOS.EDI.DAL
{
    public partial class Agents
    {
        public string Agent { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime UpdTs { get; set; }
        public string LineOper { get; set; } = null!;
        public string SiteId { get; set; } = null!;
        public string LinePrintSeparate { get; set; } = null!;
        public DateTime AsAtTs { get; set; }
        public DateTime ExpiryTs { get; set; }
        public string ContType { get; set; } = null!;
        public string Fel { get; set; } = null!;
        public string IsBillAgent { get; set; } = null!;
        public string IsContAgent { get; set; } = null!;
        public string ChargeType { get; set; } = null!;
        public string ChargeCodes { get; set; } = null!;
    }
}
