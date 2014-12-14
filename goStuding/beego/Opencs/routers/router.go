package routers

import (
	"Opencs/controllers"
	"github.com/astaxie/beego"
)

func init() {
		beego.Router("/", &controllers.MainController{})
		beego.Router("/login", &controllers.LoginController{})
		beego.Router("/sign", &controllers.SignController{})

		beego.Router("/forum", &controllers.ForumController{})
		beego.Router("/blog", &controllers.BlogController{})
		beego.Router("/video", &controllers.VideoController{})
		beego.Router("/jour", &controllers.JourController{})
		beego.Router("/notice", &controllers.NoticeController{})
		beego.Router("/lab204", &controllers.Lab204Controller{})

		beego.Router("/message", &controllers.MessageController{})


		beego.Router("/apps/*", &controllers.DenyController{})
}
