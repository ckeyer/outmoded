package controllers

import (
	"github.com/astaxie/beego"
)

type NoticeController struct {
	beego.Controller
}

func (this *NoticeController) Get() {
	// this.Data["Website"] = "beego.me"
	// this.Data["Email"] = "astaxie@gmail.com"
	this.TplNames = "Notice.tpl"

}

func (this *NoticeController) Post() {
	// this.Data["Website"] = "beego.me"
	// this.Data["Email"] = "astaxie@gmail.com"
	// this.TplNames = "mainLogin.tpl"

}
