package controllers

import (
	"github.com/astaxie/beego"
)

type VideoController struct {
	beego.Controller
}

func (this *VideoController) Get() {
	// this.Data["Website"] = "beego.me"
	// this.Data["Email"] = "astaxie@gmail.com"
	this.TplNames = "Video.tpl"

}

func (this *VideoController) Post() {
	// this.Data["Website"] = "beego.me"
	// this.Data["Email"] = "astaxie@gmail.com"
	// this.TplNames = "mainLogin.tpl"

}
