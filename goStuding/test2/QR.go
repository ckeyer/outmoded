package main

import (
	"fmt"
	"log"
	"net/http"
)

type htmltest struct {
	text string
}

var te htmltest

func main() {
	http.HandleFunc("/", QR)
	te.text = "CJ_Studio"

	err := http.ListenAndServe(":2222", nil)
	if err != nil {
		log.Fatal("ListenAndServe:", err)
	}
}

func QR(w http.ResponseWriter, r *http.Request) {
	r.ParseForm()
	for k, v := range r.Form {
		if k == "s" {
			if v[0] == "" {
				te.text = "CJ_Studio"
			} else {
				te.text = fmt.Sprintf("%v", v[0])
			}
		}
	}
	fmt.Fprintf(w, `<html><head><title>QR Link Generator</title></head>
		<body><center>
		<form action="/" name=f method="GET">
		<input maxLength=1024 size=50 name=s value="" title="Text to QR Encode">
		<input type=submit value="Show QR" name=qr>
		</form><br>
		<img src="http://chart.apis.google.com/chart?chs=300x300&cht=qr&choe=UTF-8&chl=`+fmt.Sprint(te.text)+
		`" title="`+fmt.Sprint(te.text)+`"/>
		</center></body></html>`)
}
