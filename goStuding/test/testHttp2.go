package main

import (
	"io"
	"log"
	"net/http"
)

func main() {
	mux := http.NewServeMux()

	mux.Handle("/", &myhandle{})
	mux.HandleFunc("/hello", sayHello)

	err := http.ListenAndServe(":2222", mux)
	if err != nil {
		log.Fatal(err)
	}
}

type myhandle struct{}

func (*myhandle) ServeHTTP(w http.ResponseWriter, r *http.Request) {
	io.WriteString(w, "URL"+r.URL.String())
}

func sayHello(w http.ResponseWriter, r *http.Request) {
	io.WriteString(w, "hello world version 2")
}
