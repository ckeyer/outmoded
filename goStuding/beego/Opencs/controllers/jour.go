package controllers

import (
	"github.com/astaxie/beego"
)

type JourController struct {
	beego.Controller
}

func (this *JourController) Get() {
	// this.Data["Website"] = "beego.me"
	// this.Data["Email"] = "astaxie@gmail.com"
	this.TplNames = "Jour.tpl"

}

func (this *JourController) Post() {
	// this.Data["Website"] = "beego.me"
	// this.Data["Email"] = "astaxie@gmail.com"
	// this.TplNames = "mainLogin.tpl"

}
