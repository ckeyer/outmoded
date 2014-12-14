package controllers

import (
	"github.com/astaxie/beego"
)

type ForumController struct {
	beego.Controller
}

func (this *ForumController) Get() {
	// this.Data["Website"] = "beego.me"
	// this.Data["Email"] = "astaxie@gmail.com"
	this.TplNames = "Forum.tpl"

}

func (this *ForumController) Post() {
	// this.Data["Website"] = "beego.me"
	// this.Data["Email"] = "astaxie@gmail.com"
	// this.TplNames = "mainLogin.tpl"

}
