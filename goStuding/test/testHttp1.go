package main

import (
	"io"
	"log"
	"net/http"
)

func main() {
	http.HandleFunc("/", sayHello)

	err := http.ListenAndServeTLS(":2222", "rui.crt", "rui.key", nil)
	if err != nil {
		log.Fatal(err)
	}
}

func sayHello(w http.ResponseWriter, r *http.Request) {
	io.WriteString(w, "Hello, Test version 1")
}
