package controllers

import (
	"github.com/astaxie/beego"
)

type BlogController struct {
	beego.Controller
}

func (this *BlogController) Get() {
	// this.Data["Website"] = "beego.me"
	// this.Data["Email"] = "astaxie@gmail.com"
	this.TplNames = "Blog.tpl"

}

func (this *BlogController) Post() {
	// this.Data["Website"] = "beego.me"
	// this.Data["Email"] = "astaxie@gmail.com"
	// this.TplNames = "mainLogin.tpl"

}
