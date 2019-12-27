
//用户名
//function check_Sname() {

//    var Sname = document.getElementById("name").value;

//    var regName = /[a-zA-Z]\w{4,16}/

//    if (Sname == "" || Sname.trim() == "") {

//        document.getElementById("err_name").innerHTML = "请输入用户名";

//        return false;

//    } else if (!regName.test(Sname)) {

//        document.getElementById("err_name").innerHTML = "由英文字母和数字组成的4-16位字符，以字母开头";

//        return false;

//    } else {

//        document.getElementById("err_name").innerHTML = "ok!!!";

//        return true;

//    }

//}

//验证昵称

//姓名
function check_nickName() {

    var nickName = document.getElementById("nick").value;

    var regName = /[\u4e00-\u9fa5]{2,6}/

    if (nickName == "" || nickName.trim() == "") {

        document.getElementById("err_nick").innerHTML = "请输入昵称";

        return false;

    } else if (!regName.test(nickName)) {

        document.getElementById("err_nick").innerHTML = "由2-6个汉字组成";

        return false;

    } else {

        document.getElementById("err_nick").innerHTML = "ok!!!";

        return true;

    }

}

//验证邮箱

function check_Email() {

    var Email = document.getElementById("Email").value;

    var regEmail = /^\w+@\w+((\.\w+)+)$/;

    if (Email == "" || Email.trim() == "") {

        document.getElementById("err_Email").innerHTML = "请输入邮箱";

        return false;

    } else if (!regEmail.test(Email)) {

        document.getElementById("err_Email").innerHTML = "邮箱账号@域名。如good@tom.com、whj@sina.com.cn";

        return false;

    } else {

        document.getElementById("err_Email").innerHTML = "ok!!!";

        return true;

    }

}

//验证密码

function check_pwd() {

    var Passwords = document.getElementById("pwd").value;

    var regPwd = /^\w{4,10}$/;

    if (Passwords == "" || Passwords.trim() == "") {

        document.getElementById("err_pwd").innerHTML = "请输入密码";

        return false;

    } else if (!regPwd.test(Passwords)) {

        document.getElementById("err_pwd").innerHTML = "格式错误";

        return false;

    } else {

        document.getElementById("err_pwd").innerHTML = "ok!!!";

        return true;

    }

}

//确认密码

function check_pwd2() {

    var Passwords = document.getElementById("pwd").value;

    var PasswordsTwo = document.getElementById("pwd2").value;

    if (PasswordsTwo == "" || PasswordsTwo.trim() == "") {

        document.getElementById("err_pwd2").innerHTML = "请输入密码";

        return false;

    } else if (!PasswordsTwo.equals(Passwords)) {

        document.getElementById("err_pwd2").innerHTML = "两次输入密码不一致";

        return false;

    } else {

        document.getElementById("err_pwd2").innerHTML = "ok!!!";

        return true;

    }

}

//验证手机号

function check_phone() {

    var Phone = document.getElementById("phone").value;

    var regPhone = /[13,15,18]\d{9}/;

    if (Phone == "" || Phone.trim() == "") {

        document.getElementById("err_phone").innerHTML = "请输入手机号";

        return false;

    } else if (!regPhone.test(Phone)) {

        document.getElementById("err_phone").innerHTML = "手机号由11位数字组成，且以13,15,18开头";

        return false;

    } else {

        document.getElementById("err_phone").innerHTML = "ok!!!";

        return true;

    }

}

//验证时间

//function check_date() {

//    var birthday = document.getElementById("birthday").value;

//    var regDate = /[13,15,18]\d{9}/;

//    if (birthday == "" || birthday.trim() == "") {

//        document.getElementById("err_date").innerHTML = "请输入日期";

//        return false;

//    } else if (!regDate.test(birthday)) {

//        document.getElementById("err_date").innerHTML = "出生日期在1990-2009之间";

//        return false;

//    } else {

//        document.getElementById("err_date").innerHTML = "ok!!!";

//        return true;

//    }

//}