package controllers

import (
	"github.com/astaxie/beego"
)

type Lab204Controller struct {
	beego.Controller
}

func (this *Lab204Controller) Get() {
	// this.Data["Website"] = "beego.me"
	// this.Data["Email"] = "astaxie@gmail.com"
	this.TplNames = "Lab204.tpl"

}

func (this *Lab204Controller) Post() {
	// this.Data["Website"] = "beego.me"
	// this.Data["Email"] = "astaxie@gmail.com"
	// this.TplNames = "mainLogin.tpl"

}
