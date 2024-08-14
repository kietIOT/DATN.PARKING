namespace DATN.PARKING.DLL.Models.Enums
{
    public sealed class SysCodeRef : StringEnumClass
    {
        public static readonly SysCodeRef RaNo = new SysCodeRef("RA_NO");
        public static readonly SysCodeRef BookNo = new SysCodeRef("BOOK_NO");
        public static readonly SysCodeRef BillNo = new SysCodeRef("BILL_NO");
        public static readonly SysCodeRef CateRecvEdi = new SysCodeRef("CATE_RECV_EDI");

        public static readonly SysCodeRef DayExecute = new SysCodeRef("DAY_EXECUTE");
        public static readonly SysCodeRef FromTsExecute = new SysCodeRef("FROM_TS_EXECUTE");
        public static readonly SysCodeRef ToTsExecute = new SysCodeRef("TO_TS_EXECUTE");
        public static readonly SysCodeRef RangeExecute = new SysCodeRef("RANGE_EXECUTE");

        private SysCodeRef(String code)
           : base(code)
        {

        }
    }
}
