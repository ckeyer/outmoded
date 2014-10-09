package main

import (
	"fmt"
	"net/http"
)

const (
	SERVER_PORT   = 2222
	SERVER_DOMAIN = "localhost"
	TMP           = "hello"
)

func main() {
	http.HandleFunc(fmt.Sprintf("%s:%d\n", SERVER_DOMAIN, SERVER_PORT), rootHandler)
	http.ListenAndServeTLS(fmt.Sprintf(":%d", SERVER_PORT), "rui.crt", "rui.key", nil)
}

func rootHandler(w http.ResponseWriter, r *http.Request) {
	w.Header().Set("Content-Type", "text/html")
	w.Header().Set("Content-length", fmt.Sprint(len(TMP)))
	w.Write([]byte(TMP))
}
