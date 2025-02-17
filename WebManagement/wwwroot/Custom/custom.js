function getValue(CtlId) {
    return document.getElementById(CtlId).value.trim();
}
function getValueNoTrim(CtlId) {
    return document.getElementById(CtlId).value;
}
function getText(CtlId) {
    var elt = document.getElementById(CtlId);

    if (elt.selectedIndex == -1)
        return null;

    return elt.options[elt.selectedIndex].text;
}
function getTextContent(CtlId) {
    return document.getElementById(CtlId).textContent;
}
function setValue(CtlId, Value) {
    document.getElementById(CtlId).value = Value;
}
function setInnerText(CtlId, Value) {
    document.getElementById(CtlId).innerText = Value;
}
function setInnerHTML(CtlId, Value) {
    document.getElementById(CtlId).innerHTML = Value;
}
function setClassName(CtlId, Value) {
    document.getElementById(CtlId).className = Value;
}
function setHidden(CtlId, Value) {
    document.getElementById(CtlId).hidden = Value;
}
function setDisabled(CtlId, Value) {
    document.getElementById(CtlId).disabled = Value;
}
function setStyleBgColor(CtlId, Value) {
    document.getElementById(CtlId).style.backgroundColor = Value;
}
function setStyleVisibility(CtlId, Value) {
    document.getElementById(CtlId).style.visibility = Value;
}
function setTextContent(CtlId, Value) {
    document.getElementById(CtlId).textContent = Value;
}
function isNoLicense(output) {
    if (output == 'NO_License') {
        return true;
    } else {
        return false;
    }
}
function CheckResult(Result, NewValue, OldValue, CurrentValue) {
    if (Result == "") Result = "2";

    if (NewValue != OldValue)
        if (NewValue == CurrentValue)
            return "1";
        else
            return "2";
    else
        return Result;

}

function LoadMaxLength($scope) {

    $scope.cfgUserInfo_FirstNameMaxLength = 40;                          //  UserInfo : กำหนดความยาวสูงสุด Field "ชื่อ"
    $scope.cfgUserInfo_LastNameMaxLength = 40;                           //  UserInfo : กำหนดความยาวสูงสุด Field "ชื่อสกุล"
    $scope.cfgUserInfo_FullNameMaxLength = 60;                           //  UserInfo : กำหนดความยาวสูงสุด Field "ชื่อเต็มภาษาอังกฤษ"
    $scope.cfgUserInfo_NickNameMaxLength = 40;                           //  UserInfo : กำหนดความยาวสูงสุด Field "ชื่อเล่น"
    $scope.cfgUserInfo_PassportNoMaxLength = 30;                         //  UserInfo : กำหนดความยาวสูงสุด Field "Passport No"
                                                                          
    $scope.cfgUserContact_ContactAddressMaxLength = 60;                  //  UserContact : กำหนดความยาวสูงสุด Field "ที่อยู่ที่ติดต่อได้ - ที่อยู่" 
    $scope.cfgUserContact_ContactRoadMaxLength = 40;                     //  UserContact : กำหนดความยาวสูงสุด Field "ที่อยู่ที่ติดต่อได้ - ถนน แขวง/ตำบล"   
    $scope.cfgUserContact_ContactDistrictMaxLength = 40;                 //  UserContact : กำหนดความยาวสูงสุด Field "ที่อยู่ที่ติดต่อได้ - เขต/อำเภอ"   
    $scope.cfgUserContact_AddressMaxLength = 60;                         //  UserContact : กำหนดความยาวสูงสุด Field "ที่อยู่ตามทะเบียนบ้าน - อยู่"   
    $scope.cfgUserContact_RoadMaxLength = 40;                            //  UserContact : กำหนดความยาวสูงสุด Field "ที่อยู่ตามทะเบียนบ้าน - ถนน แขวง/ตำบล"   
    $scope.cfgUserContact_DistrictMaxLength = 40;                        //  UserContact : กำหนดความยาวสูงสุด Field "ที่อยู่ตามทะเบียนบ้าน - เขต/อำเภอ"   
                                                                          
    $scope.cfgUserEmergency_Emergency1FirstNameMaxLength = 79;           //  UserEmergency : กำหนดความยาวสูงสุด Field "ชื่อ"
    $scope.cfgUserEmergency_Emergency1LastNameMaxLength = 79;            //  UserEmergency : กำหนดความยาวสูงสุด Field "ชื่อสกุล"
    $scope.cfgUserEmergency_Emergency1RelationMaxLength = 37;            //  UserEmergency : กำหนดความยาวสูงสุด Field "ความสัมพันธ์"
    $scope.cfgUserEmergency_Emergency1MobileMaxLength = 37;              //  UserEmergency : กำหนดความยาวสูงสุด Field "เบอร์โทรศัพท์ติดต่อ*"
    $scope.cfgUserEmergency_Emergency2FirstNameMaxLength = 79;           //  UserEmergency : กำหนดความยาวสูงสุด Field "ชื่อ"
    $scope.cfgUserEmergency_Emergency2LastNameMaxLength = 79;            //  UserEmergency : กำหนดความยาวสูงสุด Field "ชื่อสกุล"
    $scope.cfgUserEmergency_Emergency2RelationMaxLength = 37;            //  UserEmergency : กำหนดความยาวสูงสุด Field "ความสัมพันธ์"
    $scope.cfgUserEmergency_Emergency2MobileMaxLength = 37;              //  UserEmergency : กำหนดความยาวสูงสุด Field "เบอร์โทรศัพท์ติดต่อ*"

    $scope.cfgUserExpreience_OfficeMaxLength = 60;                       //  UserExpreience : กำหนดความยาวสูงสุด Field "สถานที่ทำงาน"
    $scope.cfgUserExpreience_PositionMaxLength = 25;                     //  UserExpreience : กำหนดความยาวสูงสุด Field "ตำแหน่ง"

    $scope.cfgUserSkill_DetailTextInRowMaxLength = 80;                   //  UserSkill : กำหนดความยาวสูงสุด Field "รายละเอียด"

    $scope.cfgUserFamily_ChildNoFamilyMaxLength = 2;                     //  UserFamily : กำหนดความยาวสูงสุด Field "ลำดับพี่น้อง/ลำดับบุตร"
    $scope.cfgUserFamily_FirstNameFamilyMaxLength = 40;                  //  UserFamily : กำหนดความยาวสูงสุด Field "ชื่อ"
    $scope.cfgUserFamily_LastNameFamilyMaxLength = 40;                   //  UserFamily : กำหนดความยาวสูงสุด Field "ชื่อสกุล"
    $scope.cfgUserFamily_PassportNoFamilyMaxLength = 30;                 //  UserFamily : กำหนดความยาวสูงสุด Field "Passport No"
    $scope.cfgUserFamily_OccupationMaxLength = 25;                       //  UserFamily : กำหนดความยาวสูงสุด Field "อาชีพ"
    $scope.cfgUserFamily_OfficeFamilyMaxLength = 40;                     //  UserFamily : กำหนดความยาวสูงสุด Field "สถานที่ทำงาน"

    $scope.cfgUserEducation_EduLocationMaxLength = 80;                   //  UserEduLocation : กำหนดความยาวสูงสุด Field "ชื่อเต็มสถาบัน"
    $scope.cfgUserEducation_EduDegreeMaxLength = 40;                     //  UserEduLocation : กำหนดความยาวสูงสุด Field "วุฒิการศึกษา - อื่นๆ (ระบุ)"
    $scope.cfgUserEducation_EduBranchMaxLength = 40;                     //  UserEduLocation : กำหนดความยาวสูงสุด Field "สาขาวิชา"
    $scope.cfgUserEducation_EduHonorMaxLength = 25;                      //  UserEduLocation : กำหนดความยาวสูงสุด Field "สาขาวิชา - อื่นๆ (ระบุ)"
    $scope.cfgUserEducation_EduGradeMaxLength = 4;                       //  UserEduLocation : กำหนดความยาวสูงสุด Field "GPA/Score"
    $scope.cfgUserEducation_EduSchoNameMaxLength = 40;                   //  UserEduLocation : กำหนดความยาวสูงสุด Field "ชื่อทุน"

    $scope.cfgUserPraise_DescPraiseTextInRowMaxLength = 80;              //  UserEduPraise : กำหนดความยาวสูงสุด Field "รายละเอียด"
    $scope.cfgUserPraise_PraiseTopicMaxLength = 50;                      //  UserEduPraise : กำหนดความยาวสูงสุด Field "รางวัลที่ได้รับ"

    $scope.cfgUserPraiseOper_DescOperTextInRowMaxLength = 80;            //  UserSpecialOper : กำหนดความยาวสูงสุด Field "รายละเอียด"

    $scope.cfgUserBank_BankAccountNameMaxLength = 40;                    //  UserContact : กำหนดความยาวสูงสุด Field "ชื่อบัญชี"
    $scope.cfgUserBank_BankAccountNameForMedicalMaxLength = 40;          //  UserContact : กำหนดความยาวสูงสุด Field "เลขบัญชี*"

    $scope.cfgUserLog_FilterEmpIDLogLength = 8;                          //  UserLog : กำหนดความยาวรหัสพนักงาน
    $scope.cfgUserLog_FilterEmpFullNameLogMaxLength = 80;                //  UserLog : กำหนดความยาวสูงสุดชื่อพนักงาน ไมเกิน 80 ตัวอักษรอักษร
    $scope.cfgUserLog_FilterEmpFullNameLogMinLength = 3;                 //  UserLog : กำหนดความยาวต่ำสุดชื่อพนักงาน 3 ตัวอักษร
    $scope.cfgUserLog_FilterDataSubGroupLogMaxLength = 100;              //  UserLog : กำหนดความยาวสูงสุดกลุ่มข้อมูลย่อย ไมเกิน 100 ตัวอักษรอักษร
                                                                         
    $scope.cfgUserLog_FilterDataSubGroupLogMinLength = 3;                //  UserLog : กำหนดความยาวต่ำสุดกลุ่มข้อมูลย่อย 3 ตัวอักษร
    $scope.cfgUserLog_FilterDataNameLogMaxLength = 100;                  //  UserLog : กำหนดความยาวสูงสุดหัวข้อ ไมเกิน 100 ตัวอักษรอักษร
    $scope.cfgUserLog_FilterDataNameLogMinLength = 3;                    //  UserLog : กำหนดความยาวต่ำสุดหัวข้อ 3 ตัวอักษร
                                                                         
    $scope.cfgUserLog_FilterDataOldLogMaxLength = 100;                   //  UserLog : กำหนดความยาวสูงสุดข้อมูลเดิม ไมเกิน 100 ตัวอักษรอักษร
    $scope.cfgUserLog_FilterDataOldLogMinLength = 3;                     //  UserLog : กำหนดความยาวต่ำสุดข้อมูลเดิม 3 ตัวอักษร
    $scope.cfgUserLog_FilterDataNewLogMaxLength = 100;                   //  UserLog : กำหนดความยาวสูงสุดข้อมูลใหม่ ไมเกิน 100 ตัวอักษรอักษร
    $scope.cfgUserLog_FilterDataNewLogMinLength = 3;                     //  UserLog : กำหนดความยาวต่ำสุดข้อมูลใหม่ 3 ตัวอักษร
}

function getParam(name) {
    var url = location.href;
    name = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
    var regexS = "[\\?&]" + name + "=([^&#]*)";
    var regex = new RegExp(regexS);
    var results = regex.exec(url);
    return results == null ? null : results[1];
}
function fnCheckDateStartOverDateEnd(dateStart, dateEnd) {
    var status = 0;
    var today = new Date();
    var SP_DateStart = dateStart.split('/');
    var SP_DateEnd = dateEnd.split('/');

    var tmpYearStart = SP_DateStart[2] - 543;
    var tmpYearEnd = SP_DateEnd[2] - 543;

    var strDateStart = tmpYearStart + "-" + SP_DateStart[1] + "-" + SP_DateStart[0];
    var strDateEnd = tmpYearEnd + "-" + SP_DateEnd[1] + "-" + SP_DateEnd[0];

    var convDateStart = new Date(strDateStart);
    var convDateEnd = new Date(strDateEnd);

    var YdateStart = convDateStart.getFullYear();
    var MdateStart = convDateStart.getMonth() + 1;
    var DdateStart = convDateStart.getDate();

    var YdateEnd = convDateEnd.getFullYear();
    var MdateEnd = convDateEnd.getMonth() + 1;
    var DdateEnd = convDateEnd.getDate();

    var nDay = DdateEnd - DdateStart;

    if (YdateStart == YdateEnd && MdateStart <= MdateEnd)
        if (MdateStart == MdateEnd && nDay < 0)
            status = 1;
        else
            status = 0;
    else if (YdateStart < YdateEnd)
        status = 0;
    else
        status = 1;

    return status;
}
function fnCheckDateEmpOverDateFam(dateStart, dateEnd) {
    var status = 0;
    var today = new Date();
    var SP_DateStart = dateStart.split('/');
    var SP_DateEnd = dateEnd.split('/');

    var tmpYearStart = SP_DateStart[2] - 543;
    var tmpYearEnd = SP_DateEnd[2] - 543;

    var strDateStart = tmpYearStart + "-" + SP_DateStart[1] + "-" + SP_DateStart[0];
    var strDateEnd = tmpYearEnd + "-" + SP_DateEnd[1] + "-" + SP_DateEnd[0];

    var convDateStart = new Date(strDateStart);
    var convDateEnd = new Date(strDateEnd);

    var YdateStart = convDateStart.getFullYear();
    var MdateStart = convDateStart.getMonth() + 1;
    var DdateStart = convDateStart.getDate();

    var YdateEnd = convDateEnd.getFullYear();
    var MdateEnd = convDateEnd.getMonth() + 1;
    var DdateEnd = convDateEnd.getDate();

    var nDay = DdateEnd - DdateStart;

    if (YdateStart == YdateEnd && MdateStart <= MdateEnd)
        if (MdateStart == MdateEnd && nDay <= 0)
            status = 1;
        else
            status = 0;
    else if (YdateStart < YdateEnd)
        status = 0;
    else
        status = 1;

    return status;
}
function fnCheckOverDateCurrent(dateString) {

    var status = 0;
    var today = new Date();
    var SP = dateString.split('/');
    var tmpYear = SP[2];

    if (tmpYear > 2300)
        tmpYear = tmpYear - 543;

    var str = tmpYear + "-" + SP[1] + "-" + SP[0];
    var DateInput = new Date(str);

    var Ytoday = today.getFullYear();
    var Mtoday = today.getMonth() + 1;
    var Dtoday = today.getDate();

    var YInput = DateInput.getFullYear();
    var MInput = DateInput.getMonth() + 1;
    var DInput = DateInput.getDate();

    var nDay = Dtoday - DInput;

    if (YInput == Ytoday && MInput <= Mtoday)
        if (MInput == Mtoday && nDay < 0)
            status = 1;
        else
            status = 0;
    else if (YInput < Ytoday)
        status = 0;


    return status;
}
function fnCheckCreateDateTxnStatus(dateString) {

    var status = 0;
    var today = new Date();
    var SP = dateString.split('/');
    var tmpYear = SP[2];

    if (tmpYear > 2300)
        tmpYear = tmpYear - 543;

    var str = tmpYear + "-" + SP[1] + "-" + SP[0];
    var CreateDate = new Date(str);

    var Ytoday = today.getFullYear();
    var Mtoday = today.getMonth() + 1;
    var Dtoday = today.getDate();

    var YCreate = CreateDate.getFullYear();
    var MCreate = CreateDate.getMonth() + 1;
    var DCreate = CreateDate.getDate();

    if (Ytoday == YCreate && Mtoday == MCreate) {
        var Lday = Dtoday - DCreate;
        if (Lday == 0 || Lday == 1) {
            status = 1;
        }
    }

    return status;
}
function fnSplitPersonalID(PID, caseSplit) {
    var SP_PID = PID.split('');
    if (caseSplit == 1) {
        var PID = [];
        var txtID1 = ""; var txtID2 = ""; var txtID3 = "";
        var txtID4 = ""; var txtID5 = "";
        txtID1 = SP_PID[0];
        txtID2 = SP_PID[1] + SP_PID[2] + SP_PID[3] + SP_PID[4];
        txtID3 = SP_PID[5] + SP_PID[6] + SP_PID[7] + SP_PID[8] + SP_PID[9];
        txtID4 = SP_PID[10] + SP_PID[11];
        txtID5 = SP_PID[12];
        PID.push(txtID1, txtID2, txtID3, txtID4, txtID5);
        return PID;
    }
    else {
        return SP_PID[0] + "-" + SP_PID[1] + SP_PID[2] + SP_PID[3] + SP_PID[4] + "-" + SP_PID[5] + SP_PID[6] + SP_PID[7] + SP_PID[8] + SP_PID[9] + "-" + SP_PID[10] + SP_PID[11] + "-" + SP_PID[12]
    }
}
function isNumeric(n) {
    return !isNaN(parseFloat(n)) && isFinite(n);
}
function fnCheckDataChange(CtlId, oldValue, newValue, displayName, ActionType) {

    if (ActionType == "U") {
        if (newValue != oldValue)
            setInnerHTML(CtlId, displayName + "&nbsp;<span class='badge badge-pill badge-warning'>Edit</span>");
        else
            setInnerText(CtlId, displayName);
    }
    else {
        setInnerText(CtlId, displayName);
    }
}
function fnCheckDataChangeAttachFile(CtlId, oldValue, newValue, displayName, ActionType) {
    if (ActionType == "U") {
        if (newValue != oldValue)
            setInnerHTML(CtlId, displayName + "&nbsp;<span class='badge badge-pill badge-warning'>Edit</span>");
        else
            setInnerText(CtlId, displayName);
    } else {
        setInnerText(CtlId, displayName);
    }

    if (newValue != "")
        document.getElementById(CtlId).href = "../Popup/popOpenPDF.aspx?AttachID=" + newValue;
    else
        document.getElementById(CtlId).removeAttribute("href");
}
function fnClearListDataChange(CtlId) {
    var ul = document.getElementById(CtlId);
    ul.innerHTML = "";
}
function fnCheckDataChangeOnly(CtlId, oldValue, newValue, titleName, displayName) {
    if (newValue != oldValue) {
        var label = document.createElement("label");
        var ul = document.getElementById(CtlId);
        var li = document.createElement("li");

        if (displayName == "-- โปรดเลือก --") {
            displayName = "";
        }

        label.className = 'col-form-label';
        label.setAttribute('style', 'word-wrap: break-word; display: inline; margin-bottom: 0px;');
        label.textContent = titleName + " : " + displayName;
        li.appendChild(label);
        ul.appendChild(li);
    }
}
function fnCheckDataChangeAttachFileOnly(CtlId, oldValue, newValue, titleName, displayNameNew, displayNameOld) {
    if (newValue != oldValue) {
        var ul = document.getElementById(CtlId);
        var li = document.createElement("li");
        var label = document.createElement("label");
        label.className = 'col-form-label';
        label.setAttribute('style', 'word-wrap: break-word; display: inline; margin-bottom: 0px;');

        if (newValue != "") {
            if (oldValue != "") {
                var strong1 = document.createElement("strong");
                var strong2 = document.createElement("strong");
                var label2 = document.createElement("label");
                label2.className = 'col-form-label';
                label2.setAttribute('style', 'word-wrap: break-word; display: inline; margin-bottom: 0px;');
                var a1 = document.createElement("a");
                a1.textContent = displayNameOld;
                a1.setAttribute('href', "../Popup/popOpenPDF.aspx?AttachID=" + oldValue);
                a1.setAttribute('target', "_blank");
                var a2 = document.createElement("a");
                a2.textContent = displayNameNew;
                a2.setAttribute('href', "../Popup/popOpenPDF.aspx?AttachID=" + newValue);
                a2.setAttribute('target', "_blank");

                label.textContent = titleName + " : ";
                strong1.textContent = "เอกสารเดิม ";
                label.appendChild(strong1);
                label.appendChild(a1);

                strong2.textContent = "เอกสารใหม่ ";
                label2.textContent = ", ";
                label2.appendChild(strong2);
                label2.appendChild(a2);
                label.appendChild(label2);

                li.appendChild(label);
                ul.appendChild(li);
            } else {
                var a = document.createElement("a");
                a.textContent = displayNameNew;
                a.setAttribute('href', "../Popup/popOpenPDF.aspx?AttachID=" + newValue);
                a.setAttribute('target', "_blank");
                label.textContent = titleName + " : ";
                label.appendChild(a);
                li.appendChild(label);
                ul.appendChild(li);
            }
        }
        else {
            label.textContent = titleName + " : ";
            li.appendChild(label);
            ul.appendChild(li);
        }

        /*
        if (newValue != "") {
            var a = document.createElement("a");
            a.textContent = displayNameOld;
            a.setAttribute('href', "../Popup/popOpenPDF.aspx?AttachID=" + newValue);
            a.setAttribute('target', "_blank");
            label.textContent = titleName + " : ";
            label.appendChild(a);
            li.appendChild(label);
            ul.appendChild(li);
        }
        else {
            label.textContent = titleName + " : ";
            li.appendChild(label);
            ul.appendChild(li);
        }
        */

    }
}
function fnSetActiveBtn(txbValueActive_CtlId, typeActive, btnActiveID1, btnActiveID2) {
    if (typeActive == 'True') {
        setValue(txbValueActive_CtlId, 'True');
        document.getElementById(btnActiveID1).className = "btn btn-outline-primary active";
        document.getElementById(btnActiveID2).className = "btn btn-outline-primary";
    }
    else {
        setValue(txbValueActive_CtlId, 'False');
        document.getElementById(btnActiveID1).className = "btn btn-outline-primary";
        document.getElementById(btnActiveID2).className = "btn btn-outline-primary active";
    }
}
function fnSetHighlightCardLists(indexCard) {
    if (indexCard >= 0) {
        var itmLists = document.getElementsByClassName('card ng-scope').length;
        for (var i = 0; i < itmLists ; i++) {
            if (i == indexCard)
                document.getElementsByClassName('card ng-scope')[i].className = "card ng-scope bg-highlight";
            else
                document.getElementsByClassName('card ng-scope')[i].className = "card ng-scope";
        }
    }
    else if (indexCard == "") {
        return;
    }
}
function fnClearHighlightCardLists() {
    var itmLists = document.getElementsByClassName('card ng-scope').length;
    for (var i = 0; i < itmLists ; i++)
        document.getElementsByClassName('card ng-scope')[i].className = "card ng-scope";
}
function fnSetHighlightDeleteCardLists(indexCard) {
    var itmLists = document.getElementsByClassName('card ng-scope').length;
    for (var i = 0; i < itmLists ; i++) {
        if (i == indexCard)
            document.getElementsByClassName('card ng-scope')[i].className = "card ng-scope bg-highlightDelete";
        else
            document.getElementsByClassName('card ng-scope')[i].className = "card ng-scope";
    }
}
function fnClearHighlightDeleteCardLists() {
    var itmLists = document.getElementsByClassName('card ng-scope').length;
    for (var i = 0; i < itmLists ; i++)
        document.getElementsByClassName('card ng-scope')[i].className = "card ng-scope";
}


function fnSetPopMassageSubmit(submitType, IsSendMailStatus, CtlId_MassageWarning, CtlId_TitalChange) {
    if (submitType == "Edit") {
        if (IsSendMailStatus == "True")
            setInnerHTML(CtlId_MassageWarning, '<label class="col-form-label" style="word-wrap: break-word; display: contents; margin-bottom: 0px;">ต้องการยืนยันการปรับปรุงข้อมูล และ<u>ส่งเมล</u>แจ้งผู้บังคับบัญชา</label>');
        else
            setInnerHTML(CtlId_MassageWarning, '<label class="col-form-label" style="word-wrap: break-word; display: contents; margin-bottom: 0px;">ต้องการยืนยันการปรับปรุงข้อมูล และ<u>ไม่ส่งเมล</u>แจ้งผู้บังคับบัญชา</label>');

        setInnerText(CtlId_TitalChange, "ข้อมูลที่เปลี่ยนแปลง");
    }
    else {
        if (IsSendMailStatus == "True")
            setInnerHTML(CtlId_MassageWarning, '<label class="col-form-label" style="word-wrap: break-word; display: contents; margin-bottom: 0px;">ต้องการยืนยันการเพิ่มข้อมูล และ<u>ส่งเมล</u>แจ้งผู้บังคับบัญชา</label>');
        else
            setInnerHTML(CtlId_MassageWarning, '<label class="col-form-label" style="word-wrap: break-word; display: contents; margin-bottom: 0px;">ต้องการยืนยันการเพิ่มข้อมูล และ<u>ไม่ส่งเมล</u>แจ้งผู้บังคับบัญชา</label>');

        setInnerText(CtlId_TitalChange, "ข้อมูลที่เพิ่ม");
    }
}
function fnGetFomatDateTH_MMYY(Date) {
    var monthNamesThai = ["มกราคม", "กุมภาพันธ์", "มีนาคม", "เมษายน", "พฤษภาคม", "มิถุนายน", "กรกฎาคม", "สิงหาคม", "กันยายน", "ตุลาคม", "พฤษจิกายน", "ธันวาคม"];
    if (Date == "") return "";
    var SP_Date = Date.split('/');

    return monthNamesThai[parseInt(SP_Date[1]) - 1] + " " + SP_Date[2];
}
/*
function fnClearWarning(divId) {
   setInnerHTML(divId, "");
}
function fnWarningUpdateSAPFail(divId, Message) {

   setInnerHTML(divId, '<div class="col-12 col-xs-11 alert alert-warning" role="alert"  >' +
                                                      '     <div class="media">' +
                                                      '         <div class="d-flex m-2 mr-3" style="font-size: 1.3rem;">' +
                                                      '             <i class="el el-warning-sign"></i>' +
                                                      '         </div>' +
                                                      '         <div class="media-body">' +
                                                      '             <label class="col-form-label" style="margin-bottom: 0px;color: red;">' + Message + '</label>' +
                                                      '         </div>' +
                                                      '    </div>' +
                                                      ' </div>');
}
function fnErrorInfo(divId, Title, MessageList) {
   var Message = "";
   for (var i = 0; i < MessageList.length; i++) {
       Message = Message + '<li>' + MessageList[i] + '</li>';
   }
   setInnerHTML(divId, '<div class="col-12 col-xs-11 alert alert-danger" role="alert" >' +
                                                      '     <div class="media">' +
                                                      '         <div class="d-flex m-2 mr-3" style="font-size: 1.3rem;">' +
                                                      '             <i class="el el-remove-sign"></i>' +
                                                      '         </div>' +
                                                      '         <div class="media-body">' +
                                                      '             <strong>' + Title + '</strong>' +
                                                      '             <ul>' + Message + '</ul>' +
                                                      '         </div>' +
                                                      '    </div>' +
                                                      ' </div>');
}
*/
function fnSetValueDrpd(CtlId, Value) {
    setValue(CtlId, Value);
    var cbx_Value = getValue(CtlId).trim();
    if (cbx_Value == "") setValue(CtlId, "");
}
//============Attach File=====================
var tmpFileLabel;
var tmpFileValue;
function fnAddFile(File_Label, File_Value) {
    tmpFileLabel = File_Label;
    tmpFileValue = File_Value;
    fnOpenWindow('ไฟล์แนบ', '../Popup/popFileUpload.aspx', fnUpload, "240px", 'Upload');
}
function fnUpload() {
    var iWin = fnGetWindow();
    iWin.fnUpload();
}
function fnSectionFile_SetFile(AttachID, FileName) {
    document.getElementById(tmpFileLabel).innerText = FileName;
    document.getElementById(tmpFileValue).value = AttachID;
    document.getElementById(tmpFileLabel).href = '../Popup/popOpenPDF.aspx?AttachID=' + AttachID;
    fnAttachFileVadidation();
    fnCloseWindow();
}
function fnDeleteFile(File_Label, File_Value, File_Type) {
    tmpFileLabel = File_Label;
    tmpFileValue = File_Value;
    var AttachTypeValue = getValue(File_Value).trim();
    if (AttachTypeValue != "") fnShowQuestion("ผลการทำงาน", "คุณต้องการลบข้อมูล " + File_Type + " หรือไม่", null, 'fnConfirmDeleteAttachFile', false, false, '');
}
function fnConfirmDeleteAttachFile() {
    document.getElementById(tmpFileLabel).innerText = "";
    document.getElementById(tmpFileValue).value = "";
    setValue(tmpFileValue, "");
}
//=====================================
function Numbers(e) {
    var keynum;
    var keychar;
    var numcheck;
    if (window.event) {// IE
        keynum = e.keyCode;
    }
    else if (e.which) {// Netscape/Firefox/Opera
        keynum = e.which;
    }
    if (keynum == 13 || keynum == 8 || typeof (keynum) == "undefined") {
        return true;
    }
    keychar = String.fromCharCode(keynum);
    numcheck = /^[0-9]$/;
    return numcheck.test(keychar);
}

function keyup(obj, e) {
    var keynum;
    var keychar;
    var id = '';
    if (window.event) {// IE
        keynum = e.keyCode;
    }
    else if (e.which) {// Netscape/Firefox/Opera
        keynum = e.which;
    }
    keychar = String.fromCharCode(keynum);

    var tagInput = document.getElementsByTagName('input');
    for (i = 0; i <= tagInput.length; i++) {
        if (tagInput[i] == obj) {
            var prevObj = tagInput[i - 1];
            var nextObj = tagInput[i + 1];
            break;
        }
    }
    if (obj.value.length == 0 && keynum == 8) prevObj.focus();

    if (obj.value.length == obj.getAttribute('maxlength')) {
        for (i = 0; i <= tagInput.length; i++) {
            if (tagInput[i].id.substring(0, 5) == 'txtID') {
                if (tagInput[i].value.length == tagInput[i].getAttribute('maxlength')) {
                    id += tagInput[i].value;
                    if (tagInput[i].id == 'txtID5') break;
                }
                else {
                    tagInput[i].focus();
                    return;
                }
            }
        }
        if (checkID(id)) nextObj.focus();
        //else alert('รหัสประชาชนไม่ถูกต้อง');
        nextObj.focus();
    }
}

function checkID(id) {
    if (id.length != 13) return false;
    for (i = 0, sum = 0; i < 12; i++)
        sum += parseFloat(id.charAt(i)) * (13 - i);
    if ((11 - sum % 11) % 10 != parseFloat(id.charAt(12)))
        return false;
    return true;
}