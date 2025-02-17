function ToolClick(ConfigName, TID, Command) {
    switch (ConfigName) {
        case "Administrator": class_management(TID, Command); break;
        case "DocumentManage": class_management(TID, Command); break;
        default: alert("No ConfigName"); break;
    }
}
//====================== Demo ======================
function class_management(TID, Command) {
    switch (TID) {
        case "ToolsAddUser": fnUser_Tools(Command); break;
        case "ToolsPosition": fnPosition_Tools(Command); break;
        case "ToolsAddBook": fnGunRegister_Tools(Command); break;
        case "ToolsAddPage": fnGunRegister_Tools(Command); break;
        default: alert("No Tools  " + Command + " " + TID + " Function in DEMO"); break;
    }
}

function fnUser_Tools(Command) {
    var SelectRows, url, ID;
    switch (Command) {
        case "AddUser":
            url = "/PartialViewModal/PVM_User";
            showpopup('เพิ่มข้อมูลผู้ใช้งาน', url, 480, 100, 'SaveUser');
            break;
        case "EditUser":
            SelectRows = getSelectRows();
            if (SelectRows === "") {
                return showmessage("โปรดเลือกรายการที่จะทำการแก้ไข");
            }
            ID = getCurrentValue(SelectRows, "ID");
            var SPACE_USER = getCurrentValue(SelectRows, "SPACE_USER");

            url = "/PartialViewModal/PVM_User?ID=" + ID + "&SPACE_USER=" + SPACE_USER;
            showpopup('เพิ่มข้อมูลผู้ใช้งาน', url, 480, 100, 'SaveUser');
            break;
        case "DeleteUser":
            SelectRows = getSelectRows();
            if (SelectRows === "") {
                return showmessage("โปรดเลือกรายการที่จะทำการแก้ไข");
            }
            ID = getCurrentValue(SelectRows, "ID");

            showconfirmDelete("คุณต้องการลบข้อมูลหรือไม่ ?", DeleteDataByDocID, ID, "Users");
            break;

        default: alert("No Command in Tools demo function"); break;
    }
}

function fnPosition_Tools(Command) {
    var SelectRows, url, ID;
    switch (Command) {
        case "AddPosition":
            url = "/PartialViewModal/PVM_Position";
            showpopup('เพิ่มข้อมูลตำแหน่ง', url, 900, 100);
            break;
        case "EditPosition":
            SelectRows = getSelectRows();
            if (SelectRows === "") {
                return showmessage("โปรดเลือกรายการที่จะทำการแก้ไข");
            }
            ID = getCurrentValue(SelectRows, "ID");
            url = "/PartialViewModal/PVM_Position?ID=" + ID;
            showpopup('เพิ่มข้อมูลตำแหน่ง', url, 900, 100);
            break;
        case "DeletePosition":
            SelectRows = getSelectRows();
            if (SelectRows === "") {
                return showmessage("โปรดเลือกรายการที่จะทำการแก้ไข");
            }
            ID = getCurrentValue(SelectRows, "ID");

            showconfirmDelete("คุณต้องการลบข้อมูลหรือไม่ ?", DeleteDataByDocID, ID, "Position");
            break;

        default: alert("No Command in Tools demo function"); break;
    }
}

function fnGunRegister_Tools(Command) {
    var SelectRows, url, ID;
    switch (Command) {
        case "AddBook":
            url = "/PartialViewModal/PVM_Book";
            showpopup('เพิ่มข้อมูลหนังสือทะเบียนอาวุธปืน', url, 600, 100, 'SaveBook');
            break;
        case "EditBook":
            SelectRows = getSelectRows();
            if (SelectRows === "") {
                return showmessage("โปรดเลือกรายการที่จะทำการแก้ไข");
            }
            ID = getCurrentValue(SelectRows, "ID");
            url = "/PartialViewModal/PVM_Book?ID=" + ID;
            showpopup('แก้ไขข้อมูลหนังสือทะเบียนอาวุธปืน', url, 600, 100, 'SaveBook');
            break;
        case "DeleteBook":
            SelectRows = getSelectRows();
            if (SelectRows === "") {
                return showmessage("โปรดเลือกรายการที่จะทำการแก้ไข");
            }
            ID = getCurrentValue(SelectRows, "ID");
            showconfirmDelete("คุณต้องการลบข้อมูลหรือไม่ ?", DeleteDataByDocID, ID, "Book");
            break;

        case "AddPage":
            url = "/PartialViewModal/PVM_Page";
            showpopup('เพิ่มข้อมูลหน้าหนังสือทะเบียนอาวุธปืน', url, 900, 100,'SavePage');
            break;
        case "EditPage":
            SelectRows = getSelectRows();
            if (SelectRows === "") {
                return showmessage("โปรดเลือกรายการที่จะทำการแก้ไข");
            }
            ID = getCurrentValue(SelectRows, "ID");
            url = "/PartialViewModal/PVM_Page?ID=" + ID;
            showpopup('แก้ไขเพิ่มข้อมูลหน้าหนังสือทะเบียนอาวุธปืน', url, 900, 100, 'SavePage');
            break;
        case "DeletePage":
            SelectRows = getSelectRows();
            if (SelectRows === "") {
                return showmessage("โปรดเลือกรายการที่จะทำการแก้ไข");
            }
            ID = getCurrentValue(SelectRows, "ID");
            showconfirmDelete("คุณต้องการลบข้อมูลหรือไม่ ?", DeleteDataByDocID, ID, "Page");
            break;

        default: alert("No Command in Tools demo function"); break;
    }
}
 
function DeleteDataByDocID(ID, TableName) {
    fnLoadingManagement();
    $.ajax({
        type: 'POST',
        cache: false,
        url: '/Service/DeleteDataByDocID',
        data: "ID=" + ID + "&TableName=" + TableName,
        success: function (data, textStatus, jqXHR) {
            console.log(data);
            if (data.code === "OK")
                showmessage(data.message, refreshAllData);
            else
                showmessage(data.message);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            showmessage(jqXHR, textStatus, errorThrown);
        }
    });
}

 
 