////
/// Copyright (c) 2016 Saúl Piña <sauljabin@gmail.com>.
/// 
/// This file is part of idempierewsc.
/// 
/// idempierewsc is free software: you can redistribute it and/or modify
/// it under the terms of the GNU Lesser General Public License as published by
/// the Free Software Foundation, either version 3 of the License, or
/// (at your option) any later version.
/// 
/// idempierewsc is distributed in the hope that it will be useful,
/// but WITHOUT ANY WARRANTY; without even the implied warranty of
/// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
/// GNU Lesser General Public License for more details.
/// 
/// You should have received a copy of the GNU Lesser General Public License
/// along with idempierewsc.  If not, see <http://www.gnu.org/licenses/>.
////


namespace WebService.Base.Enums {
            
    /// <summary>
    /// WebService Type
    /// </summary>
    public enum WebServiceDefinition {
        ModelADService,
        compositeInterface
    }

    /// <summary>
    /// WebService Method
    /// </summary>
    public enum WebServiceMethod {
        runProcess,
        createData,
        createUpdateData,
        deleteData,
        getList,
        queryData,
        readData,
        setDocAction,
        updateData,
        compositeOperation
    }

    /// <summary>
    /// Response Model
    /// </summary>
    public enum WebServiceResponseModel {
        StandardResponse,
        RunProcessResponse,
        WindowTabDataResponse,
        CompositeResponse
    }

    /// <summary>
    /// Response Status
    /// </summary>
    public enum WebServiceResponseStatus {
        Error,
        Successful,
        Unsuccessful
    }

    /// <summary>
    /// Request Model
    /// </summary>
    public enum WebServiceRequestModel {
        ModelCRUDRequest,
        ModelGetListRequest,
        ModelRunProcessRequest,
        ModelSetDocActionRequest,
        CompositeRequest
    }

    /// <summary>
    /// For field container
    /// </summary>
    public enum FieldsContainerType {
        DataRow,
        ParamValues
    }

    /// <summary>
    /// ModelCRUD Action
    /// </summary>
    public enum ModelCRUDAction {
        Read,
        Create,
        CreateUpdate,
        Delete,
        Update
    }

    /// <summary>
    /// iDempiere document action Values
    /// </summary>
    public enum DocAction {
        
        /// <summary>
        /// Complete = CO
        /// </summary>
        Complete,

        /// <summary>
        /// Wait Complete = WC
        /// </summary>
        WaitComplete,

        /// <summary>
        /// Approve = AP
        /// </summary>
        Approve,

        /// <summary>
        /// Reject = RJ
        /// </summary>
        Reject,

        /// <summary>
        /// Post = PO
        /// </summary>
        Post,
  
        /// <summary>
        /// Void = VO
        /// </summary>
        Void,
      
        /// <summary>
        /// Close = CL 
        /// </summary>
        Close,
      
        /// <summary>
        /// Reverse - Correct = RC
        /// </summary>
        ReverseCorrect,

        /// <summary>
        /// Reverse - Accrual = RA
        /// </summary>
        ReverseAccrual,

        /// <summary>
        /// ReActivate = RE
        /// </summary>
        ReActivate,

        /// <summary>
        /// Prepare = PR
        /// </summary>
        Prepare,

        /// <summary>
        /// Unlock = XL
        /// </summary>
        Unlock,

        /// <summary>
        /// Invalidate = IN
        /// </summary>
        Invalidate,

        /// <summary>
        /// ReOpen = OP
        /// </summary>
        ReOpen,

        /// <summary>
        /// <None> = --
        /// </summary>
        None
    }

    /// <summary>
    /// Document action extensions
    /// </summary>
    public static class DocActionExtensions {

        /// <summary>
        /// Gets the iDempiere Document Action Value
        /// </summary>
        /// <returns>The iDempiere Document Action Value</returns>
        /// <param name="docAction">iDempiere Document Action Value</param>
        public static string GetValue(this DocAction docAction) {
            switch (docAction) {
                case DocAction.Complete:
                    return "CO";
                case DocAction.WaitComplete:
                    return "WC";
                case DocAction.Approve:
                    return "AP";
                case DocAction.Reject:
                    return "RJ";
                case DocAction.Post:
                    return "PO";
                case DocAction.Void:
                    return "VO";
                case DocAction.Close:
                    return "CL";
                case DocAction.ReverseCorrect:
                    return "RC";
                case DocAction.ReverseAccrual:
                    return "RA";
                case DocAction.ReActivate:
                    return "RE";
                case DocAction.Prepare:
                    return "PR";
                case DocAction.Unlock:
                    return "XL";
                case DocAction.Invalidate:
                    return "IN";
                case DocAction.ReOpen:
                    return "OP";
                case DocAction.None:
                default:
                    return "--";
            }
        }

        /// <summary>
        /// Gets the iDempiere Document Action Value
        /// </summary>
        /// <returns>The iDempiere Document Action Value</returns>
        /// <param name="docAction">iDempiere Document Action Value</param>
        public static string GetValue(this DocAction? docAction) {
            if (docAction == null)
                return null;
            
            DocAction doc = docAction.Value;
            return GetValue(doc);
        }
    }

    /// <summary>
    /// iDempiere Document Status Values
    /// </summary>
    public enum DocStatus {

        /// <summary>
        ///  Drafted = DR
        /// </summary>
        Drafted,

        /// <summary>
        ///  Completed = CO
        /// </summary>
        Completed,

        /// <summary>
        ///  Approved = AP
        /// </summary>
        Approved,

        /// <summary>
        ///  Invalid = IN
        /// </summary>
        Invalid,

        /// <summary>
        ///  Not Approved = NA
        /// </summary>
        NotApproved,

        /// <summary>
        ///  Voided = VO
        /// </summary>
        Voided,

        /// <summary>
        ///  Reversed = RE
        /// </summary>
        Reversed,

        /// <summary>
        ///  Closed = CL
        /// </summary>
        Closed,

        /// <summary>
        ///  Unknown = ??
        /// </summary>
        Unknown,

        /// <summary>
        ///  In Progress = IP
        /// </summary>
        InProgress,

        /// <summary>
        ///  Waiting Payment = WP
        /// </summary>
        WaitingPayment,

        /// <summary>
        ///  Waiting Confirmation = WC
        /// </summary>
        WaitingConfirmation
    }

    /// <summary>
    /// Document status extensions
    /// </summary>
    public static class DocStatusExtensions {

        /// <summary>
        /// Gets the iDempiere Document Status Value
        /// </summary>
        /// <returns>The iDempiere Document Status Value</returns>
        /// <param name="docStatus">iDempiere Document Status Value</param>
        public static string GetValue(this DocStatus docStatus) {
            switch (docStatus) {
                case DocStatus.Drafted:
                    return "DR";
                case DocStatus.Completed:
                    return "CO";
                case DocStatus.Approved:
                    return "AP";
                case DocStatus.NotApproved:
                    return "NA";
                case DocStatus.Voided:
                    return "VO";
                case DocStatus.Closed:
                    return "CL";
                case DocStatus.Reversed:
                    return "RE";
                case DocStatus.InProgress:
                    return "IP";
                case DocStatus.WaitingPayment:
                    return "WP";
                case DocStatus.Invalid:
                    return "IN";
                case DocStatus.WaitingConfirmation:
                    return "WC";
                case DocStatus.Unknown:
                default:
                    return "??";
            }
        }

        /// <summary>
        /// Gets the iDempiere Document Status Value
        /// </summary>
        /// <returns>The iDempiere Document Status Value</returns>
        /// <param name="docStatus">iDempiere Document Status Value</param>
        public static string GetValue(this DocStatus? docStatus) {
            if (docStatus == null)
                return null;

            DocStatus doc = docStatus.Value;
            return GetValue(doc);
        }
    }

    /// <summary>
    /// iDempiere Language Values
    /// </summary>
    public enum Language {

        /// <summary>
        /// Arabic (United Arab Emirates) [Language ISO = ar, Country Code = AE]
        /// </summary>
        ar_AE,

        /// <summary>
        /// Arabic (Bahrain) [Language ISO = ar, Country Code = BH]
        /// </summary>
        ar_BH,

        /// <summary>
        /// Arabic (Algeria) [Language ISO = ar, Country Code = DZ]
        /// </summary>
        ar_DZ,

        /// <summary>
        /// Arabic (Egypt) [Language ISO = ar, Country Code = EG]
        /// </summary>
        ar_EG,

        /// <summary>
        /// Arabic (Iraq) [Language ISO = ar, Country Code = IQ]
        /// </summary>
        ar_IQ,

        /// <summary>
        /// Arabic (Jordan) [Language ISO = ar, Country Code = JO]
        /// </summary>
        ar_JO,

        /// <summary>
        /// Arabic (Kuwait) [Language ISO = ar, Country Code = KW]
        /// </summary>
        ar_KW,

        /// <summary>
        /// Arabic (Lebanon) [Language ISO = ar, Country Code = LB]
        /// </summary>
        ar_LB,

        /// <summary>
        /// Arabic (Libya) [Language ISO = ar, Country Code = LY]
        /// </summary>
        ar_LY,

        /// <summary>
        /// Arabic (Morocco) [Language ISO = ar, Country Code = MA]
        /// </summary>
        ar_MA,

        /// <summary>
        /// Arabic (Oman) [Language ISO = ar, Country Code = OM]
        /// </summary>
        ar_OM,

        /// <summary>
        /// Arabic (Qatar) [Language ISO = ar, Country Code = QA]
        /// </summary>
        ar_QA,

        /// <summary>
        /// Arabic (Saudi Arabia) [Language ISO = ar, Country Code = SA]
        /// </summary>
        ar_SA,

        /// <summary>
        /// Arabic (Sudan) [Language ISO = ar, Country Code = SD]
        /// </summary>
        ar_SD,

        /// <summary>
        /// Arabic (Syria) [Language ISO = ar, Country Code = SY]
        /// </summary>
        ar_SY,

        /// <summary>
        /// Arabic (Tunisia) [Language ISO = ar, Country Code = TN]
        /// </summary>
        ar_TN,

        /// <summary>
        /// Arabic (Yemen) [Language ISO = ar, Country Code = YE]
        /// </summary>
        ar_YE,

        /// <summary>
        /// Byelorussian (Belarus) [Language ISO = be, Country Code = BY]
        /// </summary>
        be_BY,

        /// <summary>
        /// Bulgarian (Bulgaria) [Language ISO = bg, Country Code = BG]
        /// </summary>
        bg_BG,

        /// <summary>
        /// Catalan (Spain) [Language ISO = ca, Country Code = ES]
        /// </summary>
        ca_ES,

        /// <summary>
        /// Czech (Czech Republic) [Language ISO = cs, Country Code = CZ]
        /// </summary>
        cs_CZ,

        /// <summary>
        /// Danish (Denmark) [Language ISO = da, Country Code = DK]
        /// </summary>
        da_DK,

        /// <summary>
        /// German (Austria) [Language ISO = de, Country Code = AT]
        /// </summary>
        de_AT,

        /// <summary>
        /// German (Switzerland) [Language ISO = de, Country Code = CH]
        /// </summary>
        de_CH,

        /// <summary>
        /// German (Germany) [Language ISO = de, Country Code = DE]
        /// </summary>
        de_DE,

        /// <summary>
        /// German (Luxembourg) [Language ISO = de, Country Code = LU]
        /// </summary>
        de_LU,

        /// <summary>
        /// Greek (Cyprus) [Language ISO = el, Country Code = CY]
        /// </summary>
        el_CY,

        /// <summary>
        /// Greek (Greece) [Language ISO = el, Country Code = GR]
        /// </summary>
        el_GR,

        /// <summary>
        /// English (Australia) [Language ISO = en, Country Code = AU]
        /// </summary>
        en_AU,

        /// <summary>
        /// English (Canada) [Language ISO = en, Country Code = CA]
        /// </summary>
        en_CA,

        /// <summary>
        /// English (United Kingdom) [Language ISO = en, Country Code = GB]
        /// </summary>
        en_GB,

        /// <summary>
        /// English (Ireland) [Language ISO = en, Country Code = IE]
        /// </summary>
        en_IE,

        /// <summary>
        /// English (India) [Language ISO = en, Country Code = IN]
        /// </summary>
        en_IN,

        /// <summary>
        /// English (Malta) [Language ISO = en, Country Code = MT]
        /// </summary>
        en_MT,

        /// <summary>
        /// English (New Zealand) [Language ISO = en, Country Code = NZ]
        /// </summary>
        en_NZ,

        /// <summary>
        /// English (Philippines) [Language ISO = en, Country Code = PH]
        /// </summary>
        en_PH,

        /// <summary>
        /// English (Singapore) [Language ISO = en, Country Code = SG]
        /// </summary>
        en_SG,

        /// <summary>
        /// English (USA) [Language ISO = en, Country Code = US]
        /// </summary>
        en_US,

        /// <summary>
        /// English (South Africa) [Language ISO = en, Country Code = ZA]
        /// </summary>
        en_ZA,

        /// <summary>
        /// Spanish (Argentina) [Language ISO = es, Country Code = AR]
        /// </summary>
        es_AR,

        /// <summary>
        /// Spanish (Bolivia) [Language ISO = es, Country Code = BO]
        /// </summary>
        es_BO,

        /// <summary>
        /// Spanish (Chile) [Language ISO = es, Country Code = CL]
        /// </summary>
        es_CL,

        /// <summary>
        /// Spanish (Colombia) [Language ISO = es, Country Code = CO]
        /// </summary>
        es_CO,

        /// <summary>
        /// Spanish (Costa Rica) [Language ISO = es, Country Code = CR]
        /// </summary>
        es_CR,

        /// <summary>
        /// Spanish (Dominican Republic) [Language ISO = es, Country Code = DO]
        /// </summary>
        es_DO,

        /// <summary>
        /// Spanish (Ecuador) [Language ISO = es, Country Code = EC]
        /// </summary>
        es_EC,

        /// <summary>
        /// Spanish (Spain) [Language ISO = es, Country Code = ES]
        /// </summary>
        es_ES,

        /// <summary>
        /// Spanish (Guatemala) [Language ISO = es, Country Code = GT]
        /// </summary>
        es_GT,

        /// <summary>
        /// Spanish (Honduras) [Language ISO = es, Country Code = HN]
        /// </summary>
        es_HN,

        /// <summary>
        /// Spanish (Mexico) [Language ISO = es, Country Code = MX]
        /// </summary>
        es_MX,

        /// <summary>
        /// Spanish (Nicaragua) [Language ISO = es, Country Code = NI]
        /// </summary>
        es_NI,

        /// <summary>
        /// Spanish (Panama) [Language ISO = es, Country Code = PA]
        /// </summary>
        es_PA,

        /// <summary>
        /// Spanish (Peru) [Language ISO = es, Country Code = PE]
        /// </summary>
        es_PE,

        /// <summary>
        /// Spanish (Puerto Rico) [Language ISO = es, Country Code = PR]
        /// </summary>
        es_PR,

        /// <summary>
        /// Spanish (Paraguay) [Language ISO = es, Country Code = PY]
        /// </summary>
        es_PY,

        /// <summary>
        /// Spanish (El Salvador) [Language ISO = es, Country Code = SV]
        /// </summary>
        es_SV,

        /// <summary>
        /// Spanish (USA) [Language ISO = es, Country Code = US]
        /// </summary>
        es_US,

        /// <summary>
        /// Spanish (Uruguay) [Language ISO = es, Country Code = UY]
        /// </summary>
        es_UY,

        /// <summary>
        /// Spanish (Venezuela) [Language ISO = es, Country Code = VE]
        /// </summary>
        es_VE,

        /// <summary>
        /// Estonian (Estonia) [Language ISO = et, Country Code = EE]
        /// </summary>
        et_EE,

        /// <summary>
        /// Farsi (Iran) [Language ISO = fa, Country Code = IR]
        /// </summary>
        fa_IR,

        /// <summary>
        /// Finnish (Finland) [Language ISO = fi, Country Code = FI]
        /// </summary>
        fi_FI,

        /// <summary>
        /// French (Belgium) [Language ISO = fr, Country Code = BE]
        /// </summary>
        fr_BE,

        /// <summary>
        /// French (Canada) [Language ISO = fr, Country Code = CA]
        /// </summary>
        fr_CA,

        /// <summary>
        /// French (Switzerland) [Language ISO = fr, Country Code = CH]
        /// </summary>
        fr_CH,

        /// <summary>
        /// French (France) [Language ISO = fr, Country Code = FR]
        /// </summary>
        fr_FR,

        /// <summary>
        /// French (Luxembourg) [Language ISO = fr, Country Code = LU]
        /// </summary>
        fr_LU,

        /// <summary>
        /// Irish (Ireland) [Language ISO = ga, Country Code = IE]
        /// </summary>
        ga_IE,

        /// <summary>
        /// Hindi (India) [Language ISO = hi, Country Code = IN]
        /// </summary>
        hi_IN,

        /// <summary>
        /// Croatian (Croatia) [Language ISO = hr, Country Code = HR]
        /// </summary>
        hr_HR,

        /// <summary>
        /// Hungarian (Hungary) [Language ISO = hu, Country Code = HU]
        /// </summary>
        hu_HU,

        /// <summary>
        /// Indonesian (Indonesia) [Language ISO = in, Country Code = ID]
        /// </summary>
        in_ID,

        /// <summary>
        /// Icelandic (Iceland) [Language ISO = is, Country Code = IS]
        /// </summary>
        is_IS,

        /// <summary>
        /// Italian (Switzerland) [Language ISO = it, Country Code = CH]
        /// </summary>
        it_CH,

        /// <summary>
        /// Italian (Italy) [Language ISO = it, Country Code = IT]
        /// </summary>
        it_IT,

        /// <summary>
        /// Hebrew (Israel) [Language ISO = iw, Country Code = IL]
        /// </summary>
        iw_IL,

        /// <summary>
        /// Japanese (Japan) [Language ISO = ja, Country Code = JP]
        /// </summary>
        ja_JP,

        /// <summary>
        /// Korean (South Korea) [Language ISO = ko, Country Code = KR]
        /// </summary>
        ko_KR,

        /// <summary>
        /// Lithuanian (Lithuania) [Language ISO = lt, Country Code = LT]
        /// </summary>
        lt_LT,

        /// <summary>
        /// Latvian (Lettish) (Latvia) [Language ISO = lv, Country Code = LV]
        /// </summary>
        lv_LV,

        /// <summary>
        /// Macedonian (Macedonia) [Language ISO = mk, Country Code = MK]
        /// </summary>
        mk_MK,

        /// <summary>
        /// Malay (Malaysia) [Language ISO = ms, Country Code = MY]
        /// </summary>
        ms_MY,

        /// <summary>
        /// Maltese (Malta) [Language ISO = mt, Country Code = MT]
        /// </summary>
        mt_MT,

        /// <summary>
        /// Dutch (Belgium) [Language ISO = nl, Country Code = BE]
        /// </summary>
        nl_BE,

        /// <summary>
        /// Dutch (Netherlands) [Language ISO = nl, Country Code = NL]
        /// </summary>
        nl_NL,

        /// <summary>
        /// Norwegian (Norway) [Language ISO = no, Country Code = NO]
        /// </summary>
        no_NO,

        /// <summary>
        /// Polish (Poland) [Language ISO = pl, Country Code = PL]
        /// </summary>
        pl_PL,

        /// <summary>
        /// Portuguese (Brazil) [Language ISO = pt, Country Code = BR]
        /// </summary>
        pt_BR,

        /// <summary>
        /// Portuguese (Portugal) [Language ISO = pt, Country Code = PT]
        /// </summary>
        pt_PT,

        /// <summary>
        /// Romanian (Romania) [Language ISO = ro, Country Code = RO]
        /// </summary>
        ro_RO,

        /// <summary>
        /// Russian (Russia) [Language ISO = ru, Country Code = RU]
        /// </summary>
        ru_RU,

        /// <summary>
        /// Serbo-Croatian (Yugoslavia) [Language ISO = sh, Country Code = YU]
        /// </summary>
        sh_YU,

        /// <summary>
        /// Slovak (Slovakia) [Language ISO = sk, Country Code = SK]
        /// </summary>
        sk_SK,

        /// <summary>
        /// Slovenian (Slovenia) [Language ISO = sl, Country Code = SI]
        /// </summary>
        sl_SI,

        /// <summary>
        /// Albanian (Albania) [Language ISO = sq, Country Code = AL]
        /// </summary>
        sq_AL,

        /// <summary>
        /// Serbian (Bosnia and Herzegovina) [Language ISO = sr, Country Code = BA]
        /// </summary>
        sr_BA,

        /// <summary>
        /// Serbian (Serbia and Montenegro) [Language ISO = sr, Country Code = CS]
        /// </summary>
        sr_CS,

        /// <summary>
        /// Serbian (Montenegro) [Language ISO = sr, Country Code = ME]
        /// </summary>
        sr_ME,

        /// <summary>
        /// Serbian (Serbia) [Language ISO = sr, Country Code = RS]
        /// </summary>
        sr_RS,

        /// <summary>
        /// Serbian (Yugoslavia) [Language ISO = sr, Country Code = YU]
        /// </summary>
        sr_YU,

        /// <summary>
        /// Swedish (Sweden) [Language ISO = sv, Country Code = SE]
        /// </summary>
        sv_SE,

        /// <summary>
        /// Thai (Thailand) [Language ISO = th, Country Code = TH]
        /// </summary>
        th_TH,

        /// <summary>
        /// Turkish (Turkey) [Language ISO = tr, Country Code = TR]
        /// </summary>
        tr_TR,

        /// <summary>
        /// Ukrainian (Ukraine) [Language ISO = uk, Country Code = UA]
        /// </summary>
        uk_UA,

        /// <summary>
        /// Vietnamese [Language ISO = vi, Country Code = VN]
        /// </summary>
        vi_VN,

        /// <summary>
        /// Chinese (China) [Language ISO = zh, Country Code = CN]
        /// </summary>
        zh_CN,

        /// <summary>
        /// Chinese (Hong Kong) [Language ISO = zh, Country Code = HK]
        /// </summary>
        zh_HK,

        /// <summary>
        /// Chinese (Singapore) [Language ISO = zh, Country Code = SG]
        /// </summary>
        zh_SG,

        /// <summary>
        /// Chinese (Taiwan) [Language ISO = zh, Country Code = TW]
        /// </summary>
        zh_TW
    }

    /*
     * Response error types
     * 
     * @author pozzisan
     *
     */
    public enum ErrorType
    {
           RECORD_NOT_EXISTS,
           SERVICE_TYPE_NOT_EXISTS,
           UNKNOW_ERROR,
           EMPTY_ERROR,
    }

}
