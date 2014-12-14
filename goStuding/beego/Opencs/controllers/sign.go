package controllers

import (
	"github.com/astaxie/beego"
)

type SignController struct {
	beego.Controller
}

func (this *SignController) Get() {
	// this.Data["Website"] = "beego.me"
	// this.Data["Email"] = "astaxie@gmail.com"
	this.TplNames = "Sign.tpl"
}
