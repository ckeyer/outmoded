package main

import (
	"fmt"
	"github.com/PuerkitoBio/goquery"
)

func main() {
	doc, err := goquery.NewDocument("http://fc.wut.edu.cn:8086")
	// goquery.NewDocumentGBK("http://www.gzepb.gov.cn/comm/pm25.asp")
	if err != nil {
		panic(err)
	}
	str := doc.Find("div[id=myModalLabel]").Text()
	fmt.Println(str)
	fmt.Println("Over")
}
