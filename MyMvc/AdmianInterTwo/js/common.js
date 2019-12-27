//打开字滑入效果
window.onload = function(){
	$(".connect p").eq(0).animate({"left":"0%"}, 600);
	$(".connect p").eq(1).animate({"left":"0%"}, 400);
};
//jquery.validate表单验证
$(document).ready(function(){
	//登陆表单验证
	$("#loginForm").validate({
		rules:{
			Sname:{
				required:true,//必填
				minlength:2, //最少6个字符
				maxlength:32,//最多20个字符
			},
            Passwords:{
				required:true,
				minlength:3, 
				maxlength:32,
			},
		},
		//错误信息提示
		messages:{
			Sname:{
				required:"必须填写用户名",
				minlength:"用户名至少为2个字符",
				maxlength:"用户名至多为32个字符",
				remote: "用户名已存在",
			},
            Passwords:{
				required:"必须填写密码",
				minlength:"密码至少为3个字符",
				maxlength:"密码至多为32个字符",
			},
		},

    });



	//注册表单验证
	$("#registerForm").validate({
		rules:{
			Sname:{
				required:true,//必填
				minlength:2, //最少6个字符
				maxlength:32,//最多20个字符
				//remote:{
				//	url:"http://kouss.com/demo/Sharelink/remote.json",//用户名重复检查，别跨域调用
				//	type:"post",
				//},
			},
            Passwords:{
				required:true,
				minlength:3, 
				maxlength:32,
			},
			Email:{
				required:true,
				Email:true,
			},
			confirm_password:{
				required:true,
				minlength:3,
                equalTo:'.Passwords'
			},
			Phone:{
				required:true,
				Phone:true,//自定义的规则
				digits:true,//整数
			}
		},
		//错误信息提示
		messages:{
			Sname:{
				required:"必须填写用户名",
				minlength:"用户名至少为2个字符",
				maxlength:"用户名至多为32个字符",
				remote: "用户名已存在",
			},
            Passwords:{
				required:"必须填写密码",
				minlength:"密码至少为3个字符",
				maxlength:"密码至多为32个字符",
			},
			Email:{
				required:"请输入邮箱地址",
				Email: "请输入正确的Email地址"
			},
			confirm_password:{
				required: "请再次输入密码",
				minlength: "确认密码不能少于3个字符",
				equalTo: "两次输入密码不一致",//与另一个元素相同
			},
			Phone:{
				required:"请输入手机号码",
				digits:"请输入正确的手机号码",
			},
		
		},
	});
	//添加自定义验证规则
	jQuery.validator.addMethod("Phone", function(value, element) { 
		var length = value.length; 
        var Phone = /^[1](([3][0-9])|([4][5-9])|([5][0-3,5-9])|([6][5,6])|([7][0-8])|([8][0-9])|([9][1,8,9]))[0-9]{8}$/
		return this.optional(element) || (length == 11 && Phone.test(value)); 
	}, "手机号码格式错误"); 
});
