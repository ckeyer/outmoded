package controllers

  import (
    "Opencs/controllers/opencs"
    "fmt"
    "github.com/astaxie/beego"
    // "opencs"
    )

    type DenyController struct {
      beego.Controller
    }

    func (this *DenyController) Get() {
      // this.Data["Website"] = "beego.me"
      // this.Data["Email"] = "astaxie@gmail.com"
      var website opencs.Website
      err := website.Init_Website()
      if err != nil {
        fmt.Println(err)
      }
      // fmt.Print("Hello")
      // this.Data["ViewerCount"] = website.ViewerCount
      // this.Ctx.Output.Body([]b yte("hello"))


      website.AddToDenyList(this.Ctx.Input.IP())

      this.Ctx.Redirect(302, opencs.UrlToDeny)

    }
