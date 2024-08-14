namespace DATN.PARKING.DLL
{
    public class EdiCoparnMsgIntfDto
    {
        public int? IntfId { get; set; }
        public int? Id { get; set; }

        public string? SiteId { get; set; } = "";

        public string? BookKey { get; set; } = "";

        public string? PartnerId { get; set; } = "";

        public string? TransKey { get; set; } = "";

        public string? MsgId { get; set; } = "";

        public string? DocCode { get; set; } = "";

        public string? MsgFunc { get; set; } = "";

        public string? Sender { get; set; } = "";

        public string? Receiver { get; set; } = "";

        public DateTime? MsgTs { get; set; }

        public string? ReleaseNo { get; set; } = "";

        public string? BookNo { get; set; } = "";                

        public string? BillOfLading { get; set; } = "";

        public DateTime? IssueTs { get; set; }

        public string? PortArea { get; set; } = "";

        public string? TerArea { get; set; } = "";

        public string? Agent { get; set; } = "";

        public string? LineOper { get; set; } = "";

        public string? CtrOwner { get; set; } = "";

        public string? LineOperVoy { get; set; } = "";

        public string? ModOfTrans { get; set; } = "";

        public string? ModTransId { get; set; } = "";

        public string? ModTransName { get; set; } = "";              

        public string? ModTransVoyage { get; set; } = "";

        public string? ModTransCallsign { get; set; } = "";

        public string? ModTransOp { get; set; } = "";

        public DateTime? ModTransArrTs { get; set; }

        public DateTime? ModTransDepTs { get; set; }

        public string? CustomsBrokerCd { get; set; } = "";

        public string? CustomsBroker { get; set; } = "";

        public string? ConsignorCd { get; set; } = "";

        public string? Consignor { get; set; } = "";

        public string? ForwarderCd { get; set; } = "";

        public string? Forwarder { get; set; } = "";

        public string? ConsigneeCd { get; set; } = "";

        public string? Consignee { get; set; } = "";

        public string? CustomerCd { get; set; } = "";

        public string? Customer { get; set; } = "";

        public DateTime? InlandArrTs { get; set; }

        public DateTime? InlandDepTs { get; set; }

        public int? GoodsNumber { get; set; }

        public int? GoodsQuantity { get; set; }

        public string? GoodsUnit { get; set; } = "";

        public string? GoodsDesc { get; set; } = "";

        public string? HazCode { get; set; } = "";

        public string? HazUnnoCode { get; set; } = "";

        public string? HazDetails { get; set; } = "";

        public string? HazPageNo { get; set; } = "";

        public string? Oog { get; set; } = "";

        public string? OogDetails { get; set; } = "";

        public string? OogFront { get; set; } = "";

        public string? OogRear { get; set; } = "";

        public string? OogLeft { get; set; } = "";

        public string? OogRight { get; set; } = "";

        public string? OogHeight { get; set; } = "";

        public string? ContainerNo { get; set; } = "";

        public string? SyzeType { get; set; } = "";

        public string? Status { get; set; } = "";

        public string? SealNo { get; set; } = "";    

        public string? Category { get; set; } = "";

        public string? Grade { get; set; } = "";

        public string? ReeferFlg { get; set; } = "";

        public decimal? ReeferTemp { get; set; }

        public string? ReeferUnit { get; set; } = "";

        public string? ReeferDetails { get; set; } = "";

        public string? AirFlow { get; set; } = "";   

        public string? Humidity { get; set; } = "";

        public int? Quantity { get; set; }

        public string? PortOfLoad { get; set; } = "";

        public string? TerOfLoad { get; set; } = "";

        public string? PortOfDischarge { get; set; } = "";

        public string? TerOfDischarge { get; set; } = "";

        public string? PlaceOfReceipt { get; set; } = "";

        public string? PlaceOfDelivery { get; set; } = "";

        public string? FinalPortOfDest { get; set; } = "";

        public decimal? TareWgt { get; set; }

        public decimal? CargoWgt { get; set; }

        public decimal? GrossWgt { get; set; }

        public string? Remark { get; set; } = "";

        public DateTime? EffectiveTs { get; set; }

        public DateTime? RequestedTs { get; set; }

        public DateTime? ExpiryTs { get; set; }

        public DateTime? CrtTs { get; set; }

        public DateTime? UpdTs { get; set; }

        public int? CtrlIssuedAmount { get; set; }

        public DateTime? CtrlCloseDate { get; set; }

        public string? CtrlCloseDesc { get; set; } = "";

        public string? CoparnMsgKey { get; set; } = "";

        public string? CtrlFileName { get; set; } = "";

        public string? CtrlFileKey { get; set; } = "";

        public string? CtrlCreatedBy { get; set; } = "";

        public int? CtrlIsEdiErr { get; set; }

        public bool? CtrlIsProcessing { get; set; }

        public string? CtrlErrorDesc { get; set; } = "";

        public int?  CtrlErrorNumber { get; set; }

        public decimal? Vgm { get; set; }

        public string? SeqNumber { get; set; } = "";

        public DateTime? CtrlIsProcessedDate { get; set; }

        public string? VentVolumetricUnit { get; set; } = "";

        public string? SecureCode { get; set; } = "";

        public string? NoPluginRequired { get; set; } = "";

        public string? CreatedBy { get; set; } = "";

        public int? O2 { get; set; }

        public int? Co2 { get; set; }

        public string? SpecialRemark { get; set; } = "";
    }
}
