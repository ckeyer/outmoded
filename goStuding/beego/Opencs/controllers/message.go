package controllers

import (
	"github.com/astaxie/beego"
)

type MessageController struct {
	beego.Controller
}

func (this *MessageController) Get() {
	// this.Data["Website"] = "beego.me"
	// this.Data["Email"] = "astaxie@gmail.com"
	this.TplNames = "Message.tpl"

}

func (this *MessageController) Post() {
	// this.Data["Website"] = "beego.me"
	// this.Data["Email"] = "astaxie@gmail.com"
	// this.TplNames = "mainLogin.tpl"

}
