package controllers

import (
	"Opencs/controllers/opencs"
	"fmt"
	"github.com/astaxie/beego"
	// "opencs"
)

type MainController struct {
	beego.Controller
}

func (this *MainController) Get() {
	// this.Data["Website"] = "beego.me"
	// this.Data["Email"] = "astaxie@gmail.com"
	var website opencs.Website
	err := website.Init_Website()
	if err != nil {
		fmt.Println(err)
	}

	if website.ExistsDenyList(this.Ctx.Input.IP()){
		this.Ctx.Redirect(302, opencs.UrlToDeny)
		return
	}
	this.Ctx.Output.Body([]byte(this.Ctx.Input.UserAgent()))
	this.Ctx.Output.Body([]byte(this.Ctx.Input.Url()))
	this.Ctx.Output.Body([]byte(this.Ctx.Input.IP()))
	// this.Data["ViewerCount"] = website.ViewerCount
	// this.TplNames = "Home.tpl"
}
